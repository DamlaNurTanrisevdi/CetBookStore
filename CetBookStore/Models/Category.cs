using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CetBookStore.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength =2)]
        public string Name { get; set; }  //nvarchar(100) not null        
        public bool IsVisibleInMenu { get; set; }

        public virtual List<Book>? Books { get; set; }

    }
}
