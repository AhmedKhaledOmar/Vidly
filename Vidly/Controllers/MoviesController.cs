using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Moives.
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult MovieForm() 
        {
            var Genre = _context.Genres.ToList();

            var viewModel = new NewMovieViewModel
            {
                Genres = Genre,
            };
            return View(viewModel);
        }
        public ActionResult Save(Movie movie)
        {
            movie.DateAdded = DateTime.Now;
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
                Edit(movie);
            _context.SaveChanges();
            return RedirectToAction("Index" , "Movies");
        }
        public ActionResult ViewEdit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
        public ActionResult Index()
        {
            var movie = _context.Movies.Include(c => c.Genre).ToList();
            return View(movie);
        }
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == Id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
       public Movie Edit (Movie movie)
        {
           var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == movie.Id);

            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.NumberInStock = movie.NumberInStock;

            return movieInDb;
        }
    }
}