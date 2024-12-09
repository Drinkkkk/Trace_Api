﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trace_Api.Context;

#nullable disable

namespace Trace_Api.Migrations
{
    [DbContext(typeof(TraceContext))]
    [Migration("20241209071308_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Trace_Api.Model.Coordinate", b =>
                {
                    b.Property<int>("CoordinateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoordinateID"), 1L, 1);

                    b.Property<DateTime?>("CreateDataTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TripID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDataTime")
                        .HasColumnType("datetime2");

                    b.HasKey("CoordinateID");

                    b.HasIndex("TripID");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("Trace_Api.Model.Trip", b =>
                {
                    b.Property<int>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripID"), 1L, 1);

                    b.Property<DateTime?>("CreateDataTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TripEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TripStartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TripStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TruckID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDataTime")
                        .HasColumnType("datetime2");

                    b.HasKey("TripID");

                    b.HasIndex("TruckID");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Trace_Api.Model.Truck", b =>
                {
                    b.Property<int>("TruckID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TruckID"), 1L, 1);

                    b.Property<DateTime?>("CreateDataTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicensePlate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("LoadCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateDataTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("VehicleModel")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TruckID");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("Trace_Api.Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<DateTime?>("CreateDataTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateDataTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Trace_Api.Model.Coordinate", b =>
                {
                    b.HasOne("Trace_Api.Model.Trip", "Trip")
                        .WithMany("Coordinates")
                        .HasForeignKey("TripID");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Trace_Api.Model.Trip", b =>
                {
                    b.HasOne("Trace_Api.Model.Truck", "Truck")
                        .WithMany("Trips")
                        .HasForeignKey("TruckID");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("Trace_Api.Model.Trip", b =>
                {
                    b.Navigation("Coordinates");
                });

            modelBuilder.Entity("Trace_Api.Model.Truck", b =>
                {
                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}