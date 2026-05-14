using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CetBookStore.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }       
        
        [Required(ErrorMessage = "Lütfen kitap adını giriniz.")]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Lütfen formata uygun bir fiyat giriniz.")]
        public Decimal Price { get; set;  }
        
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public string? ImageUrl { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
