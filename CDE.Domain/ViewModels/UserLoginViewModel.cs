using System.ComponentModel.DataAnnotations;

namespace CDE.Domain.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        public string UserPassword { get; set; }
    }
}
