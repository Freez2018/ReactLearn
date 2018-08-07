﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(UsersManagementContext))]
    [Migration("20180807184423_addProductsMatching2")]
    partial class addProductsMatching2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Description");

                    b.Property<double>("MeasurableValue");

                    b.Property<string>("Name");

                    b.Property<string>("UserAddedId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Data.Entities.ProductCategory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("Data.Entities.ProductsMatching", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BaseProductId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("MatchProductId");

                    b.Property<double>("Rate1");

                    b.Property<double>("Rate2");

                    b.Property<double>("Rate3");

                    b.Property<string>("UserAddedId");

                    b.HasKey("Id");

                    b.HasIndex("BaseProductId");

                    b.HasIndex("MatchProductId");

                    b.ToTable("ProductsMatching");
                });

            modelBuilder.Entity("Data.Entities.Rank", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("DisplayName");

                    b.Property<int>("Points");

                    b.HasKey("Id");

                    b.ToTable("Rank");
                });

            modelBuilder.Entity("Data.Entities.Product", b =>
                {
                    b.HasOne("Data.Entities.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Data.Entities.ProductsMatching", b =>
                {
                    b.HasOne("Data.Entities.Product", "BaseProduct")
                        .WithMany()
                        .HasForeignKey("BaseProductId");

                    b.HasOne("Data.Entities.Product", "MatchProduct")
                        .WithMany()
                        .HasForeignKey("MatchProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
