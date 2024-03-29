﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PropDatabaseCore;

#nullable disable

namespace PropDatabaseCore.Migrations
{
    [DbContext(typeof(PropDbContext))]
    partial class PropDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PropMockModels.Client", b =>
                {
                    b.Property<int>("clientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("clientId"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("companyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("csPricing")
                        .HasColumnType("integer");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("esPricing")
                        .HasColumnType("integer");

                    b.Property<int>("lnpPricing")
                        .HasColumnType("integer");

                    b.Property<int>("lsPricing")
                        .HasColumnType("integer");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("rtPricing")
                        .HasColumnType("integer");

                    b.Property<int>("tcPricing")
                        .HasColumnType("integer");

                    b.HasKey("clientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("PropMockModels.CurativeServices", b =>
                {
                    b.Property<int>("csnumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("csnumber"));

                    b.Property<string>("AdditionalComments")
                        .HasColumnType("text");

                    b.Property<string>("AdditionalContactEmail")
                        .HasColumnType("text");

                    b.Property<string>("AddressTwo")
                        .HasColumnType("text");

                    b.Property<int?>("AssignedResearcher")
                        .HasColumnType("integer");

                    b.Property<string>("BuyerEmail")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("BuyerName")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Clientfilenumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Commercial")
                        .HasColumnType("boolean");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LegalDescription")
                        .HasColumnType("text");

                    b.Property<DateTime>("NeedByDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OwnerEmail")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Parcel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Refinance")
                        .HasColumnType("boolean");

                    b.Property<bool>("Rush")
                        .HasColumnType("boolean");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Vacant")
                        .HasColumnType("boolean");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("productId")
                        .HasColumnType("integer");

                    b.HasKey("csnumber");

                    b.HasIndex("productId")
                        .IsUnique();

                    b.ToTable("CSSearches");
                });

            modelBuilder.Entity("PropMockModels.Estoppel", b =>
                {
                    b.Property<int>("estoppelnumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("estoppelnumber"));

                    b.Property<string>("AdditionalComments")
                        .HasColumnType("text");

                    b.Property<string>("AdditionalContactEmail")
                        .HasColumnType("text");

                    b.Property<string>("AddressTwo")
                        .HasColumnType("text");

                    b.Property<int?>("AssignedResearcher")
                        .HasColumnType("integer");

                    b.Property<string>("BuyerName")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Clientfilenumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Commercial")
                        .HasColumnType("boolean");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LegalDescription")
                        .HasColumnType("text");

                    b.Property<DateTime>("NeedByDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OwnerEmail")
                        .HasColumnType("text");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Parcel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Refinance")
                        .HasColumnType("boolean");

                    b.Property<bool>("Rush")
                        .HasColumnType("boolean");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Vacant")
                        .HasColumnType("boolean");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("productId")
                        .HasColumnType("integer");

                    b.HasKey("estoppelnumber");

                    b.HasIndex("productId")
                        .IsUnique();

                    b.ToTable("EstoppelSearches");
                });

            modelBuilder.Entity("PropMockModels.LienSearch", b =>
                {
                    b.Property<int>("liensearchnumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("liensearchnumber"));

                    b.Property<string>("AdditionalComments")
                        .HasColumnType("text");

                    b.Property<string>("AdditionalContactEmail")
                        .HasColumnType("text");

                    b.Property<string>("AddressTwo")
                        .HasColumnType("text");

                    b.Property<int?>("AssignedResearcher")
                        .HasColumnType("integer");

                    b.Property<string>("BuyerName")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Clientfilenumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Code")
                        .HasColumnType("boolean");

                    b.Property<bool>("Commercial")
                        .HasColumnType("boolean");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LegalDescription")
                        .HasColumnType("text");

                    b.Property<DateTime>("NeedByDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OwnerEmail")
                        .HasColumnType("text");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Parcel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Permit")
                        .HasColumnType("boolean");

                    b.Property<bool>("Refinance")
                        .HasColumnType("boolean");

                    b.Property<bool>("Rush")
                        .HasColumnType("boolean");

                    b.Property<bool>("SpecialAssessments")
                        .HasColumnType("boolean");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Tax")
                        .HasColumnType("boolean");

                    b.Property<bool>("Utility")
                        .HasColumnType("boolean");

                    b.Property<bool>("Vacant")
                        .HasColumnType("boolean");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("productId")
                        .HasColumnType("integer");

                    b.HasKey("liensearchnumber");

                    b.HasIndex("productId")
                        .IsUnique();

                    b.ToTable("LienSearches");
                });

            modelBuilder.Entity("PropMockModels.Order", b =>
                {
                    b.Property<int>("ordernumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ordernumber"));

                    b.Property<string>("Clientfilenumber")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("ordernumber");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PropMockModels.Product", b =>
                {
                    b.Property<int>("filenumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("filenumber"));

                    b.Property<int>("OrderStatus")
                        .HasColumnType("integer");

                    b.Property<int>("ProductType")
                        .HasColumnType("integer");

                    b.Property<int>("orderNumber")
                        .HasColumnType("integer");

                    b.HasKey("filenumber");

                    b.HasIndex("orderNumber");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PropMockModels.ReleaseTracking", b =>
                {
                    b.Property<int>("rtnumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("rtnumber"));

                    b.Property<string>("AdditionalComments")
                        .HasColumnType("text");

                    b.Property<string>("AdditionalContactEmail")
                        .HasColumnType("text");

                    b.Property<string>("AddressTwo")
                        .HasColumnType("text");

                    b.Property<int?>("AssignedResearcher")
                        .HasColumnType("integer");

                    b.Property<string>("BuyerEmail")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("BuyerName")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Clientfilenumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Commercial")
                        .HasColumnType("boolean");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LegalDescription")
                        .HasColumnType("text");

                    b.Property<DateTime>("NeedByDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OwnerEmail")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Parcel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Refinance")
                        .HasColumnType("boolean");

                    b.Property<bool>("Rush")
                        .HasColumnType("boolean");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Vacant")
                        .HasColumnType("boolean");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("productId")
                        .HasColumnType("integer");

                    b.HasKey("rtnumber");

                    b.HasIndex("productId")
                        .IsUnique();

                    b.ToTable("RTSearches");
                });

            modelBuilder.Entity("PropMockModels.Tax", b =>
                {
                    b.Property<int>("taxnumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("taxnumber"));

                    b.Property<string>("AdditionalComments")
                        .HasColumnType("text");

                    b.Property<string>("AdditionalContactEmail")
                        .HasColumnType("text");

                    b.Property<string>("AddressTwo")
                        .HasColumnType("text");

                    b.Property<int?>("AssignedResearcher")
                        .HasColumnType("integer");

                    b.Property<string>("BuyerName")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Clientfilenumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Commercial")
                        .HasColumnType("boolean");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LegalDescription")
                        .HasColumnType("text");

                    b.Property<DateTime>("NeedByDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OwnerEmail")
                        .HasColumnType("text");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Parcel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Refinance")
                        .HasColumnType("boolean");

                    b.Property<bool>("Rush")
                        .HasColumnType("boolean");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Vacant")
                        .HasColumnType("boolean");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("productId")
                        .HasColumnType("integer");

                    b.HasKey("taxnumber");

                    b.HasIndex("productId")
                        .IsUnique();

                    b.ToTable("TaxSearches");
                });

            modelBuilder.Entity("PropMockModels.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("userId"));

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("additionalContacts")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("clientId")
                        .HasColumnType("integer");

                    b.Property<string>("companyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("userFirst")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("userLast")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("userNotes")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("userType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("userId");

                    b.HasIndex("clientId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PropMockModels.CurativeServices", b =>
                {
                    b.HasOne("PropMockModels.Product", "Product")
                        .WithOne("CS")
                        .HasForeignKey("PropMockModels.CurativeServices", "productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PropMockModels.Estoppel", b =>
                {
                    b.HasOne("PropMockModels.Product", "Product")
                        .WithOne("Estoppel")
                        .HasForeignKey("PropMockModels.Estoppel", "productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PropMockModels.LienSearch", b =>
                {
                    b.HasOne("PropMockModels.Product", "Product")
                        .WithOne("Lien")
                        .HasForeignKey("PropMockModels.LienSearch", "productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PropMockModels.Product", b =>
                {
                    b.HasOne("PropMockModels.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("orderNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PropMockModels.ReleaseTracking", b =>
                {
                    b.HasOne("PropMockModels.Product", "Product")
                        .WithOne("RT")
                        .HasForeignKey("PropMockModels.ReleaseTracking", "productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PropMockModels.Tax", b =>
                {
                    b.HasOne("PropMockModels.Product", "Product")
                        .WithOne("Tax")
                        .HasForeignKey("PropMockModels.Tax", "productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PropMockModels.User", b =>
                {
                    b.HasOne("PropMockModels.Client", "Client")
                        .WithMany("Users")
                        .HasForeignKey("clientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("PropMockModels.Client", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PropMockModels.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PropMockModels.Product", b =>
                {
                    b.Navigation("CS");

                    b.Navigation("Estoppel");

                    b.Navigation("Lien");

                    b.Navigation("RT");

                    b.Navigation("Tax");
                });
#pragma warning restore 612, 618
        }
    }
}
