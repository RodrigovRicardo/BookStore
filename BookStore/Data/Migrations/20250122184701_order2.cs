using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class order2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Books_BookId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Orders",
                newName: "bookId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BookId",
                table: "Orders",
                newName: "IX_Orders_bookId");

            migrationBuilder.AlterColumn<int>(
                name: "bookId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Books_bookId",
                table: "Orders",
                column: "bookId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Books_bookId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "bookId",
                table: "Orders",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_bookId",
                table: "Orders",
                newName: "IX_Orders_BookId");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Books_BookId",
                table: "Orders",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
