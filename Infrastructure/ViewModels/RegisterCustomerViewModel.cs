using System.ComponentModel.DataAnnotations;

namespace BankerApp.Infrastructure.ViewModels
{
    public class RegisterCustomerViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter your first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter your last name")]
        public string LastName { get; set; }

        [Display(Name = "Home Address")]
        [Required(ErrorMessage = "Your address is needed for identification")]
        [StringLength(200, ErrorMessage = "The length of your address cannot be less than {2}", MinimumLength = 8)]
        public string Address { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Your email address is required for validation")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter a valid password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        [Required(ErrorMessage = "Please re-enter a your password to confirm")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter a valid phone number")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}