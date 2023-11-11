using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemMarketplaceTestTask.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "nvarchar(450)",
                nullable: false,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Seller",
                table: "Auctions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Name",
                table: "Items",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_Seller",
                table: "Auctions",
                column: "Seller");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Items_Name",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_Seller",
                table: "Auctions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "Seller",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
