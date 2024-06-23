using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Fujitsu.Migrations
{
    /// <inheritdoc />
    public partial class TablesBarang : Migration
    {
        /// <inheritdoc />
       protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.CreateTable(
        name: "Barangs",
        columns: table => new
        {
            Kode_Barang = table.Column<int>(nullable: false)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn), // Gunakan IdentityByDefaultColumn untuk PostgreSQL
            Nama_Barang = table.Column<string>(type: "varchar(100)", nullable: false),
            Harga_Barang = table.Column<int>(nullable: false),
            Jumlah_Barang = table.Column<int>(nullable: false),
            Expired_Barang = table.Column<DateTime>(nullable: false),
            Kode_Gudang_ID = table.Column<int>(nullable: true) // Tipe data nullable int
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Barangs", x => x.Kode_Barang);
            table.ForeignKey(
                name: "FK_Barangs_Gudangs_Kode_Gudang_ID",
                column: x => x.Kode_Gudang_ID,
                principalTable: "Gudangs",
                principalColumn: "Kode_Gudang",
                onDelete: ReferentialAction.Restrict); // Sesuaikan onDelete sesuai kebutuhan (Restrict, Cascade, dll.)
        });

    migrationBuilder.CreateIndex(
        name: "IX_Barangs_Kode_Gudang_ID",
        table: "Barangs",
        column: "Kode_Gudang_ID");
}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barangs");
        }
    }
}
