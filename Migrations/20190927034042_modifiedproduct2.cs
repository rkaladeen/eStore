using Microsoft.EntityFrameworkCore.Migrations;

namespace eStore.Migrations
{
    public partial class modifiedproduct2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "BidStartPrice",
                table: "Products",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "BidStartPrice",
                table: "Products",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
