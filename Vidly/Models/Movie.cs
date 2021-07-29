using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {   
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display (Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        [Range(1, 20, ErrorMessage = "The filed Number in Stock must be between 1 and 20.")]
        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
       
    }
}