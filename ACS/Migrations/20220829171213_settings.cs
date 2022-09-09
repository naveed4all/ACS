﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACS.Migrations
{
    public partial class settings : Migration
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

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingID);
                });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 8, 29, 22, 12, 12, 382, DateTimeKind.Local).AddTicks(9797));

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 8, 29, 22, 12, 12, 382, DateTimeKind.Local).AddTicks(9800));

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 8, 29, 22, 12, 12, 382, DateTimeKind.Local).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 8, 29, 22, 12, 12, 382, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "SettingID", "Key", "Value" },
                values: new object[] { 1, "GRNo", "1" });

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "SizeID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 8, 29, 22, 12, 12, 382, DateTimeKind.Local).AddTicks(9745));

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
                name: "FK_StockOut_Party_ReceivedByPartyID",
                table: "StockOut",
                column: "ReceivedByPartyID",
                principalTable: "Party",
                principalColumn: "PartyID",
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

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 8, 25, 21, 23, 6, 866, DateTimeKind.Local).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 8, 25, 21, 23, 6, 866, DateTimeKind.Local).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 8, 25, 21, 23, 6, 866, DateTimeKind.Local).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "Party",
                keyColumn: "PartyID",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 8, 25, 21, 23, 6, 866, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "SizeID",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 8, 25, 21, 23, 6, 866, DateTimeKind.Local).AddTicks(8038));

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
