using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book
    {
        public Book()
        {

        }
        public int Id { get; set; }
        [Column(TypeName = "money")]
        public int Price { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [ForeignKey("Author")]
        public int AuthorRefId { get; set; }
        public Author Author { get; set; }
        [ForeignKey("Genre")]
        public int GenreRefId { get; set; }
        public  Genre Genre { get; set; }
        [ForeignKey("Category")]
        public int CategoryRefId { get; set; }
        public Category Category { get; set; }
        [ForeignKey("Serie")]
        public int SerieRefId { get; set; }
        public Series Serie { get; set; }
    }
}
