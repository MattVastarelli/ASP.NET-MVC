using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class Movie
    {
        public int Id { get; set;}

        [Required]
        [StringLength(255)]
        public string Name { get; set;}

        //Genre 
        [Display(Name = "Genre")]
        public Genre Genre { get; set; }

        //FK
        [Display(Name = "Genre")]
        [Required]
        public byte GenreID { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public int Stock { get; set; }

        public byte NumberAvailable { get; set; }
    }
}