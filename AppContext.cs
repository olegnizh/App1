using App1.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;


namespace App1
{
	public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        // Объекты таблицы UserCredentials
        public DbSet<UserCredential> UserCredentials { get; set; }

        // Объекты таблицы Companies
        public DbSet<Company> Companies { get; set; }


        /*public AppContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var ConStr = @"Server=(localdb)\mssqllocaldb;Database=mstest1;Trusted_Connection=True;";
            //var ConStr = @"Server=HOME-PC\SQLEXPRESS;Database=mstest2;Trusted_Connection=True;";
            //optionsBuilder.UseSqlServer(ConStr);                        

            //var ConStr = "server=localhost;port=3306;database=app1;user=root;password=;";
            //optionsBuilder.UseMySql(ConStr, ServerVersion.AutoDetect(ConStr));

            var ConStr = "Server=127.0.0.1;Port=5432;Database=app1;User Id=alex;Password=;";
            optionsBuilder.UseNpgsql(ConStr);

        }
    }
}