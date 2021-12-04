using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OrderManager.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base()
        {
            string database_name = "QuanLyDonHang";
            Database.Connection.ConnectionString = "Data Source=(local);Initial Catalog=" + database_name + ";Trusted_Connection = True";
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
    }
}
