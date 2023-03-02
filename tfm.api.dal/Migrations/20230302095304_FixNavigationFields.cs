using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tfm.api.dal.Migrations
{
    public partial class FixNavigationFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examples_PhotoFiles_PhotoFileId",
                table: "Examples");

            migrationBuilder.DropIndex(
                name: "IX_Examples_PhotoFileId",
                table: "Examples");

            migrationBuilder.AddColumn<int>(
                name: "ExampleId",
                table: "PhotoFiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Contacts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PhotoFiles_ExampleId",
                table: "PhotoFiles",
                column: "ExampleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoFiles_Examples_ExampleId",
                table: "PhotoFiles",
                column: "ExampleId",
                principalTable: "Examples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoFiles_Examples_ExampleId",
                table: "PhotoFiles");

            migrationBuilder.DropIndex(
                name: "IX_PhotoFiles_ExampleId",
                table: "PhotoFiles");

            migrationBuilder.DropColumn(
                name: "ExampleId",
                table: "PhotoFiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contacts");

            migrationBuilder.CreateIndex(
                name: "IX_Examples_PhotoFileId",
                table: "Examples",
                column: "PhotoFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examples_PhotoFiles_PhotoFileId",
                table: "Examples",
                column: "PhotoFileId",
                principalTable: "PhotoFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
