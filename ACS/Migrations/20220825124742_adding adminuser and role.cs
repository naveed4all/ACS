using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACS.Migrations
{
    public partial class addingadminuserandrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RequiredPasswordChange = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_User_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    IsPermenant = table.Column<bool>(type: "bit", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Employee_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Item_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Item_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NoteID);
                    table.ForeignKey(
                        name: "FK_Note_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Note_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Party",
                columns: table => new
                {
                    PartyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Party", x => x.PartyID);
                    table.ForeignKey(
                        name: "FK_Party_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Party_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeID);
                    table.ForeignKey(
                        name: "FK_Size_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Size_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "AdvanceSalary",
                columns: table => new
                {
                    AdvanceSalaryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdvSalary = table.Column<double>(type: "float", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvanceSalary", x => x.AdvanceSalaryID);
                    table.ForeignKey(
                        name: "FK_AdvanceSalary_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdvanceSalary_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdvanceSalary_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttendence",
                columns: table => new
                {
                    EmployeeAttendenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPresent = table.Column<bool>(type: "bit", nullable: true),
                    IsLeave = table.Column<bool>(type: "bit", nullable: true),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttendence", x => x.EmployeeAttendenceID);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendence_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendence_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendence_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "PartyLedger",
                columns: table => new
                {
                    PartyLedgerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartyID = table.Column<int>(type: "int", nullable: false),
                    ClosingBalance = table.Column<double>(type: "float", nullable: false),
                    TodayDebit = table.Column<double>(type: "float", nullable: false),
                    TodayCredit = table.Column<double>(type: "float", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyLedger", x => x.PartyLedgerID);
                    table.ForeignKey(
                        name: "FK_PartyLedger_Party_PartyID",
                        column: x => x.PartyID,
                        principalTable: "Party",
                        principalColumn: "PartyID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PartyLedger_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PartyLedger_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "RoomAllotment",
                columns: table => new
                {
                    RoomAllotmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartyID = table.Column<int>(type: "int", nullable: false),
                    RoomNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyRent = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAllotment", x => x.RoomAllotmentID);
                    table.ForeignKey(
                        name: "FK_RoomAllotment_Party_PartyID",
                        column: x => x.PartyID,
                        principalTable: "Party",
                        principalColumn: "PartyID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RoomAllotment_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RoomAllotment_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "ShipmentDetails",
                columns: table => new
                {
                    ShipmentDetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shipline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    AmountReceived = table.Column<double>(type: "float", nullable: false),
                    PartyID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentDetails", x => x.ShipmentDetailsID);
                    table.ForeignKey(
                        name: "FK_ShipmentDetails_Party_PartyID",
                        column: x => x.PartyID,
                        principalTable: "Party",
                        principalColumn: "PartyID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ShipmentDetails_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ShipmentDetails_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartyID = table.Column<int>(type: "int", nullable: false),
                    SizeID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GRNo = table.Column<int>(type: "int", nullable: false),
                    MarkOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticleNo = table.Column<int>(type: "int", nullable: false),
                    RoomNo = table.Column<int>(type: "int", nullable: false),
                    RackNo = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    MonthlyRent = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    DiscountDays = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_Inventory_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Inventory_Party_PartyID",
                        column: x => x.PartyID,
                        principalTable: "Party",
                        principalColumn: "PartyID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Inventory_Size_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Size",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Inventory_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Inventory_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "InventoryNote",
                columns: table => new
                {
                    InventoryNoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryID = table.Column<int>(type: "int", nullable: false),
                    NoteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryNote", x => x.InventoryNoteID);
                    table.ForeignKey(
                        name: "FK_InventoryNote_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InventoryNote_Note_NoteID",
                        column: x => x.NoteID,
                        principalTable: "Note",
                        principalColumn: "NoteID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartyID = table.Column<int>(type: "int", nullable: false),
                    InventoryID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountPaid = table.Column<double>(type: "float", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoice_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Invoice_Party_PartyID",
                        column: x => x.PartyID,
                        principalTable: "Party",
                        principalColumn: "PartyID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Invoice_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Invoice_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "StockOut",
                columns: table => new
                {
                    StockOutID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivedByPartyID = table.Column<int>(type: "int", nullable: false),
                    InventoryID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockOut", x => x.StockOutID);
                    table.ForeignKey(
                        name: "FK_StockOut_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StockOut_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StockOut_Party_ReceivedByPartyID",
                        column: x => x.ReceivedByPartyID,
                        principalTable: "Party",
                        principalColumn: "PartyID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StockOut_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StockOut_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Ledger",
                columns: table => new
                {
                    LedgerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledger", x => x.LedgerID);
                    table.ForeignKey(
                        name: "FK_Ledger_Invoice_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ledger_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ledger_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "IsActive", "Title" },
                values: new object[] { 1, true, "Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "CreatedByUserID", "Email", "FirstName", "IsActive", "LastName", "Password", "RequiredPasswordChange", "RoleID" },
                values: new object[] { 1, null, "admin@gmail.com", "Super", true, "Admin", "s8scmb168Cftrf3LG8cFMjQRHk8LXGSAC9iYfOIBymK3f1Jx/wY6Tpt7jccy2MWd17vta8mAcP74Eg+BFzOQew==", false, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceSalary_CreatedByUserID",
                table: "AdvanceSalary",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceSalary_EmployeeID",
                table: "AdvanceSalary",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceSalary_UpdatedByUserID",
                table: "AdvanceSalary",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CreatedByUserID",
                table: "Employee",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UpdatedByUserID",
                table: "Employee",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendence_CreatedByUserID",
                table: "EmployeeAttendence",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendence_EmployeeID",
                table: "EmployeeAttendence",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendence_UpdatedByUserID",
                table: "EmployeeAttendence",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_CreatedByUserID",
                table: "Inventory",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ItemID",
                table: "Inventory",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_PartyID",
                table: "Inventory",
                column: "PartyID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_SizeID",
                table: "Inventory",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_UpdatedByUserID",
                table: "Inventory",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryNote_InventoryID",
                table: "InventoryNote",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryNote_NoteID",
                table: "InventoryNote",
                column: "NoteID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CreatedByUserID",
                table: "Invoice",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InventoryID",
                table: "Invoice",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_PartyID",
                table: "Invoice",
                column: "PartyID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_UpdatedByUserID",
                table: "Invoice",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CreatedByUserID",
                table: "Item",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_UpdatedByUserID",
                table: "Item",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_CreatedByUserID",
                table: "Ledger",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_InvoiceID",
                table: "Ledger",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_UpdatedByUserID",
                table: "Ledger",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_CreatedByUserID",
                table: "Note",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_UpdatedByUserID",
                table: "Note",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Party_CreatedByUserID",
                table: "Party",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Party_UpdatedByUserID",
                table: "Party",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PartyLedger_CreatedByUserID",
                table: "PartyLedger",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PartyLedger_PartyID",
                table: "PartyLedger",
                column: "PartyID");

            migrationBuilder.CreateIndex(
                name: "IX_PartyLedger_UpdatedByUserID",
                table: "PartyLedger",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllotment_CreatedByUserID",
                table: "RoomAllotment",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllotment_PartyID",
                table: "RoomAllotment",
                column: "PartyID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllotment_UpdatedByUserID",
                table: "RoomAllotment",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentDetails_CreatedByUserID",
                table: "ShipmentDetails",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentDetails_PartyID",
                table: "ShipmentDetails",
                column: "PartyID");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentDetails_UpdatedByUserID",
                table: "ShipmentDetails",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Size_CreatedByUserID",
                table: "Size",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Size_UpdatedByUserID",
                table: "Size",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_StockOut_CreatedByUserID",
                table: "StockOut",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_StockOut_InventoryID",
                table: "StockOut",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_StockOut_ItemID",
                table: "StockOut",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_StockOut_ReceivedByPartyID",
                table: "StockOut",
                column: "ReceivedByPartyID");

            migrationBuilder.CreateIndex(
                name: "IX_StockOut_UpdatedByUserID",
                table: "StockOut",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedByUserID",
                table: "User",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleID",
                table: "User",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvanceSalary");

            migrationBuilder.DropTable(
                name: "EmployeeAttendence");

            migrationBuilder.DropTable(
                name: "InventoryNote");

            migrationBuilder.DropTable(
                name: "Ledger");

            migrationBuilder.DropTable(
                name: "PartyLedger");

            migrationBuilder.DropTable(
                name: "RoomAllotment");

            migrationBuilder.DropTable(
                name: "ShipmentDetails");

            migrationBuilder.DropTable(
                name: "StockOut");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Party");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
