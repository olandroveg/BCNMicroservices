using Quartz;
using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using OF.Utility;
using System.IO;
using System.Linq;
using OF.Models;
using OF.RequestApi;

namespace OF.Services.JobServices
{
    [DisallowConcurrentExecution]
    public class AdvertisMetricJob : IJob
    {
        private string _userNumberFiles = StaticConfigurationManager.AppSetting["AdvertStats:numberOfRecordGenerate"];
        private string _generateUserStatOrNot = StaticConfigurationManager.AppSetting["AdvertStats:generateUserStatsOn/off"];
        private string _sendCategoryOrNot = StaticConfigurationManager.AppSetting["AdvertStats:sendCategoryOn/off"];
        private string _maximunWeigth = StaticConfigurationManager.AppSetting["AdvertStats:maximumOfStatWeigth"]; //only for visualization parameters
        private string _otherMaxWeigth = StaticConfigurationManager.AppSetting["AdvertStats:otherMaxWeigth"];// for other paramters but the visualization time, who has another specific weigth, in order could be of higher priority
        private string _directCategory = StaticConfigurationManager.AppSetting["AdvertStats:defineCategory:directAssignCategory"]; // if off, dont assign directly any category
        private string _numberCategories = StaticConfigurationManager.AppSetting["AdvertStats:defineCategory:numberOfCategories"];
        private string _categories = StaticConfigurationManager.AppSetting["AdvertStats:defineCategory"];

        //  Ordenador My Desktop TSR
        private string _StatsDirectory = @"C:\Users\1094545\Documents\Trabajo\StatisticUser\";
        private string _StatsAdvertising = @"C:\Users\1094545\Documents\Trabajo\StatisticAdvertsing\";


        //  Ordenador DEMO TSR
        //private string _StatsDirectory = @"C:\Users\Admin\Documents\Orlando\StatisticUser\";
        //private string _StatsAdvertising = @"C:\Users\Admin\Documents\Orlando\StatisticAdvertsing\";

        //// My laptop windows
        ////private string _StatsDirectory = @"C:\Users\1094545\source\repos\Core\CoreNetwork\StatisticUser";


        ///// MAC
        //private string _StatsDirectory = @"/Users/subzero/Documents/StatisticUser/";
        //private string _StatsAdvertising = @"/Users/subzero/Documents/StatisticAdvertsing/";

        private List<AdvertisingMetric> metrics = new List<AdvertisingMetric>();
        private readonly ILogger<AdvertisMetricJob> _logger;

