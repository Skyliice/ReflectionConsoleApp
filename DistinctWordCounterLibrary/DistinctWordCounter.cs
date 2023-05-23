using System.Text.RegularExpressions;

namespace DistinctWordCounterLibrary;

public class DistinctWordCounter
{
    private Dictionary<string, int> GetWordsQuantity(string fileContent)
    {
        var finalDictionary = new Dictionary<string, int>();
        fileContent = Regex.Replace(fileContent, "<[^>]+>", string.Empty);
        fileContent = Regex.Replace(fileContent, "[^a-zA-Zа-яА-я'\\s]", string.Empty);
        fileContent = Regex.Replace(fileContent, "[\n\t\r]", string.Empty);
        Console.WriteLine("Файл найден!\nИдет подсчёт слов...");
        var words = fileContent
            .Split(new[] { ",", ";", " " }, StringSplitOptions.RemoveEmptyEntries)
            .GroupBy(o => o.ToLower())
            .OrderByDescending(o => o.Count());
        var finalstr = string.Empty;
        foreach (var word in words)
        {
            finalDictionary.Add(word.Key,word.Count());
        }

        return finalDictionary;
    }
}