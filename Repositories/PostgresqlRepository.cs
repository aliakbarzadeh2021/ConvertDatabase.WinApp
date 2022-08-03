using ConvertDatabase.WinApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConvertDatabase.WinApp.Repositories
{
    public class PostgresqlRepository<T> : IRepository<T>
    {
        PostgresqlContext db = new PostgresqlContext();
        public void Export()
        {
            //db.Add();
            throw new System.NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }

    public class PostgresqlContext : DbContext
    {
        public DbSet<AccountCategories> AccountCategorie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");
    }
}
