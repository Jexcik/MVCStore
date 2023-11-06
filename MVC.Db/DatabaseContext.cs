using Microsoft.EntityFrameworkCore;
using MVC.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Db
{
    //Доступ к таблице
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<CompareProduct> CompareProducts { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureCreated();//Создаем базу данных при первом обращении

            //Применяет текущую миграцию
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                    new Product(){Name="ГОРГОРОД",Author="Oxxxymiron",ReleaseYear= 2015,Cost=3150,Description= "Второй студийный альбом российского рэпера Oxxxymiron",ImagePath="/images/Горгород.jpg"},
                    new Product(){Name="Дом с нормальными явлениями",Author = "Скриптонит",ReleaseYear = 2015,Cost=1850,Description="Дебютный альбом",ImagePath="/images/Скриптонит.jpg"},
                    new Product(){Name="Ещё", Author = "GUF", ReleaseYear = 2016, Cost=2000, Description = "Legendary Album",ImagePath="/images/ЕЩЁ.jpg"},
                    new Product(){Name="Моя Игра",Author= "Баста",ReleaseYear = 2006,Cost = 3000,Description ="TheBest Production",ImagePath="/images/Баста.jpg"}
            });
        }
    }
}
