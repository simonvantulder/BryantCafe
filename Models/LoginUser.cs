using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BryantCornerCafe.Models
{
    [NotMapped] //dont add table to database
    public class LoginUser
    {
        [Required(ErrorMessage = "is Required.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string LoginEmail { get; set; }

        [Required(ErrorMessage = "is Required.")]
        [MinLength(8, ErrorMessage = "must be at least 8 characters")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]

        public string LoginPassword { get; set; }

        
    }
}
