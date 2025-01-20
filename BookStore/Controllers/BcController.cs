using Microsoft.AspNetCore.Mvc;

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
    }
}
