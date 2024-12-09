using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }

		[Required(ErrorMessage = "Last Name is Required")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Email is Required")]
		[EmailAddress]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is Required")]
		[DataType(DataType.Password)]	
		public string Password { get; set; }

		[Required(ErrorMessage = "Password is Required")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage ="Password Does not Match")]
		public string ConfirmPassword { get; set; }
        public bool  IsAgree { get; set; }
    }
}
