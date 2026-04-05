using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CetStudentBook.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; } //Integer , Primary Key, Auto-increment
        [Length(3,200)]
        [DisplayName("Full Name")]
         public string Name { get; set; }  //nvarchar(max), Not Null

        [DataType(DataType.EmailAddress)]
        [Length(5,200)]
        public string Email { get; set; } //nvarchar(200), Not Null
        
        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } //datetime2, Not Null

    }
}
