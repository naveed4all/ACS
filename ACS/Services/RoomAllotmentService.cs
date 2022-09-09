using ACS.AppDBContext;
using ACS.Models;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ACS.Services
{
    public class RoomAllotmentService : IRoomAllotmentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public RoomAllotmentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoomAllotmentView> AddRoomAllotment(RoomAllotmentView roomAllotmentView)
        {
            try
            {
                var roomAllotment = _mapper.Map<RoomAllotment>(roomAllotmentView);
                
                _context.RoomAllotment.Add(roomAllotment);
                await _context.SaveChangesAsync();
                return _mapper.Map<RoomAllotmentView>(roomAllotment);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Room Allotment", e);
            }
        }

        public async Task<bool> DeleteRoomAllotment(int id)
        {
            var isDeleted = false;
            try
            {
                var roomAllotment = _context.RoomAllotment.FirstOrDefault(x => x.RoomAllotmentID == id);
                _context.RoomAllotment.Remove(roomAllotment);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Room Allotment", e);
            }
            return isDeleted;
        }

        public List<RoomAllotmentView> GetAll()
        {
            try
            {
                var roomAllotments = _context.RoomAllotment.AsNoTracking().Include(x => x.Party).AsNoTracking().ToList();
                return _mapper.Map<List<RoomAllotment>, List<RoomAllotmentView>>(roomAllotments);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Room Allotments", e);
            }
        }

        //public List<RoomAllotmentView> GetAllRoomAllotmentList()
        //{
        //    try
        //    {
        //        var roomAllotments = _context.RoomAllotment
        //        .Include(x => x.Party);

        //        return roomAllotments.Select(x => new RoomAllotmentView
        //        {
        //            PartyID = x.PartyID,
        //            PartyName = x.Party.PartyName,
        //            RoomNo = x.RoomNo,
        //            MonthlyRent = x.MonthlyRent,
        //            StartDate = x.StartDate,
        //        })
        //            .ToList();

        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Error Getting Room Allotments", e);
        //    }

        //}

        public RoomAllotmentView GetById(int id)
        {
            try
            {
                var roomAllotment = _context.RoomAllotment.Include(x => x.Party).AsNoTracking().FirstOrDefault(x => x.RoomAllotmentID == id);
                return _mapper.Map<RoomAllotmentView>(roomAllotment);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Room Allotment By Id", e);
            }
        }

        public async Task<RoomAllotmentView> UpdateRoomAllotment(RoomAllotmentView roomAllotmentView)
        {
            try
            {
                roomAllotmentView.Party=null;
                var roomAllotment = _mapper.Map<RoomAllotment>(roomAllotmentView);
                _context.ChangeTracker.Clear();
                _context.RoomAllotment.Update(roomAllotment);
                await _context.SaveChangesAsync();
                return _mapper.Map<RoomAllotmentView>(GetById(roomAllotment.RoomAllotmentID));
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Room Allotment", e);
            }
        }
    }
}
