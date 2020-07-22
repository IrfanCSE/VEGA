using Microsoft.EntityFrameworkCore.Migrations;

namespace VEGA.Migrations
{
    public partial class ContactColumnsChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "Contact_Email",
                table: "Vehicles",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact_Name",
                table: "Vehicles",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact_Phone",
                table: "Vehicles",
                unicode: false,
                maxLength: 25,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact_Email",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Contact_Name",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Contact_Phone",
                table: "Vehicles");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ContactName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Contacts_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
