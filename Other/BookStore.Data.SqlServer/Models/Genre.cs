namespace BookStore.Data.SqlServer.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }
    }
}
