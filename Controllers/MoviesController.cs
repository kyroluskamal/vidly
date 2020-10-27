using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var movies = _context.Movies.Include(G => G.genre).ToList();
            return View(movies);
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(G => G.genre).SingleOrDefault(c => c.Id==id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
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