using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PhoneNumber { get; set; }
    }
}
