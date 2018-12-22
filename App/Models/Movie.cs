using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class Movie
    {
        public int Id { get; set;}
        public string Name { get; set;}
        //Genre 
        public Genre Genre { get; set; }
        //FK
        public byte GenreID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int Stock { get; set; }
    }
}