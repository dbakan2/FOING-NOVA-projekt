using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class DatabaseChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Bills_AppBillid",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AppBillid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AppBillid",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "AppUserid",
                table: "Bills",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_AppUserid",
                table: "Bills",
                column: "AppUserid");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Users_AppUserid",
                table: "Bills",
                column: "AppUserid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Users_AppUserid",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_AppUserid",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "AppUserid",
                table: "Bills");

            migrationBuilder.AddColumn<int>(
                name: "AppBillid",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AppBillid",
                table: "Users",
                column: "AppBillid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Bills_AppBillid",
                table: "Users",
                column: "AppBillid",
                principalTable: "Bills",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
