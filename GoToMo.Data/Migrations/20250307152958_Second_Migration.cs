using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoToMo.Data.Migrations
{
    /// <inheritdoc />
    public partial class Second_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCollections_Users_OwnerId",
                table: "MovieCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_Productions_MovieCollections_MovieCollectionId",
                table: "Productions");

            migrationBuilder.DropForeignKey(
                name: "FK_Productions_ProductionBundle_BundleId",
                table: "Productions");

            migrationBuilder.DropForeignKey(
                name: "FK_Productions_Staff_DirectorId",
                table: "Productions");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Productions_ProductionId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Users_UserId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Productions_ProductionId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_StreamingServices_Productions_ProductionId",
                table: "StreamingServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_MovieCollections_MovieCollectionId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StreamingServices",
                table: "StreamingServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productions",
                table: "Productions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCollections",
                table: "MovieCollections");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "StreamingServices",
                newName: "StreamingService");

            migrationBuilder.RenameTable(
                name: "Productions",
                newName: "Production");

            migrationBuilder.RenameTable(
                name: "MovieCollections",
                newName: "MovieCollection");

            migrationBuilder.RenameIndex(
                name: "IX_Users_MovieCollectionId",
                table: "User",
                newName: "IX_User_MovieCollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_StreamingServices_ProductionId",
                table: "StreamingService",
                newName: "IX_StreamingService_ProductionId");

            migrationBuilder.RenameIndex(
                name: "IX_Productions_MovieCollectionId",
                table: "Production",
                newName: "IX_Production_MovieCollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Productions_DirectorId",
                table: "Production",
                newName: "IX_Production_DirectorId");

            migrationBuilder.RenameIndex(
                name: "IX_Productions_BundleId",
                table: "Production",
                newName: "IX_Production_BundleId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCollections_OwnerId",
                table: "MovieCollection",
                newName: "IX_MovieCollection_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StreamingService",
                table: "StreamingService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Production",
                table: "Production",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCollection",
                table: "MovieCollection",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCollection_User_OwnerId",
                table: "MovieCollection",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Production_MovieCollection_MovieCollectionId",
                table: "Production",
                column: "MovieCollectionId",
                principalTable: "MovieCollection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Production_ProductionBundle_BundleId",
                table: "Production",
                column: "BundleId",
                principalTable: "ProductionBundle",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Production_Staff_DirectorId",
                table: "Production",
                column: "DirectorId",
                principalTable: "Staff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Production_ProductionId",
                table: "Rating",
                column: "ProductionId",
                principalTable: "Production",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_User_UserId",
                table: "Rating",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Production_ProductionId",
                table: "Staff",
                column: "ProductionId",
                principalTable: "Production",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StreamingService_Production_ProductionId",
                table: "StreamingService",
                column: "ProductionId",
                principalTable: "Production",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_MovieCollection_MovieCollectionId",
                table: "User",
                column: "MovieCollectionId",
                principalTable: "MovieCollection",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCollection_User_OwnerId",
                table: "MovieCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_Production_MovieCollection_MovieCollectionId",
                table: "Production");

            migrationBuilder.DropForeignKey(
                name: "FK_Production_ProductionBundle_BundleId",
                table: "Production");

            migrationBuilder.DropForeignKey(
                name: "FK_Production_Staff_DirectorId",
                table: "Production");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Production_ProductionId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_User_UserId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Production_ProductionId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_StreamingService_Production_ProductionId",
                table: "StreamingService");

            migrationBuilder.DropForeignKey(
                name: "FK_User_MovieCollection_MovieCollectionId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StreamingService",
                table: "StreamingService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Production",
                table: "Production");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCollection",
                table: "MovieCollection");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "StreamingService",
                newName: "StreamingServices");

            migrationBuilder.RenameTable(
                name: "Production",
                newName: "Productions");

            migrationBuilder.RenameTable(
                name: "MovieCollection",
                newName: "MovieCollections");

            migrationBuilder.RenameIndex(
                name: "IX_User_MovieCollectionId",
                table: "Users",
                newName: "IX_Users_MovieCollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_StreamingService_ProductionId",
                table: "StreamingServices",
                newName: "IX_StreamingServices_ProductionId");

            migrationBuilder.RenameIndex(
                name: "IX_Production_MovieCollectionId",
                table: "Productions",
                newName: "IX_Productions_MovieCollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Production_DirectorId",
                table: "Productions",
                newName: "IX_Productions_DirectorId");

            migrationBuilder.RenameIndex(
                name: "IX_Production_BundleId",
                table: "Productions",
                newName: "IX_Productions_BundleId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCollection_OwnerId",
                table: "MovieCollections",
                newName: "IX_MovieCollections_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StreamingServices",
                table: "StreamingServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productions",
                table: "Productions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCollections",
                table: "MovieCollections",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCollections_Users_OwnerId",
                table: "MovieCollections",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productions_MovieCollections_MovieCollectionId",
                table: "Productions",
                column: "MovieCollectionId",
                principalTable: "MovieCollections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productions_ProductionBundle_BundleId",
                table: "Productions",
                column: "BundleId",
                principalTable: "ProductionBundle",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productions_Staff_DirectorId",
                table: "Productions",
                column: "DirectorId",
                principalTable: "Staff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Productions_ProductionId",
                table: "Rating",
                column: "ProductionId",
                principalTable: "Productions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Users_UserId",
                table: "Rating",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Productions_ProductionId",
                table: "Staff",
                column: "ProductionId",
                principalTable: "Productions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StreamingServices_Productions_ProductionId",
                table: "StreamingServices",
                column: "ProductionId",
                principalTable: "Productions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MovieCollections_MovieCollectionId",
                table: "Users",
                column: "MovieCollectionId",
                principalTable: "MovieCollections",
                principalColumn: "Id");
        }
    }
}
