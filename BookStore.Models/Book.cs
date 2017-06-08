using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public int Price { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
