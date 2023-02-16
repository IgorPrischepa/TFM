using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tfm.api.dal.Migrations
{
    public partial class FixTypoInExampleEntityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examples_Styles_StyleStyleId",
                table: "Examples");

            migrationBuilder.RenameColumn(
                name: "StyleStyleId",
                table: "Examples",
                newName: "StyleId");

            migrationBuilder.RenameIndex(
                name: "IX_Examples_StyleStyleId",
                table: "Examples",
                newName: "IX_Examples_StyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examples_Styles_StyleId",
                table: "Examples",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examples_Styles_StyleId",
                table: "Examples");

            migrationBuilder.RenameColumn(
                name: "StyleId",
                table: "Examples",
                newName: "StyleStyleId");

            migrationBuilder.RenameIndex(
                name: "IX_Examples_StyleId",
                table: "Examples",
                newName: "IX_Examples_StyleStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examples_Styles_StyleStyleId",
                table: "Examples",
                column: "StyleStyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
