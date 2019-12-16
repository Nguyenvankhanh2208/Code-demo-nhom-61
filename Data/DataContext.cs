using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Core.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }// dùng để đổ dữ liệu vào

        public DataContext() : base("ProductConnectionString")// sinh database trong models
        {
            Database.SetInitializer<DataContext>(null);
            //Database.CreateIfNotExists();
        }
        public static void InitDb()
        {
            using (var db = new DataContext())
            {
                if (!db.Database.Exists())
                {
                    db.Database.CreateIfNotExists();
                }
            }
        }

    }
}