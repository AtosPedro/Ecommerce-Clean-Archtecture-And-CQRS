using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Infrastructure.Migrations
{
    public partial class CreatingRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Operations_MaterialId",
                table: "Operations",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_OperationalUnitId",
                table: "Operations",
                column: "OperationalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_StoreId",
                table: "Operations",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationalUnit_StoreId",
                table: "OperationalUnit",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationalUnit_Stores_StoreId",
                table: "OperationalUnit",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Materials_MaterialId",
                table: "Operations",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_OperationalUnit_OperationalUnitId",
                table: "Operations",
                column: "OperationalUnitId",
                principalTable: "OperationalUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Stores_StoreId",
                table: "Operations",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationalUnit_Stores_StoreId",
                table: "OperationalUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Materials_MaterialId",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_OperationalUnit_OperationalUnitId",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Stores_StoreId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_MaterialId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_OperationalUnitId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_StoreId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_OperationalUnit_StoreId",
                table: "OperationalUnit");
        }
    }
}
