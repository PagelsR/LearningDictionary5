using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using LearningDictionary5.Web.Models;

namespace LearningDictionary5.Web;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<Dictionary> Dictionary { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Word> Word { get; set; }
}
