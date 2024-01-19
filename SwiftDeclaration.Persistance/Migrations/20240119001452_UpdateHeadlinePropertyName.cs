using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftDeclaration.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHeadlinePropertyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeadLine",
                table: "Declarations",
                newName: "Headline");

            migrationBuilder.RenameIndex(
                name: "IX_Declarations_HeadLine",
                table: "Declarations",
                newName: "IX_Declarations_Headline");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Headline",
                table: "Declarations",
                newName: "HeadLine");

            migrationBuilder.RenameIndex(
                name: "IX_Declarations_Headline",
                table: "Declarations",
                newName: "IX_Declarations_HeadLine");
        }
    }
}
