using KnowledgeHub.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHub.Web.Models.Data
{
    public class KnowledgeHUbDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =(localdb)\\mssqllocaldb;Initial Catalog=KnowledgeHubdb2022;Integrated Security=True");
        }
        //Creating a table in database
        public DbSet<Category> categories { get; set; }
    }
}
//need to specoify the context as there is a two context in the project.
//Add-migration -context KnowledgeHub.Web.Models.Data.KnowledgeHUbDbContext init
//update-database -context KnowledgeHub.Web.Models.Data.KnowledgeHUbDbContext