namespace BookStore.Data.SqLite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Cities")]
    public class City
    {
        private ICollection<Library> libraries;

        public City()
        {
            this.libraries = new HashSet<Library>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Library> Libraries
        {
            get { return this.libraries; }

            set { this.libraries = value; }
        }
    }
}