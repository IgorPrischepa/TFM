using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tfm.api.dal.Migrations
{
    public partial class ExtendUserContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Contacts",
                newName: "Value");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Contacts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Contacts",
                newName: "Phone");
        }
    }
}
