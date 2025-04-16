using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appka.Migrations
{
    /// <inheritdoc />
    public partial class Raiting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewiews_Users_UserId",
                table: "Rewiews");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Rewiews",
                newName: "RecieverId");

            migrationBuilder.RenameIndex(
                name: "IX_Rewiews_UserId",
                table: "Rewiews",
                newName: "IX_Rewiews_RecieverId");

            migrationBuilder.AlterColumn<double>(
                name: "Raiting",
                table: "Users",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Raiting",
                table: "Rewiews",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Rewiews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Raiting",
                table: "Cars",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Raiting",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Raiting",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "Raiting",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Raiting",
                value: 4.7999999999999998);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Raiting",
                value: 5.0);

            migrationBuilder.CreateIndex(
                name: "IX_Rewiews_SenderId",
                table: "Rewiews",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rewiews_Users_RecieverId",
                table: "Rewiews",
                column: "RecieverId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rewiews_Users_SenderId",
                table: "Rewiews",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewiews_Users_RecieverId",
                table: "Rewiews");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewiews_Users_SenderId",
                table: "Rewiews");

            migrationBuilder.DropIndex(
                name: "IX_Rewiews_SenderId",
                table: "Rewiews");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Rewiews");

            migrationBuilder.DropColumn(
                name: "Raiting",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "RecieverId",
                table: "Rewiews",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Rewiews_RecieverId",
                table: "Rewiews",
                newName: "IX_Rewiews_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Raiting",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Raiting",
                table: "Rewiews",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Raiting",
                value: "4.8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Raiting",
                value: "5.0");

            migrationBuilder.AddForeignKey(
                name: "FK_Rewiews_Users_UserId",
                table: "Rewiews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
