using System.Collections.Concurrent;
using DistinctWordCounterLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WordsQuantityController : ControllerBase
{
    [HttpGet(Name = "GetWordsQuantity")]
    public ConcurrentDictionary<string,int> Get(string fileContent)
    {
        return new DistinctWordCounter().GetWordsQuantityInParallelWithParallelFor(fileContent);
    }
}