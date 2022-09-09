using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACS.Migrations
{
    public partial class ReplacedStockOutwithInvoiceandaddedlog : Migration
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
                name: "FK_Category_User_CreatedByUserID",
                table: "Category");

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
                name: "FK_Invoice_Party_PartyID",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_User_CreatedByUserID",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_CreatedByUserID",
                table: "Item");

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
                name: "FK_StockOut_StockOutBill_StockOutBillID",
                table: "StockOut");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOut_User_CreatedByUserID",
                table: "StockOut");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOut_User_UpdatedByUserID",
                table: "StockOut");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Category_CategoryID",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User_CreatedByUserID",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User");

            migrationBuilder.DropTable(
                name: "StockOutBill");

            migrationBuilder.DropIndex(
                name: "IX_StockOut_CreatedByUserID",
                table: "StockOut");

            migrationBuilder.DropIndex(
                name: "IX_StockOut_UpdatedByUserID",
                table: "StockOut");

            migrationBuilder.DropColumn(
                name: "CreatedByUserID",
                table: "StockOut");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "StockOut");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserID",
                table: "StockOut");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "StockOut");

            migrationBuilder.RenameColumn(
                name: "StockOutBillID",
                table: "StockOut",
                newName: "InvoiceID");

            migrationBuilder.RenameIndex(
                name: "IX_StockOut_StockOutBillID",
                table: "StockOut",
                newName: "IX_StockOut_InvoiceID");

            migrationBuilder.RenameColumn(
                name: "PartyID",
                table: "Invoice",
                newName: "ReceivedByPartyID");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Invoice",
                newName: "TotalAmount");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_PartyID",
                table: "Invoice",
                newName: "IX_Invoice_ReceivedByPartyID");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryID",
                table: "Invoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ReceivedByName",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "InventoryPartyLogs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartyID = table.Column<int>(type: "int", nullable: false),
                    InventoryID = table.Column<int>(type: "int", nullable: false),
                    GRNo = table.Column<int>(type: "int", nullable: false),
                    OwnerShipEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryPartyLogs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_InventoryPartyLogs_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InventoryPartyLogs_Party_PartyID",
                        column: x => x.PartyID,
                        principalTable: "Party",
                        principalColumn: "PartyID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2022, 9, 6, 22, 46, 25, 314, DateTimeKind.Utc).AddTicks(1460), new DateTime(2022, 9, 6, 22, 46, 25, 314, DateTimeKind.Utc).AddTicks(1444) });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 2,
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2022, 9, 6, 22, 46, 25, 314, DateTimeKind.Utc).AddTicks(1464), new DateTime(2022, 9, 6, 22, 46, 25, 314, DateTimeKind.Utc).AddTicks(1462) });

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2022, 9, 6, 22, 46, 25, 314, DateTimeKind.Utc).AddTicks(1502), new DateTime(2022, 9, 6, 22, 46, 25, 314, DateTimeKind.Utc).AddTicks(1499) });

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 2,
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2022, 9, 6, 22, 46, 25, 314, DateTimeKind.Utc).AddTicks(1506), new DateTime(2022, 9, 6, 22, 46, 25, 314, DateTimeKind.Utc).AddTicks(1506) });

            migrationBuilder.InsertData(
                table: "PartyLedger",
                columns: new[] { "PartyLedgerID", "ClosingBalance", "CreatedByUserID", "CreatedDateTime", "IsActive", "PartyID", "TodayCredit", "TodayDebit", "UpdatedByUserID", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 1, 0.0, 1, new DateTime(2022, 9, 6, 22, 46, 25, 314, DateTimeKind.Utc).AddTicks(1545), true, 1, 50000.0, 10000.0, null, new DateTime(2022, 9, 6, 22, 46, 25, 314, DateTimeKind.Utc).AddTicks(1541) },
                    { 2, 0.0, 1, new DateTime(2022, 9, 6, 22, 46, 25, 314, DateTimeKind.Utc).AddTicks(1548), true, 2, 0.0, 0.0, null, new DateTime(2022, 9, 6, 22, 46, 25, 314, DateTimeKind.Utc).AddTicks(1547) }
                });

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "SizeID",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2022, 9, 6, 22, 46, 25, 314, DateTimeKind.Utc).AddTicks(1391), new DateTime(2022, 9, 6, 22, 46, 25, 314, DateTimeKind.Utc).AddTicks(1382) });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryPartyLogs_InventoryID",
                table: "InventoryPartyLogs",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryPartyLogs_PartyID",
                table: "InventoryPartyLogs",
                column: "PartyID");

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
                name: "FK_Category_User_CreatedByUserID",
                table: "Category",
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
                name: "FK_Invoice_Party_ReceivedByPartyID",
                table: "Invoice",
                column: "ReceivedByPartyID",
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
                name: "FK_StockOut_Invoice_InvoiceID",
                table: "StockOut",
                column: "InvoiceID",
                principalTable: "Invoice",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StockOut_Item_ItemID",
                table: "StockOut",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Category_CategoryID",
                table: "Transaction",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User_CreatedByUserID",
                table: "Transaction",
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
                name: "FK_Category_User_CreatedByUserID",
                table: "Category");

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
                name: "FK_Invoice_Party_ReceivedByPartyID",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_User_CreatedByUserID",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_CreatedByUserID",
                table: "Item");

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
                name: "FK_StockOut_Invoice_InvoiceID",
                table: "StockOut");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOut_Item_ItemID",
                table: "StockOut");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Category_CategoryID",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User_CreatedByUserID",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User");

            migrationBuilder.DropTable(
                name: "InventoryPartyLogs");

            migrationBuilder.DeleteData(
                table: "PartyLedger",
                keyColumn: "PartyLedgerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PartyLedger",
                keyColumn: "PartyLedgerID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ReceivedByName",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "InvoiceID",
                table: "StockOut",
                newName: "StockOutBillID");

            migrationBuilder.RenameIndex(
                name: "IX_StockOut_InvoiceID",
                table: "StockOut",
                newName: "IX_StockOut_StockOutBillID");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Invoice",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "ReceivedByPartyID",
                table: "Invoice",
                newName: "PartyID");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_ReceivedByPartyID",
                table: "Invoice",
                newName: "IX_Invoice_PartyID");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserID",
                table: "StockOut",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "StockOut",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserID",
                table: "StockOut",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "StockOut",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryID",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "StockOutBill",
                columns: table => new
                {
                    StockOutBillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    ReceivedByPartyID = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GivenBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockOutBill", x => x.StockOutBillID);
                    table.ForeignKey(
                        name: "FK_StockOutBill_Party_ReceivedByPartyID",
                        column: x => x.ReceivedByPartyID,
                        principalTable: "Party",
                        principalColumn: "PartyID");
                    table.ForeignKey(
                        name: "FK_StockOutBill_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
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
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2022, 9, 5, 17, 49, 19, 688, DateTimeKind.Utc).AddTicks(8716), null });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 2,
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2022, 9, 5, 17, 49, 19, 688, DateTimeKind.Utc).AddTicks(8719), null });

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2022, 9, 5, 17, 49, 19, 688, DateTimeKind.Utc).AddTicks(8757), null });

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 2,
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2022, 9, 5, 17, 49, 19, 688, DateTimeKind.Local).AddTicks(8765), null });

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "SizeID",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "UpdatedDateTime" },
                values: new object[] { new DateTime(2022, 9, 5, 17, 49, 19, 688, DateTimeKind.Utc).AddTicks(8674), null });

            migrationBuilder.CreateIndex(
                name: "IX_StockOut_CreatedByUserID",
                table: "StockOut",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_StockOut_UpdatedByUserID",
                table: "StockOut",
                column: "UpdatedByUserID");

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
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvanceSalary_User_CreatedByUserID",
                table: "AdvanceSalary",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_User_CreatedByUserID",
                table: "Category",
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
                name: "FK_StockOut_StockOutBill_StockOutBillID",
                table: "StockOut",
                column: "StockOutBillID",
                principalTable: "StockOutBill",
                principalColumn: "StockOutBillID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockOut_User_CreatedByUserID",
                table: "StockOut",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockOut_User_UpdatedByUserID",
                table: "StockOut",
                column: "UpdatedByUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Category_CategoryID",
                table: "Transaction",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User_CreatedByUserID",
                table: "Transaction",
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
