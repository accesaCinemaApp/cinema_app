﻿// <auto-generated />
using System;
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CinemaApp.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20200806111541_Version1")]
    partial class Version1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CinemaApp.Models.Booking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TimeSlotID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TimeSlotID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("CinemaApp.Models.CinemaRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoomNr")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CinemaRooms");
                });

            modelBuilder.Entity("CinemaApp.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("CoverPhoto")
                        .HasColumnName("image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Description")
                        .HasColumnName("varchar(250)")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnName("time")
                        .HasColumnType("time");

                    b.Property<float>("Rating")
                        .HasColumnName("float")
                        .HasColumnType("real");

                    b.Property<DateTime>("ReleasedDate")
                        .HasColumnName("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnName("varchar(250)")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CinemaApp.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookingID")
                        .HasColumnType("int");

                    b.Property<int?>("CinemaRoomId")
                        .HasColumnType("int");

                    b.Property<int>("Nr")
                        .HasColumnType("int");

                    b.Property<string>("Row")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("BookingID");

                    b.HasIndex("CinemaRoomId");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("CinemaApp.Models.TimeSlot", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CinemaRoomId")
                        .HasColumnType("int");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CinemaRoomId");

                    b.HasIndex("MovieId");

                    b.ToTable("TimeSlots");
                });

            modelBuilder.Entity("CinemaApp.Models.Booking", b =>
                {
                    b.HasOne("CinemaApp.Models.TimeSlot", "TimeSlot")
                        .WithMany()
                        .HasForeignKey("TimeSlotID");
                });

            modelBuilder.Entity("CinemaApp.Models.Seat", b =>
                {
                    b.HasOne("CinemaApp.Models.Booking", "Booking")
                        .WithMany("Seats")
                        .HasForeignKey("BookingID");

                    b.HasOne("CinemaApp.Models.CinemaRoom", null)
                        .WithMany("Seats")
                        .HasForeignKey("CinemaRoomId");
                });

            modelBuilder.Entity("CinemaApp.Models.TimeSlot", b =>
                {
                    b.HasOne("CinemaApp.Models.CinemaRoom", "CinemaRoom")
                        .WithMany()
                        .HasForeignKey("CinemaRoomId");

                    b.HasOne("CinemaApp.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");
                });
#pragma warning restore 612, 618
        }
    }
}
