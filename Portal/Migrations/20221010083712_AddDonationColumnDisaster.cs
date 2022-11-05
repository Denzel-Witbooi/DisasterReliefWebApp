using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class AddDonationColumnDisaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DonationMoney",
                table: "Disaster",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MonetaryID",
                table: "Disaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Disaster_MonetaryID",
                table: "Disaster",
                column: "MonetaryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Disaster_Monetary_MonetaryID",
                table: "Disaster",
                column: "MonetaryID",
                principalTable: "Monetary",
                principalColumn: "MonetaryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disaster_Monetary_MonetaryID",
                table: "Disaster");

            migrationBuilder.DropIndex(
                name: "IX_Disaster_MonetaryID",
                table: "Disaster");

            migrationBuilder.DropColumn(
                name: "DonationMoney",
                table: "Disaster");

            migrationBuilder.DropColumn(
                name: "MonetaryID",
                table: "Disaster");
        }
    }
}
