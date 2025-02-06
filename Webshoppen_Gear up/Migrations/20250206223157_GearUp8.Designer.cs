﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webshoppen_Gear_up.Models;

#nullable disable

namespace Webshoppen_Gear_up.Migrations
{
    [DbContext(typeof(GearUpContext))]
    [Migration("20250206223157_GearUp8")]
    partial class GearUp8
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Webshoppen_Gear_up.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<int?>("ShoppingCartID")
                        .HasColumnType("int");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Models.DeliveryService", b =>
                {
                    b.Property<int>("DeliveryServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliveryServiceID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeliveryServiceID");

                    b.ToTable("DeliveryServices");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemID"));

                    b.Property<int>("AmountInStock")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Discount")
                        .HasColumnType("bit");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiscInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int?>("OrderQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuplierID")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierID")
                        .HasColumnType("int");

                    b.HasKey("ItemID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("OrderID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<DateTime>("BuyDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BuyTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("DeliveryId")
                        .HasColumnType("int");

                    b.Property<int?>("DeliveryServiceID")
                        .HasColumnType("int");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemQuantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("OrderTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeliveryServiceID");

                    b.ToTable("PreviousOrders");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemID"));

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemQuantity")
                        .HasColumnType("int");

                    b.Property<int>("Shopping_CartID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("Shopping_CartID");

                    b.ToTable("ShoppingCartItem");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierID");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Shop.Shopping_Cart", b =>
                {
                    b.Property<int>("Shopping_CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Shopping_CartID"));

                    b.Property<decimal?>("CartTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int?>("ItemID")
                        .HasColumnType("int");

                    b.HasKey("Shopping_CartID");

                    b.HasIndex("CustomerID")
                        .IsUnique();

                    b.HasIndex("ItemID");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Models.Item", b =>
                {
                    b.HasOne("Webshoppen_Gear_up.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webshoppen_Gear_up.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderID");

                    b.HasOne("Webshoppen_Gear_up.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierID");

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Models.Order", b =>
                {
                    b.HasOne("Webshoppen_Gear_up.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webshoppen_Gear_up.Models.DeliveryService", "DeliveryService")
                        .WithMany()
                        .HasForeignKey("DeliveryServiceID");

                    b.Navigation("Customer");

                    b.Navigation("DeliveryService");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Models.OrderItem", b =>
                {
                    b.HasOne("Webshoppen_Gear_up.Models.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("Webshoppen_Gear_up.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webshoppen_Gear_up.Shop.Shopping_Cart", "ShoppingCart")
                        .WithMany("shoppingCartItems")
                        .HasForeignKey("Shopping_CartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Shop.Shopping_Cart", b =>
                {
                    b.HasOne("Webshoppen_Gear_up.Models.Customer", null)
                        .WithOne("Shopping_Cart")
                        .HasForeignKey("Webshoppen_Gear_up.Shop.Shopping_Cart", "CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webshoppen_Gear_up.Models.Item", null)
                        .WithMany("Shopping_Carts")
                        .HasForeignKey("ItemID");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Models.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Shopping_Cart");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Models.Item", b =>
                {
                    b.Navigation("Shopping_Carts");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Models.Order", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Webshoppen_Gear_up.Shop.Shopping_Cart", b =>
                {
                    b.Navigation("shoppingCartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
