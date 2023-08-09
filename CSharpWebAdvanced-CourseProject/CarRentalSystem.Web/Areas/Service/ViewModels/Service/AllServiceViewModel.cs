namespace CarRentalSystem.Web.Areas.Service.ViewModels.Service;

public class AllServiceViewModel
{
    public AllServiceViewModel()
    {
        this.Services = new HashSet<ServiceViewModel>();
    }

    public IEnumerable<ServiceViewModel> Services { get; set; }
}