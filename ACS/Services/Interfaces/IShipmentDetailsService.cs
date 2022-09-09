using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface IShipmentDetailsService
    {
        ShipmentDetailsView GetById(int id);
        List<ShipmentDetailsView> GetAll();
        Task<bool> DeleteShipmentDetails(int id);
        Task<ShipmentDetailsView> AddShipmentDetails(ShipmentDetailsView shipmentDetailsView);
        Task<ShipmentDetailsView> UpdateShipmentDetails(ShipmentDetailsView shipmentDetailsView);
    }
}
