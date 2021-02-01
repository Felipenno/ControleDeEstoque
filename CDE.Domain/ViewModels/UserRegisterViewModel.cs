using System.ComponentModel.DataAnnotations;

namespace CDE.Domain.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required]
        [Range(6, 40)]
        public string UserName { get; set; }

        [EmailAddress]
        [Required]
        [Range(6, 40)]
        public string UserEmail { get; set; }

        [Required]
        [Range(6, 40)]
        public string UserPassword { get; set; }
    }
}
