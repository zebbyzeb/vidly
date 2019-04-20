using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string DateAdded { get; set; }
        public int AvailableStock { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}