using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class ServiceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourierName = table.Column<string>(type: "TEXT", nullable: true),
                    CourierSlug = table.Column<string>(type: "TEXT", nullable: true),
                    Slug = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CollectionType = table.Column<string>(type: "TEXT", nullable: true),
                    DeliveryType = table.Column<string>(type: "TEXT", nullable: true),
                    ShortDescriptions = table.Column<string>(type: "TEXT", nullable: true),
                    Overview = table.Column<string>(type: "TEXT", nullable: true),
                    Features = table.Column<string>(type: "TEXT", nullable: true),
                    ImageSmall = table.Column<string>(type: "TEXT", nullable: true),
                    Imagelarge = table.Column<string>(type: "TEXT", nullable: true),
                    ImageSvg = table.Column<string>(type: "TEXT", nullable: true),
                    Courier = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageSmall = table.Column<string>(type: "TEXT", nullable: true),
                    Imagelarge = table.Column<string>(type: "TEXT", nullable: true),
                    ImageSvg = table.Column<string>(type: "TEXT", nullable: true),
                    Courier = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_links_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_links_ServiceId",
                table: "links",
                column: "ServiceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "links");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
