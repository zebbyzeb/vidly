using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewMovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string DateAdded { get; set; }
        public int AvailableStock { get; set; }
        public Genre Genre { get; set; }
        public int? GenreId { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}