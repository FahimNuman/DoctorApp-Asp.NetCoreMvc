using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorsApp.Models
{
    public class Doctor
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Name")]
        [MinLength(3, ErrorMessage = "The Name field must be at list 3 char long")]
        [MaxLength(20, ErrorMessage = "The Name field must be at list 20 char long")]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Email")]
        [MinLength(5, ErrorMessage = "The Email field must be at list 5 char long")]
        [MaxLength(20, ErrorMessage = "The Email field must be at list 20 char long")]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Mobile")]
        [MinLength(11, ErrorMessage = "The Mobile field must be at list 11 char long")]
        [MaxLength(11, ErrorMessage = "The Mobile field must be at list 11 char long")]
        public string Mobile { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Degree")]
        [MinLength(5, ErrorMessage = "The Degree field must be at list 5 char long")]
        [MaxLength(10, ErrorMessage = "The Degree field must be at list 20 char long")]
        public string Degree { get; set; }

        [Required]
        public decimal VisitFee { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        public string Password { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile? File { get; set; }
    }
}
