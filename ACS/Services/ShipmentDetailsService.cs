using ACS.AppDBContext;
using ACS.Models;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ACS.Services
{
    public class ShipmentDetailsService : IShipmentDetailsService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ShipmentDetailsService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShipmentDetailsView> AddShipmentDetails(ShipmentDetailsView shipmentDetailsView)
        {
            try
            {
                var shipmentDetail = _mapper.Map<ShipmentDetails>(shipmentDetailsView);
                shipmentDetail.IsActive = true;

                _context.ShipmentDetails.Add(shipmentDetail);
                await _context.SaveChangesAsync();
                return _mapper.Map<ShipmentDetailsView>(GetById(shipmentDetail.ShipmentDetailsID));
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Shipment Detail", e);
            }
        }

        public async Task<bool> DeleteShipmentDetails(int id)
        {
            var isDeleted = false;
            try
            {
                var shipmentDetail = _context.ShipmentDetails.FirstOrDefault(x => x.ShipmentDetailsID == id);
                //_context.ShipmentDetails.Remove(shipmentDetail);
                if (shipmentDetail.IsActive)
                {
                    shipmentDetail.IsActive = false;
                    _context.ShipmentDetails.Update(shipmentDetail);
                    await _context.SaveChangesAsync();
                }

                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Shipment Detail", e);
            }
            return isDeleted;
        }

        public List<ShipmentDetailsView> GetAll()
        {
            try
            {
                var shipmentDetails = _context.ShipmentDetails.Where(x => x.IsActive == true).AsNoTracking().Include(x => x.Party).AsNoTracking().ToList();
                return _mapper.Map<List<ShipmentDetails>, List<ShipmentDetailsView>>(shipmentDetails);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Shipment Details", e);
            }
        }

        public ShipmentDetailsView GetById(int id)
        {
            try
            {
                var shipmentDetail = _context.ShipmentDetails.Include(x => x.Party).AsNoTracking().FirstOrDefault(x => x.ShipmentDetailsID == id);
                return _mapper.Map<ShipmentDetailsView>(shipmentDetail);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Shipment Detail By Id", e);
            }
        }




        public async Task<ShipmentDetailsView> UpdateShipmentDetails(ShipmentDetailsView shipmentDetailsView)
        {
            try
            {
                shipmentDetailsView.Party = null;
                var shipmentDetail = _mapper.Map<ShipmentDetails>(shipmentDetailsView);
                _context.ChangeTracker.Clear();
                _context.ShipmentDetails.Update(shipmentDetail);
                await _context.SaveChangesAsync();
                return _mapper.Map<ShipmentDetailsView>(GetById(shipmentDetail.ShipmentDetailsID));
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Shipment Detail", e);
            }
        }
    }
}
