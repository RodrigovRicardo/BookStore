using System.Diagnostics;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static NuGet.Packaging.PackagingConstants;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookStoreContext _context;

        private List<Book> books = new List<Book>();

        public HomeController(ILogger<HomeController> logger, BookStoreContext context)
		{
			_logger = logger;
			_context = context;
		}
        public IActionResult Index(string? search = "")
        {
            var query = _context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                books = query.Where(s => s.Title.ToLower().Contains(search) || s.Author.ToLower().Contains(search)).ToList();
            }
            else
            {
                books = query.ToList();
            }

            var ViewModel = new indexviewmodel
            {
                Search = search ?? string.Empty,
                Books = books
            };

            return View(ViewModel);
        }
        public IActionResult Orders()
        {
  
            return View();
        }

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
