using ConvertDatabase.WinApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace ConvertDatabase.WinApp.Repositories
{
    public class PostgresqlRepository<T> : IRepository<T>
    {
        PostgresqlContext db = new PostgresqlContext();
        public void Export(List<T> input)
        {
            throw new System.NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetData()
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
