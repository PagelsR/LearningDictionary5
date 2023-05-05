using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using LearningDictionary5.Web;
using LearningDictionary5.Web.Models;

public class FunctionsDictionary
{
    private readonly MyDbContext _dbContext;

    public FunctionsDictionary(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [FunctionName("CreateDictionary")]
    public async Task<IActionResult> CreateDictionary(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "items")] Dictionary dictionary,
        ILogger log)
    {
        log.LogInformation($"C# HTTP trigger function processed a request to create an item with name {dictionary.PrimaryLanguage} and description {dictionary.SecondaryLanguage}.");

        _dbContext.Dictionary.Add(dictionary);
        await _dbContext.SaveChangesAsync();

        return new OkObjectResult(dictionary);
    }

    [FunctionName("GetDictionary")]
    public async Task<IActionResult> GetDictionary(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "items/{id}")] int id,
        ILogger log)
    {
        log.LogInformation($"C# HTTP trigger function processed a request to get an item with ID {id}.");

        Dictionary dictionary = await _dbContext.Dictionary.FindAsync(id);

        if (dictionary == null)
        {
            return new NotFoundResult();
        }

        return new OkObjectResult(dictionary);
    }

    [FunctionName("UpdateDictionary")]
    public async Task<IActionResult> UpdateDictionary(
        [HttpTrigger(AuthorizationLevel.Function, "put", Route = "items/{id}")] Dictionary updatedItem,
        [FromRoute] int id,
        ILogger log)
    {
        log.LogInformation($"C# HTTP trigger function processed a request to update an item with ID {id}.");

        Dictionary dictionary = await _dbContext.Dictionary.FindAsync(id);

        if (dictionary == null)
        {
            return new NotFoundResult();
        }

        dictionary.PrimaryLanguage = updatedItem.PrimaryLanguage;
        dictionary.SecondaryLanguage = updatedItem.SecondaryLanguage;
        dictionary.UserId = updatedItem.UserId;
        dictionary.User = updatedItem.User;
        await _dbContext.SaveChangesAsync();

        return new OkObjectResult(dictionary);
    }

    [FunctionName("DeleteDictionary")]
    public async Task<IActionResult> DeleteDictionary(
        [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "items/{id}")] int id,
        ILogger log)
    {
        log.LogInformation($"C# HTTP trigger function processed a request to delete an item with ID {id}.");

        Dictionary dictionary = await _dbContext.Dictionary.FindAsync(id);

        if (dictionary == null)
        {
            return new NotFoundResult();
        }

        _dbContext.Dictionary.Remove(dictionary);
        await _dbContext.SaveChangesAsync();

        return new OkResult();
    }
}
