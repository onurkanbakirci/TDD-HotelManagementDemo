using HotelManagementDemo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelManagementDemo.DataAccess.Concrete.EntityFramework.Contexts
{
    public class HotelManagementDemoContext : DbContext
    {
        //public IConfiguration Configuration{ get; }
        //public MySqlDbOptions _mySqlDbOptions{ get; set; }
        //public HotelManagementDemoContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //    _mySqlDbOptions = Configuration.GetSection("MySqlDb").Get<MySqlDbOptions>();

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;port=3306;database=hotel_management_demo;uid=root;password=", ServerVersion.AutoDetect("server=localhost;port=3306;database=hotel_management_demo;uid=root;password="));
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
