using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Adams.Models;

namespace Mission06_Adams.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private AddMovieContext _context;
        public HomeController(AddMovieContext temp) 
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            _context.Movies.Add(response); //Add record to the database
            _context.SaveChanges();
            

            return View("Confirmation", response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ListTable()
        {
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .Select(x => new Movie
                {
                    MovieID = x.MovieID,
                    Title = x.Title,
                    Year = x.Year ?? 0,  // Default 0 for NULL years
                    Edited = x.Edited ?? false,  // Default false for NULL Edited
                    CopiedToPlex = x.CopiedToPlex ?? false,  // Default false for NULL CopiedToPlex
                    CategoryId = x.CategoryId, // Handle CategoryId as nullable, default 0 if NULL
                    Category = x.Category,
                    Director = x.Director ?? "",  // Default empty string for NULL Director
                    Rating = x.Rating ?? "",  // Default empty string for NULL Rating
                    LentTo = x.LentTo ?? "",  // Default empty string for NULL LentTo
                    Notes = x.Notes ?? ""  // Default empty string for NULL Notes
                })
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieID == id);

            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

            return View("AddMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            _context.Update(updatedMovie);
            _context.SaveChanges();

            return RedirectToAction("ListTable");
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieID == id);

            return View("Delete", recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie deletedMovie)
        {
            _context.Movies.Remove(deletedMovie);
            _context.SaveChanges();

            return RedirectToAction("ListTable");
        }

    }
}
