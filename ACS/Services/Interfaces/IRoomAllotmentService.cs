using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface IRoomAllotmentService
    {
        RoomAllotmentView GetById(int id);
        List<RoomAllotmentView> GetAll();
        //List<RoomAllotmentView> GetAllRoomAllotmentList();
        Task<bool> DeleteRoomAllotment(int id);
        Task<RoomAllotmentView> AddRoomAllotment(RoomAllotmentView roomAllotmentView);
        Task<RoomAllotmentView> UpdateRoomAllotment(RoomAllotmentView roomAllotmentView);
    }
}
