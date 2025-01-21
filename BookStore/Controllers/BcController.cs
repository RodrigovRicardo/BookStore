using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using SQLitePCL;

namespace BookStore.Controllers
{
    public class BcController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookStoreContext _context;

        public BcController(ILogger<HomeController> logger, BookStoreContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var Books = _context.Books.OrderByDescending(p => p.Id).ToList();
            return View(Books);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound(); // Or return a different error view
            }

            return View(book); // Pass the book object as the model
        }

        public IActionResult Edit(int id)
        {
            var book = _context.Books.FirstOrDefault(p => p.Id == id);

            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if(ModelState.IsValid)
            {
                _context.Books.Update(book);
                _context.SaveChanges();

                return RedirectToAction("Backoffice", "Home");
            }
            // Log the model state errors to the console
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    _logger.LogError($"Property: {state.Key}, Error: {error.ErrorMessage}");
                }
            }

            return View(book);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(p => p.Id == id);
                
            if(book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            // Log the model state errors to the console
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    _logger.LogError($"Property: {state.Key}, Error: {error.ErrorMessage}");
                }
            }
            return RedirectToAction("Backoffice","Home");
        }

    }
}
