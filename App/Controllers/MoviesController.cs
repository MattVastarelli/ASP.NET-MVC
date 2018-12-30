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
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("Movies");
            }
            else
            {
                return View("ReadOnly");
            }
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
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList(),
                };

                return View("MovieForm", viewModel);
            }
        }


        //add a new movie
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel(new Movie())
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList(),
                };

                return View("MovieForm", viewModel);
            }


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