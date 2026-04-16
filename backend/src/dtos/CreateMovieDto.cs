namespace CinemaBooking.dto
{
    public class CreateMovieDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public List<string> Genre { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}