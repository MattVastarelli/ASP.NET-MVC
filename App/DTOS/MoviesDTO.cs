using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using App.Models;

namespace App.DTOS
{
    public class MoviesDTO
    {
        public int Id { get; set;}

        [Required]
        [StringLength(255)]
        public string Name { get; set;}

        //Genre 
        public GenresDTO Genre { get; set; }

        //FK
        [Required]
        public byte GenreID { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Range(1, 20)]
        public int Stock { get; set; }
    }
}