using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private ApplicationDbContext _context;

        //constructor
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //dispose
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            // movie list
            var movies = _context.Movies.Include(m => m.Genre).ToList();
          


            var viewModel = new MoviesViewModel
            {
                Movies = movies
            };

            return View("Movies", viewModel);
        }

        // edit
        public ActionResult Edit(int? id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList(),
                };

                return View("MovieForm", viewModel);
            }
        }


        //add a new movie
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Today;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Stock = movie.Stock;
                movieInDb.GenreID = movie.GenreID;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}