using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACS.Migrations
{
    public partial class cattableadded : Migration
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
                name: "FK_StockOutBill_Party_ReceivedByPartyID",
                table: "StockOutBill");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOutBill_User_CreatedByUserID",
                table: "StockOutBill");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Category_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Category_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transaction_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Transaction_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Transaction_User_UpdatedByUserID",
                        column: x => x.UpdatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 5, 17, 49, 19, 688, DateTimeKind.Utc).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 5, 17, 49, 19, 688, DateTimeKind.Utc).AddTicks(8719));

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 5, 17, 49, 19, 688, DateTimeKind.Utc).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 5, 17, 49, 19, 688, DateTimeKind.Local).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "SizeID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 5, 17, 49, 19, 688, DateTimeKind.Utc).AddTicks(8674));

            migrationBuilder.CreateIndex(
                name: "IX_Category_CreatedByUserID",
                table: "Category",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_UpdatedByUserID",
                table: "Category",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CategoryID",
                table: "Transaction",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CreatedByUserID",
                table: "Transaction",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_UpdatedByUserID",
                table: "Transaction",
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
                name: "FK_StockOutBill_Party_ReceivedByPartyID",
                table: "StockOutBill",
                column: "ReceivedByPartyID",
                principalTable: "Party",
                principalColumn: "PartyID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StockOutBill_User_CreatedByUserID",
                table: "StockOutBill",
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
                name: "FK_StockOutBill_Party_ReceivedByPartyID",
                table: "StockOutBill");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOutBill_User_CreatedByUserID",
                table: "StockOutBill");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 3, 0, 11, 29, 890, DateTimeKind.Utc).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 3, 0, 11, 29, 890, DateTimeKind.Utc).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 3, 0, 11, 29, 890, DateTimeKind.Utc).AddTicks(5205));

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 3, 0, 11, 29, 890, DateTimeKind.Local).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "SizeID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 3, 0, 11, 29, 890, DateTimeKind.Utc).AddTicks(5128));

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
                name: "FK_StockOutBill_Party_ReceivedByPartyID",
                table: "StockOutBill",
                column: "ReceivedByPartyID",
                principalTable: "Party",
                principalColumn: "PartyID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockOutBill_User_CreatedByUserID",
                table: "StockOutBill",
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
