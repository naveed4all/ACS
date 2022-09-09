using ACS.AppDBContext;
using ACS.Models;
using ACS.Models.User_Model;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using ACS.ViewModels.UserModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ACS.Services
{
    public class SizeService : ISizeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SizeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<SizeView> AddSize(SizeView sizeView)
        {
            try
            {
                var size = _mapper.Map<Size>(sizeView);
                size.IsActive = true;
                _context.Size.Add(size);
                await _context.SaveChangesAsync();
                return _mapper.Map<SizeView>(size);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Size", e);
            }
        }

        public async Task<bool> DeleteSize(int id)
        {
            var isDeleted = false;
            try
            {
                var size = _context.Size.FirstOrDefault(x => x.SizeID == id);
                if(size == null)
                {
                    return true;
                }
                //_context.Size.Remove(size);
                if (size.IsActive)
                {
                    size.IsActive = false;
                    _context.Size.Update(size);
                    await _context.SaveChangesAsync();
                }
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Size", e);
            }
            return isDeleted;
        }

        public List<SizeView> GetAll()
        {
            try
            {
                var sizes = _context.Size.Where(x=>x.IsActive==true).AsNoTracking().ToList();
                return _mapper.Map<List<Size>, List<SizeView>>(sizes);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Size", e);
            }
        }

        public SizeView GetById(int id)
        {
            try
            {
                var size = _context.Size.AsNoTracking().FirstOrDefault(x=> x.SizeID == id);
                return _mapper.Map<SizeView>(size);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Size", e);
            }
        }

        public async Task<SizeView> UpdateSize(SizeView sizeView)
        {
            try
            {
                var size = _mapper.Map<Size>(sizeView);
                _context.ChangeTracker.Clear();
                _context.Size.Update(size);
                await _context.SaveChangesAsync();
                return _mapper.Map<SizeView>(GetById(size.SizeID));
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Size", e);
            }
        }
    }
}
