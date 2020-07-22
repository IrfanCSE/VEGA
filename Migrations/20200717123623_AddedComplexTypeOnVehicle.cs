using Microsoft.EntityFrameworkCore.Migrations;

namespace VEGA.Migrations
{
    public partial class AddedComplexTypeOnVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_VehicleId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Contacts",
                newName: "ContactName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contacts",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "Contacts",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Contacts",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_VehicleId",
                table: "Contacts",
                column: "VehicleId",
                unique: true);
        }
    }
}
