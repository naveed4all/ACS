using ACS.Models.User_Model;
using ACS.Models;
using ACS.ViewModels;
using ACS.ViewModels.UserModel;
using AutoMapper;

namespace ACS.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {            
            CreateMap<RoleView, Role>().ReverseMap();
            CreateMap<UserView, User>().ReverseMap();
            CreateMap<SizeView, Size>().ReverseMap();
            CreateMap<ItemView, Item>().ReverseMap();
            CreateMap<PartyView, Party>().ReverseMap();
            CreateMap<InventoryView, Inventory>().ReverseMap();
            CreateMap<NoteView, Note>().ReverseMap();
            CreateMap<InventoryNoteView, InventoryNote>().ReverseMap();
            CreateMap<InvoiceView, Invoice>().ReverseMap();
            CreateMap<LedgerView, Ledger>().ReverseMap();
            CreateMap<PartyLedgerView, PartyLedger>().ReverseMap();
            CreateMap<RoomAllotmentView, RoomAllotment>().ReverseMap();
            CreateMap<ShipmentDetailsView, ShipmentDetails>().ReverseMap();
            CreateMap<StockOutView, StockOut>().ReverseMap();
            CreateMap<EmployeeView, Employee>().ReverseMap();
            CreateMap<EmployeeAttendenceView, EmployeeAttendence>().ReverseMap();
            CreateMap<AdvanceSalaryView, AdvanceSalary>().ReverseMap();
            CreateMap<PermissionView, Permission>().ReverseMap();
            CreateMap<RolePermissionView, RolePermission>().ReverseMap();
            CreateMap<StockOutBillView, StockOutBill>().ReverseMap();
            CreateMap<CategoryView, Category>().ReverseMap();
            CreateMap<TransactionView, Transaction>().ReverseMap();

            
            
        }
    }
}
