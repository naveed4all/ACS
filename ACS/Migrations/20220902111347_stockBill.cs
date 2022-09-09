using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACS.Migrations
{
    public partial class stockBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvanceSalary_Employee_EmployeeID",
                table: "AdvanceSalary");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvanceSalary_User_CreatedByUserID",
                table: "AdvanceSalary");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_User_CreatedByUserID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAttendence_Employee_EmployeeID",
                table: "EmployeeAttendence");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAttendence_User_CreatedByUserID",
                table: "EmployeeAttendence");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Item_ItemID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Party_PartyID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Size_SizeID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_User_CreatedByUserID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryNote_Inventory_InventoryID",
                table: "InventoryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryNote_Note_NoteID",
                table: "InventoryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Inventory_InventoryID",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Party_PartyID",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_User_CreatedByUserID",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_CreatedByUserID",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Ledger_Invoice_InvoiceID",
                table: "Ledger");

            migrationBuilder.DropForeignKey(
                name: "FK_Ledger_User_CreatedByUserID",
                table: "Ledger");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_User_CreatedByUserID",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Party_User_CreatedByUserID",
                table: "Party");

            migrationBuilder.DropForeignKey(
                name: "FK_PartyLedger_Party_PartyID",
                table: "PartyLedger");

            migrationBuilder.DropForeignKey(
                name: "FK_PartyLedger_User_CreatedByUserID",
                table: "PartyLedger");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_User_CreatedByUserID",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Permission_PermissionId",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Role_RoleId",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_User_CreatedByUserID",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllotment_Party_PartyID",
                table: "RoomAllotment");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllotment_User_CreatedByUserID",
                table: "RoomAllotment");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentDetails_Party_PartyID",
                table: "ShipmentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentDetails_User_CreatedByUserID",
                table: "ShipmentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Size_User_CreatedByUserID",
                table: "Size");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOut_Inventory_InventoryID",
                table: "StockOut");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOut_Item_ItemID",
                table: "StockOut");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOut_Party_ReceivedByPartyID",
                table: "StockOut");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOut_User_CreatedByUserID",
                table: "StockOut");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "StockOut");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "StockOut",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "ReceivedByPartyID",
                table: "StockOut",
                newName: "StockOutBillID");

            migrationBuilder.RenameIndex(
                name: "IX_StockOut_ReceivedByPartyID",
                table: "StockOut",
                newName: "IX_StockOut_StockOutBillID");

            migrationBuilder.AddColumn<int>(
                name: "PartyID",
                table: "StockOut",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StockOutBill",
                columns: table => new
                {
                    StockOutBillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivedByPartyID = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GivenBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockOutBill", x => x.StockOutBillID);
                    table.ForeignKey(
                        name: "FK_StockOutBill_Party_ReceivedByPartyID",
                        column: x => x.ReceivedByPartyID,
                        principalTable: "Party",
                        principalColumn: "PartyID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StockOutBill_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StockOutBill_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 2, 16, 13, 46, 46, DateTimeKind.Local).AddTicks(5339));

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 2, 16, 13, 46, 46, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 2, 16, 13, 46, 46, DateTimeKind.Local).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 2, 16, 13, 46, 46, DateTimeKind.Local).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "SizeID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 2, 16, 13, 46, 46, DateTimeKind.Local).AddTicks(5281));

            migrationBuilder.CreateIndex(
                name: "IX_StockOut_PartyID",
                table: "StockOut",
                column: "PartyID");

            migrationBuilder.CreateIndex(
                name: "IX_StockOutBill_CreatedByUserID",
                table: "StockOutBill",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_StockOutBill_ReceivedByPartyID",
                table: "StockOutBill",
                column: "ReceivedByPartyID");

            migrationBuilder.CreateIndex(
                name: "IX_StockOutBill_UpdatedByUserID",
                table: "StockOutBill",
                column: "UpdatedByUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvanceSalary_Employee_EmployeeID",
                table: "AdvanceSalary",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvanceSalary_User_CreatedByUserID",
                table: "AdvanceSalary",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_User_CreatedByUserID",
                table: "Employee",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAttendence_Employee_EmployeeID",
                table: "EmployeeAttendence",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAttendence_User_CreatedByUserID",
                table: "EmployeeAttendence",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Item_ItemID",
                table: "Inventory",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Party_PartyID",
                table: "Inventory",
                column: "PartyID",
                principalTable: "Party",
                principalColumn: "PartyID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Size_SizeID",
                table: "Inventory",
                column: "SizeID",
                principalTable: "Size",
                principalColumn: "SizeID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_User_CreatedByUserID",
                table: "Inventory",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryNote_Inventory_InventoryID",
                table: "InventoryNote",
                column: "InventoryID",
                principalTable: "Inventory",
                principalColumn: "InventoryID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryNote_Note_NoteID",
                table: "InventoryNote",
                column: "NoteID",
                principalTable: "Note",
                principalColumn: "NoteID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Inventory_InventoryID",
                table: "Invoice",
                column: "InventoryID",
                principalTable: "Inventory",
                principalColumn: "InventoryID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Party_PartyID",
                table: "Invoice",
                column: "PartyID",
                principalTable: "Party",
                principalColumn: "PartyID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_User_CreatedByUserID",
                table: "Invoice",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_CreatedByUserID",
                table: "Item",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ledger_Invoice_InvoiceID",
                table: "Ledger",
                column: "InvoiceID",
                principalTable: "Invoice",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ledger_User_CreatedByUserID",
                table: "Ledger",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_User_CreatedByUserID",
                table: "Note",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Party_User_CreatedByUserID",
                table: "Party",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PartyLedger_Party_PartyID",
                table: "PartyLedger",
                column: "PartyID",
                principalTable: "Party",
                principalColumn: "PartyID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PartyLedger_User_CreatedByUserID",
                table: "PartyLedger",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_User_CreatedByUserID",
                table: "Permission",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Permission_PermissionId",
                table: "RolePermission",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Role_RoleId",
                table: "RolePermission",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_User_CreatedByUserID",
                table: "RolePermission",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllotment_Party_PartyID",
                table: "RoomAllotment",
                column: "PartyID",
                principalTable: "Party",
                principalColumn: "PartyID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllotment_User_CreatedByUserID",
                table: "RoomAllotment",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentDetails_Party_PartyID",
                table: "ShipmentDetails",
                column: "PartyID",
                principalTable: "Party",
                principalColumn: "PartyID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentDetails_User_CreatedByUserID",
                table: "ShipmentDetails",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Size_User_CreatedByUserID",
                table: "Size",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StockOut_Inventory_InventoryID",
                table: "StockOut",
                column: "InventoryID",
                principalTable: "Inventory",
                principalColumn: "InventoryID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StockOut_Item_ItemID",
                table: "StockOut",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StockOut_Party_PartyID",
                table: "StockOut",
                column: "PartyID",
                principalTable: "Party",
                principalColumn: "PartyID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockOut_StockOutBill_StockOutBillID",
                table: "StockOut",
                column: "StockOutBillID",
                principalTable: "StockOutBill",
                principalColumn: "StockOutBillID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StockOut_User_CreatedByUserID",
                table: "StockOut",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvanceSalary_Employee_EmployeeID",
                table: "AdvanceSalary");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvanceSalary_User_CreatedByUserID",
                table: "AdvanceSalary");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_User_CreatedByUserID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAttendence_Employee_EmployeeID",
                table: "EmployeeAttendence");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAttendence_User_CreatedByUserID",
                table: "EmployeeAttendence");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Item_ItemID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Party_PartyID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Size_SizeID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_User_CreatedByUserID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryNote_Inventory_InventoryID",
                table: "InventoryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryNote_Note_NoteID",
                table: "InventoryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Inventory_InventoryID",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Party_PartyID",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_User_CreatedByUserID",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_CreatedByUserID",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Ledger_Invoice_InvoiceID",
                table: "Ledger");

            migrationBuilder.DropForeignKey(
                name: "FK_Ledger_User_CreatedByUserID",
                table: "Ledger");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_User_CreatedByUserID",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Party_User_CreatedByUserID",
                table: "Party");

            migrationBuilder.DropForeignKey(
                name: "FK_PartyLedger_Party_PartyID",
                table: "PartyLedger");

            migrationBuilder.DropForeignKey(
                name: "FK_PartyLedger_User_CreatedByUserID",
                table: "PartyLedger");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_User_CreatedByUserID",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Permission_PermissionId",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Role_RoleId",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_User_CreatedByUserID",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllotment_Party_PartyID",
                table: "RoomAllotment");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllotment_User_CreatedByUserID",
                table: "RoomAllotment");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentDetails_Party_PartyID",
                table: "ShipmentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentDetails_User_CreatedByUserID",
                table: "ShipmentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Size_User_CreatedByUserID",
                table: "Size");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOut_Inventory_InventoryID",
                table: "StockOut");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOut_Item_ItemID",
                table: "StockOut");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOut_Party_PartyID",
                table: "StockOut");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOut_StockOutBill_StockOutBillID",
                table: "StockOut");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOut_User_CreatedByUserID",
                table: "StockOut");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User");

            migrationBuilder.DropTable(
                name: "StockOutBill");

            migrationBuilder.DropIndex(
                name: "IX_StockOut_PartyID",
                table: "StockOut");

            migrationBuilder.DropColumn(
                name: "PartyID",
                table: "StockOut");

            migrationBuilder.RenameColumn(
                name: "StockOutBillID",
                table: "StockOut",
                newName: "ReceivedByPartyID");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "StockOut",
                newName: "TotalAmount");

            migrationBuilder.RenameIndex(
                name: "IX_StockOut_StockOutBillID",
                table: "StockOut",
                newName: "IX_StockOut_ReceivedByPartyID");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "StockOut",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 1, 22, 5, 39, 288, DateTimeKind.Local).AddTicks(8850));

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 1, 22, 5, 39, 288, DateTimeKind.Local).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 1, 22, 5, 39, 288, DateTimeKind.Local).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 1, 22, 5, 39, 288, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "SizeID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 1, 22, 5, 39, 288, DateTimeKind.Local).AddTicks(8789));

            migrationBuilder.AddForeignKey(
                name: "FK_AdvanceSalary_Employee_EmployeeID",
                table: "AdvanceSalary",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvanceSalary_User_CreatedByUserID",
                table: "AdvanceSalary",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_User_CreatedByUserID",
                table: "Employee",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAttendence_Employee_EmployeeID",
                table: "EmployeeAttendence",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAttendence_User_CreatedByUserID",
                table: "EmployeeAttendence",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Item_ItemID",
                table: "Inventory",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Party_PartyID",
                table: "Inventory",
                column: "PartyID",
                principalTable: "Party",
                principalColumn: "PartyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Size_SizeID",
                table: "Inventory",
                column: "SizeID",
                principalTable: "Size",
                principalColumn: "SizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_User_CreatedByUserID",
                table: "Inventory",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryNote_Inventory_InventoryID",
                table: "InventoryNote",
                column: "InventoryID",
                principalTable: "Inventory",
                principalColumn: "InventoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryNote_Note_NoteID",
                table: "InventoryNote",
                column: "NoteID",
                principalTable: "Note",
                principalColumn: "NoteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Inventory_InventoryID",
                table: "Invoice",
                column: "InventoryID",
                principalTable: "Inventory",
                principalColumn: "InventoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Party_PartyID",
                table: "Invoice",
                column: "PartyID",
                principalTable: "Party",
                principalColumn: "PartyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_User_CreatedByUserID",
                table: "Invoice",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_CreatedByUserID",
                table: "Item",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ledger_Invoice_InvoiceID",
                table: "Ledger",
                column: "InvoiceID",
                principalTable: "Invoice",
                principalColumn: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ledger_User_CreatedByUserID",
                table: "Ledger",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_User_CreatedByUserID",
                table: "Note",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Party_User_CreatedByUserID",
                table: "Party",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_PartyLedger_Party_PartyID",
                table: "PartyLedger",
                column: "PartyID",
                principalTable: "Party",
                principalColumn: "PartyID");

            migrationBuilder.AddForeignKey(
                name: "FK_PartyLedger_User_CreatedByUserID",
                table: "PartyLedger",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_User_CreatedByUserID",
                table: "Permission",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Permission_PermissionId",
                table: "RolePermission",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Role_RoleId",
                table: "RolePermission",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_User_CreatedByUserID",
                table: "RolePermission",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllotment_Party_PartyID",
                table: "RoomAllotment",
                column: "PartyID",
                principalTable: "Party",
                principalColumn: "PartyID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllotment_User_CreatedByUserID",
                table: "RoomAllotment",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentDetails_Party_PartyID",
                table: "ShipmentDetails",
                column: "PartyID",
                principalTable: "Party",
                principalColumn: "PartyID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentDetails_User_CreatedByUserID",
                table: "ShipmentDetails",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Size_User_CreatedByUserID",
                table: "Size",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockOut_Inventory_InventoryID",
                table: "StockOut",
                column: "InventoryID",
                principalTable: "Inventory",
                principalColumn: "InventoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockOut_Item_ItemID",
                table: "StockOut",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockOut_Party_ReceivedByPartyID",
                table: "StockOut",
                column: "ReceivedByPartyID",
                principalTable: "Party",
                principalColumn: "PartyID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockOut_User_CreatedByUserID",
                table: "StockOut",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "RoleID");
        }
    }
}
