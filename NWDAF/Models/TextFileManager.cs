namespace NWDAF.Models
{
    public class TextFileManager
    {
        public void ClearFile(string fileName)
        {
            if (File.Exists(fileName))
                File.WriteAllText(fileName, string.Empty);
        }
        public void WriteWholeFile(string filename, string text)
        {
            if (File.Exists(filename))
                File.WriteAllText(filename, text);
        }
        public void InsertLine(string filename, IEnumerable<string> lines)
        {
            //if (File.Exists(filename))
            //File.AppendAllText(filename, text + Environment.NewLine);
            File.AppendAllLines(filename, lines);

        }
    }
}
