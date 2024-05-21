namespace eHouse.Models
{
    public class gallery
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
        public int? Bookid { get; set; }
        public RentModel Rent { get; set; }
    }
}
