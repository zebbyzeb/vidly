using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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
    }
}