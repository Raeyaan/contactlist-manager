﻿// <auto-generated />
using System;
using ContactList.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactList.Migrations
{
    [DbContext(typeof(ContactContext))]
    partial class ContactContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ContactList.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Friend"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Family"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Work"
                        });
                });

            modelBuilder.Entity("ContactList.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            ContactId = 4,
                            CategoryId = 1,
                            Created = new DateTime(2015, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified),
                            Email = "n7lO5@example.com",
                            FirstName = "John",
                            LastName = "Smith",
                            Phone = "456-478-159"
                        },
                        new
                        {
                            ContactId = 2,
                            CategoryId = 2,
                            Created = new DateTime(2015, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified),
                            Email = "n7lO6@example.com",
                            FirstName = "Alice",
                            LastName = "Ross",
                            Phone = "789-657-719"
                        },
                        new
                        {
                            ContactId = 3,
                            CategoryId = 3,
                            Created = new DateTime(2015, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified),
                            Email = "n7lO7@example.com",
                            FirstName = "Chris",
                            LastName = "Lewis",
                            Phone = "196-746-319"
                        });
                });

            modelBuilder.Entity("ContactList.Models.Contact", b =>
                {
                    b.HasOne("ContactList.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
