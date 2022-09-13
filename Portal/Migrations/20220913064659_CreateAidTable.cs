using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class CreateAidTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AidTypeID",
                table: "Disaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AidType",
                columns: table => new
                {
                    AidTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AidType", x => x.AidTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disaster_AidTypeID",
                table: "Disaster",
                column: "AidTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Disaster_AidType_AidTypeID",
                table: "Disaster",
                column: "AidTypeID",
                principalTable: "AidType",
                principalColumn: "AidTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disaster_AidType_AidTypeID",
                table: "Disaster");

            migrationBuilder.DropTable(
                name: "AidType");

            migrationBuilder.DropIndex(
                name: "IX_Disaster_AidTypeID",
                table: "Disaster");

            migrationBuilder.DropColumn(
                name: "AidTypeID",
                table: "Disaster");
        }
    }
}
