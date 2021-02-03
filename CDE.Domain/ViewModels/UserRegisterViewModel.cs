using System.ComponentModel.DataAnnotations;

namespace CDE.Domain.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [EmailAddress]
        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string UserPassword { get; set; }
    }
}
