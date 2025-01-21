using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace BookStore.Controllers
{
    public class BcController : Controller
    {
        private readonly BookStoreContext context;

        public BcController(BookStoreContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var Books = context.Books.OrderByDescending(p => p.Id).ToList();
            return View(Books);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var book = context.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound(); // Or return a different error view
            }

            return View(book); // Pass the book object as the model
        }
    }
}
