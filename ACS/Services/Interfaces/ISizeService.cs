using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface ISizeService
    {
        SizeView GetById(int id);
        List<SizeView> GetAll();
        Task<bool> DeleteSize(int id);
        Task<SizeView> AddSize(SizeView SizeView);
        Task<SizeView> UpdateSize(SizeView SizeView);
    }
}
