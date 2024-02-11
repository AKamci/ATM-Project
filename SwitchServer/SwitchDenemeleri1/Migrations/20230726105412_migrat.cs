using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwitchDenemeleri1.Migrations
{
    /// <inheritdoc />
    public partial class migrat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loglar",
                columns: table => new
                {
                    IslemSırası = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Konum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HedefKonum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Islem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BasarıDurum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loglar", x => x.IslemSırası);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loglar");
        }
    }
}
