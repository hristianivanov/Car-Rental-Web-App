namespace CarRentalSystem.Web.ViewModels.Blog
{
	using System.Collections.Generic;

	public class AllBlogViewModel
	{
        public AllBlogViewModel()
        {
	        this.Blogs = new HashSet<BlogViewModel>();
        }

        public IEnumerable<BlogViewModel> Blogs { get; set; }
	}
}
