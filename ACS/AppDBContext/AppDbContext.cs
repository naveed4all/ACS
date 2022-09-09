using ACS.Helpers;
using ACS.Models;
using ACS.Models.User_Model;
using Microsoft.EntityFrameworkCore;

namespace ACS.AppDBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<StockOut> StockOut { get; set; }
        //public DbSet<StockOutBill> StockOutBill { get; set; }
        public DbSet<Ledger> Ledger { get; set; }
        public DbSet<PartyLedger> PartyLedger { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Party> Party { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeAttendence> EmployeeAttendence { get; set; }
        public DbSet<AdvanceSalary> AdvanceSalary { get; set; }
        public DbSet<RoomAllotment> RoomAllotment { get; set; }
        public DbSet<ShipmentDetails> ShipmentDetails { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<InventoryNote> InventoryNote { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<InventoryPartyLog> InventoryPartyLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Settings>().HasData(
              new Settings
              {
                  SettingID = 1,
                  Key = "GRNo",
                  Value = "1",
              }
          );

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleID = 1,
                    Title = "Admin",
                    IsActive = true,
                }
            ); 
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    FirstName = "Super",
                    LastName = "Admin",
                    RoleID = 1,
                    Email = "admin@gmail.com",
                    Password = "123".HashWithSalt(),
                    IsActive = true,

                }
            ); 
            modelBuilder.Entity<Size>().HasData(
                new Size
                {
                    SizeID = 1,
                    Name = "Medium",
                    CreatedByUserID = 1,
                    CreatedDateTime = DateTime.UtcNow.AddHours(5),
                    IsActive = true,

                }
            );
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    ItemID = 1,
                    ItemName = "Cold Drinks",
                    CreatedByUserID = 1,
                    CreatedDateTime = DateTime.UtcNow.AddHours(5),
                    IsActive = true,
                } ,
                new Item
                {
                    ItemID = 2,
                    ItemName = "ice cream",
                    CreatedByUserID = 1,
                    CreatedDateTime = DateTime.UtcNow.AddHours(5),
                    IsActive = true,
                }
            );
            modelBuilder.Entity<Party>().HasData(
                new Party
                {
                    PartyID = 1,
                    PartyName = "Ashfaq",
                    CreatedByUserID = 1,
                    CreatedDateTime = DateTime.UtcNow.AddHours(5),
                    Address = "baju me",
                    Contact = "sdasd",
                    IsActive = true,

                } ,
                new Party
                {
                    PartyID = 2,
                    PartyName = "ismail",
                    CreatedByUserID = 1,
                    CreatedDateTime = DateTime.UtcNow.AddHours(5),
                    Contact = "sdasd",
                    Address = "baju me",
                    IsActive = true,
                }
            );
            modelBuilder.Entity<PartyLedger>().HasData(
                new PartyLedger
                {
                    PartyLedgerID = 1,
                    PartyID = 1,           
                    TodayCredit = 50000,
                    TodayDebit = 10000,
                    CreatedByUserID = 1,
                    CreatedDateTime = DateTime.UtcNow.AddHours(5),                    
                    IsActive = true,

                } ,
                new PartyLedger
                {
                    PartyLedgerID = 2,
                    PartyID = 2,
                    CreatedByUserID = 1,
                    CreatedDateTime = DateTime.UtcNow.AddHours(5),
                    IsActive = true,
                }
            );
        }

    }
}
