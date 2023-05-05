using LearningDictionary5.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Retrieve the Connection String from the secrets manager 
var connectionString = builder.Configuration.GetConnectionString("AppConfig");

//string connectionString = "SqlConnectionString";

builder.Host.ConfigureAppConfiguration(builder =>
{
    // Connect to your App Config Store using the connection string
    builder.AddAzureAppConfiguration(options =>
    {
        options.Connect(connectionString);
    });
    //builder.Services.AddDbContext<MyDbContext>(options =>
    //options.UseSqlServer(connectionString));
})
    .ConfigureServices(services =>
    {
        // Add MVC views and Controller services to the container.
        services.AddControllersWithViews();
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DBContext services to the container
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LearningDictionaryDBConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();