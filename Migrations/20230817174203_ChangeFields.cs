using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFTestCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_UserDbUserId",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserDbUserId",
                table: "Characters",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "Characters",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_UserDbUserId",
                table: "Characters",
                newName: "IX_Characters_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Characters",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Characters",
                newName: "UserDbUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Characters",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                newName: "IX_Characters_UserDbUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_UserDbUserId",
                table: "Characters",
                column: "UserDbUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
