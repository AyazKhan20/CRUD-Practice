using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical.Models
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }
        [Required]
        [MaxLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Customer Name")]
        public string Customer_Name { get; set; }
        [Required]
        [MaxLength(300)]
        [Column(TypeName = "nvarchar(300)")]
        public string Address { get; set; }
        [Required]
        [MaxLength(6)]
        [Column(TypeName = "nvarchar(6)")]
        public string Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar(250)")]
        public string Hobbies { get; set; } 

    }
}
