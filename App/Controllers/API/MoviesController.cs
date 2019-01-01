using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using App.DTOS;
using App.Models;
using AutoMapper;

namespace App.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<MoviesDTO> GetMovies()
        {
            return _context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MoviesDTO>);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                NotFound();
            }
            return Ok(Mapper.Map<Movie, MoviesDTO>(movie));
        }

        [HttpPost]
        [System.Web.Mvc.Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MoviesDTO moviesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var movie = Mapper.Map<MoviesDTO, Movie>(moviesDto);
                _context.Movies.Add(movie);
                _context.SaveChanges();

                //add the id to the movie dto
                moviesDto.Id = movie.Id;

                return Created(new Uri(Request.RequestUri + "/" + moviesDto.Id), moviesDto);
            }
        }

        [HttpPut]
        [System.Web.Mvc.Authorize(Roles = RoleName.CanManageMovies)]
        public void UpdateMovie(int id, MoviesDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

                if (movie == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    Mapper.Map<MoviesDTO, Movie>(movieDto, movie);

                    _context.SaveChanges();
                }
            }
        }

        [HttpDelete]
        [System.Web.Mvc.Authorize(Roles = RoleName.CanManageMovies)]
        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }


    }
}
