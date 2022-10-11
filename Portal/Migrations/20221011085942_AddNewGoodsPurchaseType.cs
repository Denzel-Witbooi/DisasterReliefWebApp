using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class AddNewGoodsPurchaseType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoodsPurchase",
                columns: table => new
                {
                    GoodsPurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisasterId = table.Column<int>(type: "int", nullable: false),
                    MonetaryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    purchaseAmount = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsPurchase", x => x.GoodsPurchaseId);
                    table.ForeignKey(
                        name: "FK_GoodsPurchase_Disaster_DisasterId",
                        column: x => x.DisasterId,
                        principalTable: "Disaster",
                        principalColumn: "DisasterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsPurchase_Monetary_MonetaryId",
                        column: x => x.MonetaryId,
                        principalTable: "Monetary",
                        principalColumn: "MonetaryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsPurchase_DisasterId",
                table: "GoodsPurchase",
                column: "DisasterId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsPurchase_MonetaryId",
                table: "GoodsPurchase",
                column: "MonetaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsPurchase");
        }
    }
}
