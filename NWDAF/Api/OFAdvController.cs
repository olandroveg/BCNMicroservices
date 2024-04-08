using Microsoft.AspNetCore.Mvc;
using NWDAF.Models;
using System.Collections.Generic;
using System.Linq;
namespace NWDAF.Api
{
    [Route("api/[controller]/[action]")]
    public class OFAdvController : ControllerBase
    {
        private readonly ILogger<OFAdvController> _logger;
        private string _maximunWeigth = "50"; //only for visualization parameters
        private string _otherMaxWeigth = "5";// for other paramters but the visualization time, who has another specific weigth, in order could be of higher priority

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

        public OFAdvController(ILogger<OFAdvController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task <IActionResult> StartAdvertStats()
        {
            await ParalProcess();
            _logger.LogInformation("From controller");
            return Ok();
        }
        
        private async Task ParalProcess()
        {
            var category = "";
            await Task.Run(() =>
            {
                category = AnalyzeStats();
            }).ContinueWith(async task =>
            {
                // Handle task completion or process the result
                await SendByAPI(category);
            });
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
        private int GenerateWeigthForParameter(int weigth)
        {
            int numb = new Random().Next(1, weigth + 1); // Generates a number between 1 to weigth
            return numb;
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
        private void DeletePreviousFiles(string path)
        {
            string[] filePaths = Directory.GetFiles(path);
            foreach (string filePath in filePaths)
                System.IO.File.Delete(filePath);
        }
        public async Task<string> SendByAPI(string incom)
        {
            return "test";
        }
    }
}
