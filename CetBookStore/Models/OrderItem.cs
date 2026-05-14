using System.ComponentModel.DataAnnotations;

namespace CetBookStore.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
        
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal Price { get; set; } 
    }
}
