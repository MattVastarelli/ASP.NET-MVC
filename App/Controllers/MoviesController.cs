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

        //a given customers info
        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            // movie list
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie != null)
            {
                var viewModel = new MovieDetailsViewModel()
                {
                    Movie = movie
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