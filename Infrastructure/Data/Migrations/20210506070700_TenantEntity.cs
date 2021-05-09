﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class TenantEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Host = table.Column<string>(type: "TEXT", nullable: true),
                    ClientId = table.Column<string>(type: "TEXT", nullable: true),
                    ClientSecret = table.Column<string>(type: "TEXT", nullable: true),
                    Scope = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}