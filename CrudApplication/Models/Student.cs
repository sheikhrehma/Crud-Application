using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApplication.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Your Name")]
        [Column(TypeName ="varchar(50)")]

        public string Name { get; set; } /*nvarchar*/
        [Required(ErrorMessage = "Please Enter Your Email")]
        [Column(TypeName = "varchar(50)")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Phone")]
        [Column(TypeName = "varchar(50)")]


        public string Phone { get; set; }


    }
}
