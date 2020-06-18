using System.ComponentModel.DataAnnotations.Schema;

namespace UnitTests.Entities
{
    public class Track
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AlbumID { get; set; }
        public int MediaTypeID { get; set; }
        public int GenreID { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }

        [ForeignKey(nameof(GenreID))]
        public virtual Genre Genre { get; set; }

        [ForeignKey(nameof(MediaTypeID))]
        public virtual MediaType MediaType { get; set; }
    }
}
