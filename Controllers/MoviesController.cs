using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;
        public MoviesController() {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index() {
            var movies = _context.Movies.Include(G => G.Genre).ToList();
            return View(movies);
        }

        public ActionResult newMovieForm() {
            var gnereList = _context.Genre.ToList();
            var movieGenreViewModel = new MovieGenreViewModel
            {
                genre = gnereList
            };
            return View(movieGenreViewModel);
        }

        public ActionResult Edit(int id) {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieGenreViewModel {
                Movie = movie,
                genre = _context.Genre.ToList()
            };
            return View("newMovieForm", viewModel);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(G => G.Genre).SingleOrDefault(c => c.Id==id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie Movie) {
            if (!ModelState.IsValid) { 
                var viewmodel = new MovieGenreViewModel{
                    Movie = Movie,
                    genre = _context.Genre.ToList()
                };
                return View("newMovieForm", viewmodel);
            }
            if (Movie.Id == 0)
            {
                _context.Movies.Add(Movie);
            }
            else
            {
                var newMovie = _context.Movies.Single(m => m.Id == Movie.Id);
                newMovie.Name = Movie.Name;
                newMovie.ReleaseDate = Movie.ReleaseDate;
                newMovie.DateAdded = Movie.DateAdded;
                newMovie.GenreId = Movie.GenreId;
                newMovie.numberInStock = Movie.numberInStock;
            }
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Movies");
        }
        // GET: Movies
        public ActionResult Radnom()
        {
            var movie = new Movie(){Name = "Shark"};

            List<Customer> customers = new List<Customer> { 
                new Customer { name = "Customer 1"},
                new Customer { name = "customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }
    }
}