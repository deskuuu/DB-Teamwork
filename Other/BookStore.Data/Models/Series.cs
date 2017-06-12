﻿namespace BookStore.Data.SqlServer.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Series
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}