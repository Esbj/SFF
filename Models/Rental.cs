namespace SFF.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int AssosiationId { get; set; }
        public bool Rented { get; set; }
    }
}