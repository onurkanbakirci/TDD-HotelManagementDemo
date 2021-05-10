namespace HotelSystemDemo.UI.Entities.Concrete
{
    public class Hotel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int PersonalCount { get; set; }
    }
}
