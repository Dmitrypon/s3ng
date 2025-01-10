﻿// <auto-generated />
using System;
using DeliveryService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeliveryService.Migrations
{
    [DbContext(typeof(DeliveryDBContext))]
    [Migration("20250110180414_CreateModelUpdated")]
    partial class CreateModelUpdated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DeliveryService.Domain.Domain.Entities.Courier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DeliveryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId");

                    b.ToTable("Couriers");
                });

            modelBuilder.Entity("DeliveryService.Domain.Domain.Entities.Delivery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ActualDeliveryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CourierId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateTimestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DeliveryStatus")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EstimatedDeliveryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("integer");

                    b.Property<int>("PaymentType")
                        .HasColumnType("integer");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("TimeModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("DeliveryService.Domain.External.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PaymentType")
                        .HasColumnType("integer");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("DeliveryService.Domain.External.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("DeliveryId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("DeliveryService.Domain.Domain.Entities.Courier", b =>
                {
                    b.HasOne("DeliveryService.Domain.Domain.Entities.Delivery", "Delivery")
                        .WithMany("Couriers")
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delivery");
                });

            modelBuilder.Entity("DeliveryService.Domain.External.Entities.OrderItem", b =>
                {
                    b.HasOne("DeliveryService.Domain.Domain.Entities.Delivery", null)
                        .WithMany("Items")
                        .HasForeignKey("DeliveryId");

                    b.HasOne("DeliveryService.Domain.External.Entities.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DeliveryService.Domain.Domain.Entities.Delivery", b =>
                {
                    b.Navigation("Couriers");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("DeliveryService.Domain.External.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
