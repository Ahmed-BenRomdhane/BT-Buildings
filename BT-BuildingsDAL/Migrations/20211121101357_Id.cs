using Microsoft.EntityFrameworkCore.Migrations;

namespace BT_BuildingsDAL.Migrations
{
    public partial class Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Owners_OwnerCIN",
                table: "Buildings");

            migrationBuilder.RenameColumn(
                name: "CIN",
                table: "Owners",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OwnerCIN",
                table: "Buildings",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Buildings_OwnerCIN",
                table: "Buildings",
                newName: "IX_Buildings_OwnerId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Owners_OwnerId",
                table: "Buildings",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Owners_OwnerId",
                table: "Buildings");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Owners",
                newName: "CIN");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Buildings",
                newName: "OwnerCIN");

            migrationBuilder.RenameIndex(
                name: "IX_Buildings_OwnerId",
                table: "Buildings",
                newName: "IX_Buildings_OwnerCIN");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Owners_OwnerCIN",
                table: "Buildings",
                column: "OwnerCIN",
                principalTable: "Owners",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
