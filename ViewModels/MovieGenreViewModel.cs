using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using vidly.Models;

namespace vidly.ViewModels
{
    public class MovieGenreViewModel
    {
        public IEnumerable<Genre> genre { get; set; }
        public Movie Movie { get; set; }

        public readonly string moviIdAtt = "Movie.Id";

        public string getTitle() {
            return (Movie == null) ? "Add new Movie" : "Edit Movie : " + Movie.Name;
        }

        public int getSelectedGenre() {
            return (Movie == null) ? 0 : Movie.GenreId;
        }
    }
}