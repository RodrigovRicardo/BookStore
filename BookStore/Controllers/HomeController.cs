using System.Diagnostics;
using BookStore.Models;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

		public IActionResult Orders(int id = default)
		{
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            var viewModel = new OrderViewModel
            {
                BookId = book.Id,
                Image = book.Image,
                Title = book.Title,
                Price = book.Price,
            };

            return View(viewModel);
		}

		[HttpPost]
        public IActionResult Orders(OrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
				var book = _context.Books.FirstOrDefault(b => b.Id == viewModel.BookId);
				var order = new Order
                {
                    book = book,
                    Name = viewModel.Name,
                    Address = viewModel.Address,
                    City = viewModel.City,
                    PhoneNumber = viewModel.PhoneNumber,
                };

                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

			foreach (var state in ModelState)
			{
				foreach (var error in state.Value.Errors)
				{
					_logger.LogError($"Property: {state.Key}, Error: {error.ErrorMessage}");
				}
			}
			return View(viewModel);
        }

        [Authorize]
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
