using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserSocial.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNameAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "NameAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameAccount",
                table: "AspNetUsers",
                newName: "Name");
        }
    }
}
