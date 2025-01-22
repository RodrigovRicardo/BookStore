using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{

 
    public class indexviewmodel
    {
        public string Search { get; set; }
        public List<Book> Books { get; set; }
    }


    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string Language { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }

    }
}
