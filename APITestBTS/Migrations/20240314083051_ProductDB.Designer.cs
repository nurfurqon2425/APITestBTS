﻿// <auto-generated />
using APITestBTS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APITestBTS.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240314083051_ProductDB")]
    partial class ProductDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APITestBTS.Auth", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Auth");
                });

            modelBuilder.Entity("APITestBTS.Checklist", b =>
                {
                    b.Property<string>("ChecklistId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChecklistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChecklistId");

                    b.ToTable("Checklist");
                });

            modelBuilder.Entity("APITestBTS.ChecklistItem", b =>
                {
                    b.Property<string>("ChecklistItemId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CheckListId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChecklistItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChecklistItemId");

                    b.ToTable("ChecklistItem");
                });
#pragma warning restore 612, 618
        }
    }
}
