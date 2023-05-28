using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace DistinctWordCounterLibrary;

public class DistinctWordCounter
{
    private Dictionary<string, int> GetWordsQuantity(string fileContent)
    {
        var finalDictionary = new Dictionary<string, int>();
        Console.WriteLine("Файл найден!\nИдет подсчёт слов...");
        var words = fileContent
            .Split(new[] { ",", ";", " " }, StringSplitOptions.RemoveEmptyEntries)
            .GroupBy(o => o.ToLower())
            .OrderByDescending(o => o.Count());
        foreach (var word in words)
        {
            finalDictionary.Add(word.Key,word.Count());
        }
        return finalDictionary;
    }
    
    public ConcurrentDictionary<string,int> GetWordsQuantityInParallelWithPLinq(string fileContent)
    {
        var finalDictionary = new ConcurrentDictionary<string, int>();
        var words = fileContent
            .Split(new[] { ",", ";", " " }, StringSplitOptions.RemoveEmptyEntries);
        words.AsParallel()
            .WithDegreeOfParallelism(4)
            .ForAll(s => finalDictionary.AddOrUpdate(s.ToLower(), 1, (_, num) => num + 1));
        return finalDictionary;
    }

    public ConcurrentDictionary<string, int> GetWordsQuantityInParallelWithParallelFor(string fileContent)
    {
        var finalDictionary = new ConcurrentDictionary<string, int>();
        
        var words = fileContent
            .Split(new[] { ",", ";", " " }, StringSplitOptions.RemoveEmptyEntries);
        Parallel.ForEach(words, (word) => finalDictionary.AddOrUpdate(word.ToLower(), 1, (_, num) => num + 1));
        return finalDictionary;
    }
}