﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Fujitsu.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240623191006_TablesGudang")]
    partial class TablesGudang
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Fujitsu.ADO.NET.Models.Gudang", b =>
                {
                    b.Property<int>("Kode_Gudang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Kode_Gudang"));

                    b.Property<string>("Nama_Gudang")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Kode_Gudang");

                    b.ToTable("Gudangs");
                });
#pragma warning restore 612, 618
        }
    }
}
