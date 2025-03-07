using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoToMo.Data.Migrations
{
    /// <inheritdoc />
    public partial class Third_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Production_Staff_DirectorId",
                table: "Production");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Production_ProductionId",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_ProductionId",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Production_DirectorId",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "ProductionId",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Production");

            migrationBuilder.CreateTable(
                name: "ProductionStaff",
                columns: table => new
                {
                    ProductionsId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionStaff", x => new { x.ProductionsId, x.StaffId });
                    table.ForeignKey(
                        name: "FK_ProductionStaff_Production_ProductionsId",
                        column: x => x.ProductionsId,
                        principalTable: "Production",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionStaff_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionStaff_StaffId",
                table: "ProductionStaff",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionStaff");

            migrationBuilder.AddColumn<int>(
                name: "ProductionId",
                table: "Staff",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "Production",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_ProductionId",
                table: "Staff",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Production_DirectorId",
                table: "Production",
                column: "DirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Production_Staff_DirectorId",
                table: "Production",
                column: "DirectorId",
                principalTable: "Staff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Production_ProductionId",
                table: "Staff",
                column: "ProductionId",
                principalTable: "Production",
                principalColumn: "Id");
        }
    }
}
