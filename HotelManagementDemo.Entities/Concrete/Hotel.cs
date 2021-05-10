namespace HotelManagementDemo.Entities.Concrete
{
    public class Hotel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Zip { get; set; }
        public string Address { get; set; }
    }
}
