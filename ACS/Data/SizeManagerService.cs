using ACS.AppDBContext;
using ACS.Services.Interfaces;
using ACS.ViewModels;

namespace ACS.Data
{
    public class SizeManagerService
    {
        private readonly ISizeService _sizeService;


        public SizeManagerService(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }
        //get-all-sizes
        public List<SizeView> GetAllSizes()
        {
            var sizes = _sizeService.GetAll();
            return (sizes);
        }
        //add-size
        public async Task<SizeView> AddSize(SizeView sizeView)
        {
            sizeView.CreatedDateTime = DateTime.Now;
            sizeView.CreatedByUserID = 1;
            sizeView = await _sizeService.AddSize(sizeView);

            return sizeView;

        }

        //Update-Size

        public SizeView GetById(int id)
        {
            return _sizeService.GetById(id);
        }

        public async Task<SizeView> UpdateSize(SizeView sizeView)
        {
            sizeView.UpdatedDateTime = DateTime.Now;
            sizeView.UpdatedByUserID = 1;
            sizeView = await _sizeService.UpdateSize(sizeView);

            return sizeView;

        }

        //Delete-Size

        public async Task<bool> DeleteSize(int id)
        {
            return await _sizeService.DeleteSize(id);
        }
    }
}
