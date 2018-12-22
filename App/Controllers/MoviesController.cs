using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using App.Models;
using App.ViewModels;

namespace App.Controllers
{
    [RoutePrefix("Movies")]
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            // movie list
            var movies = new List<Movie>
            {
                new Movie {Name = "Shrek", Id = 1},
                new Movie {Name = "Wall-e", Id = 2}
            };


            var viewModel = new MoviesViewModel
            {
                Movies = movies
            };

            return View("Movies", viewModel);
        }

        //a given customers info
        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            // movie list
            var movies = new List<Movie>
            {
                new Movie {Name = "Shrek", Id = 1},
                new Movie {Name = "Wall-e", Id = 2}
            };

            if (movies.Count >= id)
            {
                var viewModel = new MovieDetailsViewModel()
                {
                    Movie = movies[id - 1]
                };

                return View("MovieDetails", viewModel);
            }
            else
            {
                return new HttpNotFoundResult();
            }
        }
    }
}