using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Author
    {
        public int Id { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(40)]
        public string LastName { get; set; }
    }
}
