using System.ComponentModel.DataAnnotations;

namespace CetStudentBook.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        public int BookId { get; set; }
        public Book? Book { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
