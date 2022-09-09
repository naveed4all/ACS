using ACS.AppDBContext;
using ACS.Services;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ACS.Data
{
    public class RoomAllotmentManagerService
    {
        private readonly IRoomAllotmentService _roomAllotmentService;
        private readonly IPartyService _partyService;
      
        public RoomAllotmentManagerService(IRoomAllotmentService roomAllotmentService, IPartyService partyService)
        {
            _roomAllotmentService = roomAllotmentService;
            _partyService = partyService;
            
        }
        //Get-All-Room-Allotments
        public List<RoomAllotmentView> GetAllRoomAllotments()
        {
            var roomAllotments = _roomAllotmentService.GetAll();
            return roomAllotments.OrderByDescending(x=>x.RoomAllotmentID).ToList();
        }

        //Get-Room-Allotment-By-ID
        public RoomAllotmentView GetById(int id)
        {
            return _roomAllotmentService.GetById(id);
        }
        //Add-Room-Allotment
        public async Task<RoomAllotmentView> AddRoomAllotment(RoomAllotmentView roomAllotmentView)
        {
            
            roomAllotmentView.CreatedDateTime = DateTime.UtcNow.AddHours(5);
            roomAllotmentView.CreatedByUserID = 1;
            roomAllotmentView = await _roomAllotmentService.AddRoomAllotment(roomAllotmentView);
            return roomAllotmentView;
        }
        //Get-All-Parties

        public List<PartyView> GetAllParties()
        {
            var parties = _partyService.GetAll();
            return parties;
        }

        //Get-Party-By-ID

        public PartyView GetPartyById(int id)
        {
            return _partyService.GetById(id);
        }

        //Update-Room-Allotment
        public async Task<RoomAllotmentView> UpdateRoomAllotment(RoomAllotmentView roomAllotmentView)
        {
            roomAllotmentView.UpdatedDateTime = DateTime.UtcNow.AddHours(5);
            roomAllotmentView.UpdatedByUserID = 1;
            roomAllotmentView = await _roomAllotmentService.UpdateRoomAllotment(roomAllotmentView);

            return roomAllotmentView;

        }

        //Delete-Room-Allotment

        public async Task<bool> DeleteRoomAllotment(int id)
        {
            return await _roomAllotmentService.DeleteRoomAllotment(id);
        }





        //Get-All-Room-Allotments-with-PartyName
        //public List<RoomAllotmentView> GetRoomAllotmentList()
        //{
        //    var roomAllotments = _roomAllotmentService.GetAllRoomAllotmentList();
        //    return roomAllotments;
        //}



    }
}
