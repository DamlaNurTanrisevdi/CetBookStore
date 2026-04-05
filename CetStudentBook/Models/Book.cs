using System.ComponentModel.DataAnnotations;

namespace CetStudentBook.Models
{
    public class Book
    {
        public int Id { get; set; } // Primary Key

        [Required(ErrorMessage = "Kitap adı zorunludur.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Kitap adı 2-200 karakter arasında olmalıdır.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yazar adı zorunludur.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Yazar adı 2-200 karakter arasında olmalıdır.")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yayın tarihi zorunludur.")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Required(ErrorMessage = "Sayfa sayısı zorunludur.")]
        [Range(1, 10000, ErrorMessage = "Sayfa sayısı 1 ile 10.000 arasında olmalıdır.")]
        public int PageCount { get; set; }

        [Required]
        public bool IsSecondHand { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Geçerli bir fiyat giriniz.")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
