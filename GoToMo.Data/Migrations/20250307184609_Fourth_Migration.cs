using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoToMo.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fourth_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Production",
                newName: "ReleaseYear");

            migrationBuilder.AlterColumn<int>(
                name: "SecondaryGenre",
                table: "Production",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PrimaryGenre",
                table: "Production",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plot",
                table: "Production",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Production",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plot",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Production");

            migrationBuilder.RenameColumn(
                name: "ReleaseYear",
                table: "Production",
                newName: "Year");

            migrationBuilder.AlterColumn<int>(
                name: "SecondaryGenre",
                table: "Production",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PrimaryGenre",
                table: "Production",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
