namespace CarRentalSystem.Services.Data.Interfaces
{
    using Web.ViewModels.Make;

    public interface IMakeService
    {
        Task<int> GetMakeIdOrCreateMakeAsync(string make);
        Task<bool> MakeExistsByNameAsync(string make);
        Task CreateMakeAsync(string make);
        public Task<MakeViewModel?> GetMakeByNameAsync(string name);
    }
}