        public AdvertisMetricJob(ILogger<AdvertisMetricJob> logger)
        {
            // Do background jobs here
            // example Hello World log every 5 secs
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Collecting statistics and sending to DASH server after 48 secs");

            if (_generateUserStatOrNot == "on")
            {
                if (_directCategory == "off")
                    GenerateStatics();
                else
                    await SendByAPI(_directCategory);
            }
            if (_sendCategoryOrNot == "on")
            {
                //var category = AnalyzeStats();
                var category = await new SendCategory().ReqstCategory();
                try
                {
                    await SendByAPI(category);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            //return Task.CompletedTask;

            //NOTA: se comentarea 'return Task.CompletedTask' para poner async en la definicion del metodo, para poder llamar a funciones await
            //Se probó y funciona el Job. Si no es necesario que el metodo sea async, se puede dejar 'return Task.CompletedTask'
        }

        private string AnalyzeStats()
        {
            int fileCount = Directory.GetFiles(_StatsDirectory, "*", SearchOption.AllDirectories).Length;
            var My_dict1 = new Dictionary<string, int>();
            for (int i = 0; i < fileCount; i++)
            {
                ReadFile(i, My_dict1);
            }
            // According to value number of dictionary[category], normalize according to a weigth value. 
            var finalDict = NormalizeToVisualizationWeigth(My_dict1, fileCount);
            var category = GenerateCategoriesStats(finalDict);
            return category;
        }
        private string GenerateCategoriesStats(Dictionary<string, int> dictionary)
        {
            var metrics = new List<AdvertisingMetric>();
            WriteCategoriesStats(dictionary, metrics);
            string category = SuggestVideoCategory(metrics);
            //write category result in textfile
            var fileManager = new TextFileManager();
            var lineText = new List<string>();
            lineText.Add("suggested_advertisement_category: " + category);
            string suggestedCateg = _StatsAdvertising + "suggested_video_category.txt";
            fileManager.InsertLine(suggestedCateg, lineText);
            return category;
        }
        private string SuggestVideoCategory(List<AdvertisingMetric> metrics)
        {
            int value = 0;
            var category = "";
            for (int i = 0; i < metrics.Count(); i++)
            {
                if (metrics.ElementAt(i).weigthSum > value)
                {
                    value = metrics.ElementAt(i).weigthSum;
                    category = metrics.ElementAt(i).category;
                }
            }
            return category;
        }
        private void WriteCategoriesStats(Dictionary<string, int> dictionary, List<AdvertisingMetric> metrics)
        {
            DeletePreviousFiles(_StatsAdvertising);
            var fileManager = new TextFileManager();
            foreach (var dict in dictionary)
            {
                string userStat = _StatsAdvertising + "category_stat_" + dict.Key + ".txt";
                var lineText = new List<string>();
                var metric = new AdvertisingMetric();

                metric.category = dict.Key;
                lineText.Add("category: " + dict.Key);

                metric.visualTime = dict.Value;
                lineText.Add("visualization_time: " + dict.Value);

                var weigth = GenerateWeigthForParameter(int.Parse(_otherMaxWeigth));
                metric.payment = weigth;
                lineText.Add("payment_license: " + weigth.ToString());

                weigth = GenerateWeigthForParameter(int.Parse(_otherMaxWeigth));
                metric.alreadShown = weigth;
                lineText.Add("not_repeated: " + weigth.ToString());

                weigth = GenerateWeigthForParameter(int.Parse(_otherMaxWeigth));
                metric.socialContext = weigth;
                lineText.Add("social_context: " + weigth.ToString());

                lineText.Add("Sum_parameters: " + metric.weigthSum.ToString());

                metrics.Add(metric);
                fileManager.InsertLine(userStat, lineText);
            }

        }
        private Dictionary<string, int> NormalizeToVisualizationWeigth(Dictionary<string, int> dictionary, int fileCount)
        {
            var finalDictionary = new Dictionary<string, int>();
            int weigth = int.Parse(_maximunWeigth);
            int wigthxFileCount = weigth * fileCount;
            foreach (var dict in dictionary)
            {
                decimal ratio = (Decimal)dict.Value / (Decimal)wigthxFileCount;
                // get decimal and round to nearest no decimal value
                decimal valueDec = Math.Round(ratio * weigth, 0);
                // convert to Int
                int realValue = Decimal.ToInt32(valueDec);
                // insert the value in the final dictrionay place.
                finalDictionary.Add(dict.Key, realValue);
            }
            return finalDictionary;
        }
        private void ReadFile(int i, Dictionary<string, int> dictionary)
        {
            string fileName = _StatsDirectory + "user_stats_" + i.ToString() + ".txt";
            if (System.IO.File.Exists(fileName))
            {
                var categ = "";
                int weigth = 0;
                string[] lines = System.IO.File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    if (line.Contains("CategoryName"))
                        categ = line.Substring(14);
                    else
                        weigth = int.Parse(line.Substring(15));
                }
                if (dictionary.ContainsKey(categ))
                {
                    int value = dictionary[categ];
                    dictionary[categ] = value + weigth;
                }
                else
                    dictionary.Add(categ, weigth);

            }
        }
        private void GenerateStatics()
        {
            List<string> categories = ExtractCategories();
            DeletePreviousFiles(_StatsDirectory);
            GenerateUserStats(categories);

        }
        private void DeletePreviousFiles(string path)
        {
            string[] filePaths = Directory.GetFiles(path);
            foreach (string filePath in filePaths)
                System.IO.File.Delete(filePath);
        }
        private void GenerateUserStats(List<string> categories)
        {
            int weight = int.Parse(_maximunWeigth);
            for (int i = 0; i < int.Parse(_userNumberFiles); i++)
            {

                GenerateOneUser(i, categories, weight);
            }
        }
        private void GenerateOneUser(int i, List<string> categories, int weigth)
        {
            var fileManager = new TextFileManager();
            string userStat = _StatsDirectory + "user_stats_" + i.ToString() + ".txt";
            var lineText = new List<string>();
            int realWeigth;
            realWeigth = GenerateWeigthForParameter(categories.Count());
            lineText.Add("CategoryName: " + categories.ElementAt(realWeigth - 1));
            realWeigth = GenerateWeigthForParameter(weigth);
            lineText.Add("Visualization: " + realWeigth.ToString());
            fileManager.InsertLine(userStat, lineText);

        }

        private int GenerateWeigthForParameter(int weigth)
        {
            int numb = new Random().Next(1, weigth + 1); // Generates a number between 1 to weigth
            return numb;
        }
        private List<string> ExtractCategories()
        {
            List<string> categories = new List<string>();
            for (int i = 0; i < int.Parse(_numberCategories); i++)
            {
                categories.Add(StaticConfigurationManager.AppSetting["AdvertStats:defineCategory:" + i.ToString()]);
            }
            return categories;
        }

        // Send to RasberryVide API the category suggested
        // SendAPI()
        //private async Task<string> SendPredictedCategory(string category)
        //{
        //    var configRequest = await new SendRasberryVideoCat().SendConfig(category);
        //    return configRequest;
        //}
        public async Task<string> SendByAPI(string incom)
        {
            return "test";
        }

    }
}
