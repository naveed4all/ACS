using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.Models.User_Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool RequiredPasswordChange { get; set; }

        [ForeignKey("UserID")]
        public int? CreatedByUserID { get; set; }
        public User CreatedByUser { get; set; }
        
        public int RoleID { get; set; }
        public Role Role { get; set; }


        [InverseProperty("CreatedByUser")]
        public ICollection<Employee> EmployeesCreated { get; set; }
        [InverseProperty("UpdatedByUser")]
        public ICollection<Employee> EmployeesUpdated { get; set; }
        
        [InverseProperty("CreatedByUser")]
        public ICollection<AdvanceSalary> AdvanceSalariesCreated { get; set; }
        [InverseProperty("UpdatedByUser")]
        public ICollection<AdvanceSalary> AdvanceSalariesUpdated { get; set; }

        [InverseProperty("CreatedByUser")]
        public ICollection<EmployeeAttendence> EmployeeAttendenceCreated { get; set; }
        [InverseProperty("UpdatedByUser")]
        public ICollection<EmployeeAttendence> EmployeeAttendenceUpdated { get; set; }

        [InverseProperty("CreatedByUser")]
        public ICollection<Inventory> InventoriesCreated { get; set; }
        [InverseProperty("UpdatedByUser")]
        public ICollection<Inventory> InventoriesUpdated { get; set; }

        [InverseProperty("CreatedByUser")]
        public ICollection<Invoice> InvoicesCreated { get; set; }
        [InverseProperty("UpdatedByUser")]
        public ICollection<Invoice> InvoicesUpdated { get; set; }

        [InverseProperty("CreatedByUser")]
        public ICollection<Item> ItemsCreated { get; set; }
        [InverseProperty("UpdatedByUser")]
        public ICollection<Item> ItemsUpdated { get; set; }

        [InverseProperty("CreatedByUser")]
        public ICollection<Ledger> LedgersCreated { get; set; }
        [InverseProperty("UpdatedByUser")]
        public ICollection<Ledger> LedgersUpdated { get; set; }
        
        [InverseProperty("CreatedByUser")]
        public ICollection<Party> PartiesCreated { get; set; }
        [InverseProperty("UpdatedByUser")]
        public ICollection<Party> PartiesUpdated { get; set; }
        
        [InverseProperty("CreatedByUser")]
        public ICollection<PartyLedger> PartyLedgersCreated { get; set; }
        [InverseProperty("UpdatedByUser")]
        public ICollection<PartyLedger> PartyLedgersUpdated { get; set; }
        
        [InverseProperty("CreatedByUser")]
        public ICollection<RoomAllotment> RoomAllotmentsCreated { get; set; }
        [InverseProperty("UpdatedByUser")]
        public ICollection<RoomAllotment> RoomAllotmentsUpdated { get; set; }
        
        [InverseProperty("CreatedByUser")]
        public ICollection<ShipmentDetails> ShipmentDetailsCreated { get; set; }
        [InverseProperty("UpdatedByUser")]
        public ICollection<ShipmentDetails> ShipmentDetailsUpdated { get; set; }
        
        [InverseProperty("CreatedByUser")]
        public ICollection<Size> SizesCreated { get; set; }
        [InverseProperty("UpdatedByUser")]
        public ICollection<Size> SizesUpdated { get; set; }
        
        //[InverseProperty("CreatedByUser")]
        //public ICollection<StockOut> StockOutsCreated { get; set; }
        //[InverseProperty("UpdatedByUser")]
        //public ICollection<StockOut> StockOutsUpdated { get; set; }
               
        [InverseProperty("CreatedByUser")]
        public ICollection<Permission> PermissionsCreated { get; set; }
        [InverseProperty("UpdatedByUser")]
        public ICollection<Permission> PermissionsUpdated { get; set; }

        [InverseProperty("CreatedByUser")]
        public ICollection<RolePermission> RolePermissionsCreated { get; set; }
        [InverseProperty("UpdatedByUser")]
        public ICollection<RolePermission> RolePermissionsUpdated { get; set; }


    }
}
