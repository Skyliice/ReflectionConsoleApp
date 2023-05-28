using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WordsQuantityController : ControllerBase
{
    [HttpGet(Name = "GetWordsQuantity")]
    public ConcurrentDictionary<string,int> Get(string fileContent)
    {
        var finalDictionary = new ConcurrentDictionary<string, int>();
        
        var words = fileContent
            .Split(new[] { ",", ";", " " }, StringSplitOptions.RemoveEmptyEntries);
        Parallel.ForEach(words, (word) => finalDictionary.AddOrUpdate(word.ToLower(), 1, (_, num) => num + 1));
        return finalDictionary;
    }
}