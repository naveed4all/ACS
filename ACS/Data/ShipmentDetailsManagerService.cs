using ACS.Services.Interfaces;
using ACS.ViewModels;



namespace ACS.Data
{
    public class ShipmentDetailsManagerService
    {
        private readonly IShipmentDetailsService _shipmentDetailsService;
        private readonly IPartyService _partyService;
        public ShipmentDetailsManagerService(IShipmentDetailsService shipmentDetailsService, IPartyService partyService)
        {
            _shipmentDetailsService = shipmentDetailsService;
            _partyService = partyService;
        }
      

        //Get-All-Shipment-Details
        public List<ShipmentDetailsView> GetAllShipmentDetails()
        {
            var shipmentDetailsView = _shipmentDetailsService.GetAll();
            return shipmentDetailsView;
        }

        //Get-All-Parties
        public List<PartyView> GetAllParties()
        {
            var partyView = _partyService.GetAll();
            return partyView;
        }





        //Add-Shipment-Detail
        public async Task<ShipmentDetailsView> AddShipmentDetail(ShipmentDetailsView shipmentDetailsView)
        {
            shipmentDetailsView.CreatedDateTime = DateTime.UtcNow;
            shipmentDetailsView.CreatedByUserID = 1;
            shipmentDetailsView = await _shipmentDetailsService.AddShipmentDetails(shipmentDetailsView);
            return shipmentDetailsView;
        }



        //Get-Shipment-Detail-By-ID
        public ShipmentDetailsView GetById(int id)
        {
            return _shipmentDetailsService.GetById(id);
        }
        //Get-Party-By-ID
        public PartyView GetPartyById(int id)
        {
            return _partyService.GetById(id);
        }

        //Update-Shipment-Detail



        public async Task<ShipmentDetailsView> UpdateShipmentDetail(ShipmentDetailsView shipmentDetailsView)
        {
            shipmentDetailsView.UpdatedDateTime = DateTime.Now;
            shipmentDetailsView.UpdatedByUserID = 1;
            shipmentDetailsView = await _shipmentDetailsService.UpdateShipmentDetails(shipmentDetailsView);

            return shipmentDetailsView;

        }

        //Delete-Shipment-Detail

        public async Task<bool> DeleteShipmentDetail(int id)
        {
            return await _shipmentDetailsService.DeleteShipmentDetails(id);
        }



    }
}
