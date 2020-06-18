namespace UnitTests.Dtos
{
    public class TrackDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }
        public MediaTypeDto MediaType { get; set; }
        public GenreDto Genre { get; set; }
    }
}
