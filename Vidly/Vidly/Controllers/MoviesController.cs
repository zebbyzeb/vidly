using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private MyDBContext _context;
        public MoviesController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var viewModel = new RandomMovieViewModel()
            {
                Movie = new Movie()
                {
                    Id = 1,
                    Name = "The Highwaymen"
                },
                Customers = new List<Customer>()
                {
                    new Customer()
                    {
                        Id = 1,
                        Name = "Zebby"
                    },
                    new Customer()
                    {
                        Id = 2,
                        Name = "Kannu"
                    }
                }
            };

            return View(viewModel);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        //how to add the defaults values for year and month usng attribute routing?
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        //public ActionResult Index()
        //{
        //    var movies = _context.Movies
        //        .Include(m => m.Genre)
        //        .ToList();

        //    return View(movies);
        //}

        public ActionResult New()
        {
            var viewModel = new NewMovieViewModel()
            {
                //Movie = new Movie(),
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("New")]
        public ActionResult Save(NewMovieViewModel viewModel)
        {
            if (viewModel.Id == 0) {
                var movie = new Movie();
                movie.Name = viewModel.Name;
                movie.GenreId = viewModel.GenreId;

                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == viewModel.Id);

                movieInDb.Name = viewModel.Name;
                movieInDb.GenreId = viewModel.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult View(int Id)
        {
            var movie = _context.Movies
                .Where(m => m.Id == Id)
                .ToList()
                .FirstOrDefault();
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies
                .Single(m => m.Id == Id);
            var viewModel = new NewMovieViewModel()
            {
                //Movie = movie,
                Name = movie.Name,
                Genres = _context.Genres.ToList()
            };
            return View("New", viewModel);
        }
    }
}