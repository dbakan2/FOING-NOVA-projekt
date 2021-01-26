using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class DatabaseFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppItem_Bills_BillId",
                table: "AppItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppItem",
                table: "AppItem");

            migrationBuilder.RenameTable(
                name: "AppItem",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_AppItem_BillId",
                table: "Items",
                newName: "IX_Items_BillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Bills_BillId",
                table: "Items",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Bills_BillId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "AppItem");

            migrationBuilder.RenameIndex(
                name: "IX_Items_BillId",
                table: "AppItem",
                newName: "IX_AppItem_BillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppItem",
                table: "AppItem",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppItem_Bills_BillId",
                table: "AppItem",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
