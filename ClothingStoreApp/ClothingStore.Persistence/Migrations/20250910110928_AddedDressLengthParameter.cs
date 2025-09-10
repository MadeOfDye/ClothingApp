using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedDressLengthParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Dress_Length",
                table: "Sizes",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dress_Length",
                table: "Sizes");
        }
    }
}
