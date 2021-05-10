using HotelManagementDemo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementDemo.DataAccess.Concrete.EntityFramework.Contexts
{
    public class HotelManagementDemoContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        //}
        public DbSet<Hotel> Hotels { get; set; }
    }
}
