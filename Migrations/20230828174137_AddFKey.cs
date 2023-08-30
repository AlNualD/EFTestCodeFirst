using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFTestCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class AddFKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GuildDb_GuildId",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuildDb",
                table: "GuildDb");

            migrationBuilder.RenameTable(
                name: "GuildDb",
                newName: "Guilds");

            migrationBuilder.AlterColumn<string>(
                name: "LeaderId",
                table: "Guilds",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guilds",
                table: "Guilds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Guilds_GuildId",
                table: "Characters",
                column: "GuildId",
                principalTable: "Guilds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Guilds_GuildId",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guilds",
                table: "Guilds");

            migrationBuilder.RenameTable(
                name: "Guilds",
                newName: "GuildDb");

            migrationBuilder.AlterColumn<string>(
                name: "LeaderId",
                table: "GuildDb",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuildDb",
                table: "GuildDb",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GuildDb_GuildId",
                table: "Characters",
                column: "GuildId",
                principalTable: "GuildDb",
                principalColumn: "Id");
        }
    }
}
