using System.Diagnostics;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookStoreContext _context;

		public HomeController(ILogger<HomeController> logger, BookStoreContext context)
		{
			_logger = logger;
			_context = context;
		}
        public IActionResult Index(string searchString)
        {
            var books = from b in _context.Books select b;

            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Title.Contains(searchString) || b.Author.Contains(searchString) || b.Publisher.Contains(searchString));
            }

            return View(books.ToList());
        }
        //public IActionResult Index()
        //{
        //	var livros = _context.Books.ToList();
        //	return View(livros);
        //}

        public IActionResult Backoffice()
        {
            return View(_context.Books.ToList());
        }

		public IActionResult Register()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
