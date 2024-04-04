﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240404164321_seed")]
    partial class seed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataLayer.Models.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Followers")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"),
                            Bio = "This is John's profile",
                            Followers = 2,
                            Name = "John's profile",
                            UserId = new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3301")
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("683b30d6-70b8-4e1d-b531-cfc5e327f124"),
                            Description = "Basic subscription",
                            Name = "Basic",
                            Price = 10.00m
                        });
                });

            modelBuilder.Entity("DataLayer.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3301"),
                            Email = "john@email.com",
                            Name = "John",
                            Password = "**********",
                            ProfileId = new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"),
                            TypeId = new Guid("d39ea4fd-2900-4ce6-a81e-8fed108fe5e7")
                        });
                });

            modelBuilder.Entity("DataLayer.Models.UserType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d39ea4fd-2900-4ce6-a81e-8fed108fe5e7"),
                            Name = "User"
                        });
                });

            modelBuilder.Entity("SubscriptionUser", b =>
                {
                    b.Property<Guid>("SubscriptionsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SubscriptionsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("SubscriptionUser", (string)null);
                });

            modelBuilder.Entity("DataLayer.Models.Profile", b =>
                {
                    b.HasOne("DataLayer.Models.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("DataLayer.Models.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Models.User", b =>
                {
                    b.HasOne("DataLayer.Models.UserType", "Type")
                        .WithMany("Users")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("SubscriptionUser", b =>
                {
                    b.HasOne("DataLayer.Models.Subscription", null)
                        .WithMany()
                        .HasForeignKey("SubscriptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Models.User", b =>
                {
                    b.Navigation("Profile")
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Models.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}