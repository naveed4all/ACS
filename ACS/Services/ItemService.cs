using ACS.AppDBContext;
using ACS.Models;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ACS.Services
{
    public class ItemService : IItemService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ItemService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ItemView> AddItem(ItemView itemView)
        {
            try
            {
                var item = _mapper.Map<Item>(itemView);
                item.IsActive = true;
                _context.Item.Add(item);
                await _context.SaveChangesAsync();
                return _mapper.Map<ItemView>(item);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Item", e);
            }
        }

        public async Task<bool> DeleteItem(int id)
        {
            var isDeleted = false;
            try
            {
                var item = _context.Item.FirstOrDefault(x => x.ItemID == id);
                //_context.Item.Remove(item);
                if (item.IsActive)
                {
                    item.IsActive = false;
                    _context.Item.Update(item);
                    await _context.SaveChangesAsync();
                }
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Item", e);
            }
            return isDeleted;
        }

        public List<ItemView> GetAll()
        {
            try
            {
                var items = _context.Item.Where(x=>x.IsActive==true).AsNoTracking().ToList();
                return _mapper.Map<List<Item>, List<ItemView>>(items);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Items", e);
            }
        }

        public ItemView GetById(int id)
        {
            try
            {
                var item = _context.Item.AsNoTracking().FirstOrDefault(x => x.ItemID == id);
                return _mapper.Map<ItemView>(item);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Item By Id", e);
            }
        }

        public async Task<ItemView> UpdateItem(ItemView itemView)
        {
            try
            {
                var item = _mapper.Map<Item>(itemView);
                _context.ChangeTracker.Clear();
                _context.Item.Update(item);
                await _context.SaveChangesAsync();
                return _mapper.Map<ItemView>(GetById(item.ItemID));
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Item", e);
            }
        }
    }
}
