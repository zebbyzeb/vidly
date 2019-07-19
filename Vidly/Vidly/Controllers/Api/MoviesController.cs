using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.DTOs;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private MyDBContext _context { get; set; }
        public MoviesController()
        {
            _context = new MyDBContext();
        }

        public IEnumerable<MovieDTO> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<MovieDTO>);
        }

        public IHttpActionResult GetMovie(int id)
        {
            try
            {
                var movie = _context.Movies.Where(m => m.Id == id).SingleOrDefault();
                var movieDto = new MovieDTO
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    AvailableStock = movie.AvailableStock,
                    DateAdded = movie.DateAdded,
                    ReleaseDate = movie.ReleaseDate,
                    GenreId = movie.GenreId
                };

                return Ok<MovieDTO>(movieDto);
            }
            catch
            {
                return BadRequest();
            }            
        }

        public IHttpActionResult CreateMovie(MovieDTO movieDto)
        {
            var movie = new Movie
            {
                Name = movieDto.Name,
                AvailableStock = movieDto.AvailableStock,
                DateAdded = movieDto.DateAdded,
                ReleaseDate = movieDto.ReleaseDate,
                GenreId = movieDto.GenreId
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Ok<MovieDTO>(movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(MovieDTO movieDTO)
        {
            var movie = _context.Movies.Where(m => m.Id == movieDTO.Id).SingleOrDefault();

            movie.Name = movieDTO.Name;
            movie.ReleaseDate = movieDTO.ReleaseDate;
            movie.AvailableStock = movieDTO.AvailableStock;
            movie.DateAdded = movieDTO.DateAdded;
            movie.GenreId = movieDTO.GenreId;

            _context.SaveChanges();

            return Ok<MovieDTO>(movieDTO);
        }

        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Remove(_context.Movies.Where(m => m.Id == id).SingleOrDefault());
            _context.SaveChanges();
            return Ok();
        }
    }
}
