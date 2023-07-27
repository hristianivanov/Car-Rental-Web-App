namespace CarRentalSystem.Web.ViewModels.User
{
	using System.ComponentModel.DataAnnotations;

	public class UserInfoOnCarViewModel
	{
		public string Email { get; set; } = null!;
        [Display(Name = "Phone")] 
        public string PhoneNumber { get; set; } = null!;
	}
}
