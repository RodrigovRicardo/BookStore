using BookStore.Models;

namespace BookStore.ViewModels
{
    public class OrderViewModel
    {
        public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public int PhoneNumber { get; set; }


		public int BookId { get; set; }
		public string Image { get; set; }
		public string Title { get; set; }
		public decimal Price { get; set; }
	}
}
