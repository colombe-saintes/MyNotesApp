using System.ComponentModel.DataAnnotations;

namespace MyNotes.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "The email is required")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
