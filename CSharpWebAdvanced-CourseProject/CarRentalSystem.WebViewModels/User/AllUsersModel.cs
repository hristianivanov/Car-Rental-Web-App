namespace CarRentalSystem.Web.ViewModels.User
{
	public class AllUsersModel
	{
		public AllUsersModel()
		{
			this.Users = new HashSet<UserViewModel>();
		}
		public string? SearchString { get; set; }
		public IEnumerable<UserViewModel> Users { get; set; }
	}
}
