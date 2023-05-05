using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using LearningDictionary5.Web;
using LearningDictionary5.Web.Models;

public class FunctionsWord
{
    private readonly MyDbContext _dbContext;

    public FunctionsWord(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [FunctionName("CreateWord")]
    public async Task<IActionResult> CreateWord(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "items")] Word word,
        ILogger log)
    {
        log.LogInformation($"C# HTTP trigger function processed a request to create an item with name {word.PrimaryWord}. and description {word.SecondaryWord}.");

        _dbContext.Word.Add(word);
        await _dbContext.SaveChangesAsync();

        return new OkObjectResult(word);
    }

    [FunctionName("GetWord")]
    public async Task<IActionResult> GetWord(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "items/{id}")] int id,
        ILogger log)
    {
        log.LogInformation($"C# HTTP trigger function processed a request to get an item with ID {id}.");

        Word word = await _dbContext.Word.FindAsync(id);

        if (word == null)
        {
            return new NotFoundResult();
        }

        return new OkObjectResult(word);
    }

    [FunctionName("UpdateWord")]
    public async Task<IActionResult> UpdateWord(
        [HttpTrigger(AuthorizationLevel.Function, "put", Route = "items/{id}")] Word updatedItem,
        [FromRoute] int id,
        ILogger log)
    {
        log.LogInformation($"C# HTTP trigger function processed a request to update an item with ID {id}.");

        Word word = await _dbContext.Word.FindAsync(id);

        if (word == null)
        {
            return new NotFoundResult();
        }

        word.PrimaryWord = updatedItem.PrimaryWord;
        word.SecondaryWord = updatedItem.SecondaryWord;
        await _dbContext.SaveChangesAsync();

        return new OkObjectResult(word);
    }

    [FunctionName("DeleteWord")]
    public async Task<IActionResult> DeleteWord(
        [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "items/{id}")] int id,
        ILogger log)
    {
        log.LogInformation($"C# HTTP trigger function processed a request to delete an item with ID {id}.");

        Word word = await _dbContext.Word.FindAsync(id);

        if (word == null)
        {
            return new NotFoundResult();
        }

        _dbContext.Word.Remove(word);
        await _dbContext.SaveChangesAsync();

        return new OkResult();
    }
}
