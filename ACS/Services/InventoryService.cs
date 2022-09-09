using ACS.AppDBContext;
using ACS.Models;
using ACS.Models.User_Model;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using ACS.ViewModels.UserModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ACS.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public InventoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InventoryView> AddInventory(InventoryView inventoryView)
        {
            try
            {
                if (_context.Inventory.FirstOrDefault(x => x.GRNo == inventoryView.GRNo) != null)
                {
                    throw new Exception($"Inventory With GRNo : {inventoryView.GRNo} already exists.");
                }

                var inventory = _mapper.Map<Inventory>(inventoryView);

                _context.Inventory.Add(inventory);
                var settingGRNo = _context.Settings.FirstOrDefault(x => x.Key == "GRNo");
                if (settingGRNo != null)
                {
                    settingGRNo.Value = inventory.GRNo.ToString();
                    _context.Settings.Update(settingGRNo);
                }
                await _context.SaveChangesAsync();
                return _mapper.Map<InventoryView>(inventory);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Inventory", e);
            }
        }

        public async Task<List<InventoryView>> UpdateInventoryList(List<InventoryView> inventoryViewlist)
        {
            try
            {
                var invenList = _mapper.Map<List<InventoryView>, List<Inventory>>(inventoryViewlist);
                _context.Inventory.UpdateRange(invenList);
                await _context.SaveChangesAsync();
                return _mapper.Map<List<Inventory>, List<InventoryView>>(invenList);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Inventory List", e);
            }
        }

        public async Task<bool> DeleteInventory(int id)
        {
            var isDeleted = false;
            try
            {
                var inventory = _context.Inventory.FirstOrDefault(x => x.InventoryID == id);
                if (inventory == null)
                {
                    return true;
                }
                inventory.IsActive = false;
                var notes = _context.InventoryNote.Where(x => x.InventoryID == id).ToList();
                _context.InventoryNote.RemoveRange(notes);
                _context.Inventory.Update(inventory);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Inventory", e);
            }
            return isDeleted;
        }

        public List<InventoryView> GetAll()
        {
            try
            {
                var inventories = _context.Inventory.Where(x => x.IsActive == true).Include(x => x.Item).ToList();
                return _mapper.Map<List<Inventory>, List<InventoryView>>(inventories);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Inventories", e);
            }
        }

        public InventoryView GetById(int id)
        {
            try
            {
                var inventory = _context.Inventory.FirstOrDefault(x => x.InventoryID == id);
                return _mapper.Map<InventoryView>(inventory);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Inventory", e);
            }
        }
        public InventoryView GetByGRNo(int gR)
        {
            try
            {
                var inventory = _context.Inventory.AsNoTracking().Where(x => x.GRNo == gR).Include(x => x.Party).AsNoTracking().Include(x => x.Item).AsNoTracking().FirstOrDefault();
                return _mapper.Map<InventoryView>(inventory);
            }
            catch (Exception e)
            {
                throw new Exception($"Error Getting Inventory With GRNo : {gR} ", e);
            }
        }



        public async Task<InventoryView> UpdateInventory(InventoryView inventoryView)
        {
            try
            {
                var inventory = _mapper.Map<Inventory>(inventoryView);
                _context.Entry(inventory).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                var item = _context.Inventory.Include(x => x.Item).Include(x => x.Party).AsNoTracking().FirstOrDefault(x => x.InventoryID == inventoryView.InventoryID);
                return _mapper.Map<InventoryView>(item);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Inventory", e);
            }
        }

        public int GetGRNo()
        {
            try
            {
                var grNo = Convert.ToInt32(_context.Settings.FirstOrDefault(x => x.Key == "GRNo").Value) + 1;
                return grNo;
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting GRNo", e);
            }

        }

    }
}
