namespace BookStore.Data.SqlServer.Models
{
    // using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Author
    {
        private ICollection<Book> books;

        public Author()
        {
            // this.Id = Guid.NewGuid();
            this.books = new HashSet<Book>();
        }

        [Key]

        //// public Guid Id { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(40)]
        public string Lastname { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }

            set { this.books = value; }
        }
    }
}
