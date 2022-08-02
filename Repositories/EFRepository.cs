using ConvertDatabase.WinApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConvertDatabase.WinApp.Repositories
{
    public class EFRepository : IRepository
    {
        public void Export()
        {
            throw new System.NotImplementedException();
        }

        public object GetAll()
        {
            throw new System.NotImplementedException();
        }
    }

    public class EfContext : DbContext
    {
        public DbSet<AccountCategories> AccountCategorie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");
    }
}
