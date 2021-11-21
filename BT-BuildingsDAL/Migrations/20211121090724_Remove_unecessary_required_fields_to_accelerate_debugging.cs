using Microsoft.EntityFrameworkCore.Migrations;

namespace BT_BuildingsDAL.Migrations
{
    public partial class Remove_unecessary_required_fields_to_accelerate_debugging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingImage_Buildings_BuildingId",
                table: "BuildingImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingImage",
                table: "BuildingImage");

            migrationBuilder.RenameTable(
                name: "BuildingImage",
                newName: "BuildingImages");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingImage_BuildingId",
                table: "BuildingImages",
                newName: "IX_BuildingImages_BuildingId");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Buildings",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HouseNumber",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingImages",
                table: "BuildingImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingImages_Buildings_BuildingId",
                table: "BuildingImages",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingImages_Buildings_BuildingId",
                table: "BuildingImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingImages",
                table: "BuildingImages");

            migrationBuilder.RenameTable(
                name: "BuildingImages",
                newName: "BuildingImage");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingImages_BuildingId",
                table: "BuildingImage",
                newName: "IX_BuildingImage_BuildingId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Buildings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HouseNumber",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingImage",
                table: "BuildingImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingImage_Buildings_BuildingId",
                table: "BuildingImage",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
