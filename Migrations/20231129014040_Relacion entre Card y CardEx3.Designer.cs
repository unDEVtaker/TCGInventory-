﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCGInventory.Data;

#nullable disable

namespace TCGInventory.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231129014040_Relacion entre Card y CardEx3")]
    partial class RelacionentreCardyCardEx3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("TCGInventory.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Defense")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rarity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Set")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("YearReleased")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("TCGInventory.Models.CardExpansion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CardId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.ToTable("CardExpansion");
                });

            modelBuilder.Entity("TCGInventory.Models.CardExpansion", b =>
                {
                    b.HasOne("TCGInventory.Models.Card", "Card")
                        .WithMany("CardExpansions")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");
                });

            modelBuilder.Entity("TCGInventory.Models.Card", b =>
                {
                    b.Navigation("CardExpansions");
                });
#pragma warning restore 612, 618
        }
    }
}