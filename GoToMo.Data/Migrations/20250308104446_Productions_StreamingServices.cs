using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoToMo.Data.Migrations
{
    /// <inheritdoc />
    public partial class Productions_StreamingServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StreamingService_Production_ProductionId",
                table: "StreamingService");

            migrationBuilder.DropIndex(
                name: "IX_StreamingService_ProductionId",
                table: "StreamingService");

            migrationBuilder.DropColumn(
                name: "ProductionId",
                table: "StreamingService");

            migrationBuilder.AlterColumn<string>(
                name: "Plot",
                table: "Production",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ProductionStreamingService",
                columns: table => new
                {
                    ProductionsId = table.Column<int>(type: "int", nullable: false),
                    StreamingServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionStreamingService", x => new { x.ProductionsId, x.StreamingServicesId });
                    table.ForeignKey(
                        name: "FK_ProductionStreamingService_Production_ProductionsId",
                        column: x => x.ProductionsId,
                        principalTable: "Production",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionStreamingService_StreamingService_StreamingServicesId",
                        column: x => x.StreamingServicesId,
                        principalTable: "StreamingService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionStreamingService_StreamingServicesId",
                table: "ProductionStreamingService",
                column: "StreamingServicesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionStreamingService");

            migrationBuilder.AddColumn<int>(
                name: "ProductionId",
                table: "StreamingService",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Plot",
                table: "Production",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StreamingService_ProductionId",
                table: "StreamingService",
                column: "ProductionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StreamingService_Production_ProductionId",
                table: "StreamingService",
                column: "ProductionId",
                principalTable: "Production",
                principalColumn: "Id");
        }
    }
}
