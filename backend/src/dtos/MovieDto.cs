namespace CinemaBooking.dto
{
    public class MovieDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public List<string> Genre { get; set; }
        public string Poster { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Status { get; set; }
    }
}