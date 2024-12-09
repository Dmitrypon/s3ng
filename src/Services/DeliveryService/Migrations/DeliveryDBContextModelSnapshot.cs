﻿// <auto-generated />
using System;
using DeliveryService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeliveryService.Migrations
{
    [DbContext(typeof(DeliveryDBContext))]
    partial class DeliveryDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DeliveryService.Domain.Domain.Entities.Delivery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("Courer_Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateTimeestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Delivery_Time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("Order_Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Shipping_Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<decimal>("Total_Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Total_Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Deliveries");
                });
#pragma warning restore 612, 618
        }
    }
}
