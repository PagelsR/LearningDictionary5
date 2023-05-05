using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using LearningDictionary5.Web;
using LearningDictionary5.Web.Models;

public class FunctionsUser
{
    private readonly MyDbContext _dbContext;

    public FunctionsUser(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [FunctionName("CreateUser")]
    public async Task<IActionResult> CreateUser(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "items")] User user,
        ILogger log)
    {
        log.LogInformation($"C# HTTP trigger function processed a request to create an item with name {user.Username} and description {user.Email}.");

        _dbContext.User.Add(user);
        await _dbContext.SaveChangesAsync();

        return new OkObjectResult(user);
    }

    [FunctionName("GetUser")]
    public async Task<IActionResult> GetUser(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "items/{id}")] int id,
        ILogger log)
    {
        log.LogInformation($"C# HTTP trigger function processed a request to get an item with ID {id}.");

        User user = await _dbContext.User.FindAsync(id);

        if (user == null)
        {
            return new NotFoundResult();
        }

        return new OkObjectResult(user);
    }

    [FunctionName("UpdateUser")]
    public async Task<IActionResult> UpdateUser(
        [HttpTrigger(AuthorizationLevel.Function, "put", Route = "items/{id}")] User updatedUser,
        [FromRoute] int id,
        ILogger log)
    {
        log.LogInformation($"C# HTTP trigger function processed a request to update an item with ID {id}.");

        User user = await _dbContext.User.FindAsync(id);

        if (user == null)
        {
            return new NotFoundResult();
        }

        user.Email = updatedUser.Email;
        user.Password = updatedUser.Password;
        user.Username = updatedUser.Username;
        await _dbContext.SaveChangesAsync();

        return new OkObjectResult(user);
    }

    [FunctionName("DeleteUser")]
    public async Task<IActionResult> DeleteUser(
        [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "items/{id}")] int id,
        ILogger log)
    {
        log.LogInformation($"C# HTTP trigger function processed a request to delete an item with ID {id}.");

        User user = await _dbContext.User.FindAsync(id);

        if (user == null)
        {
            return new NotFoundResult();
        }

        _dbContext.User.Remove(user);
        await _dbContext.SaveChangesAsync();

        return new OkResult();
    }
}
