﻿// <auto-generated />
using System;
using DbOperationWithEfCode.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbOperationWithEfCode.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241203054941_updatedtheBookTable")]
    partial class updatedtheBookTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbOperationWithEfCode.Data.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuthorS");
                });

            modelBuilder.Entity("DbOperationWithEfCode.Data.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int?>("NoOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("LanguageId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Rom",
                            IsActive = true,
                            LanguageId = 3,
                            Title = "It Ends With Us",
                            country = "India"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Relationships",
                            IsActive = false,
                            LanguageId = 2,
                            Title = "Rememberence of him",
                            country = "Spain"
                        },
                        new
                        {
                            Id = 3,
                            Description = "The Pakistani gurl",
                            IsActive = true,
                            LanguageId = 4,
                            Title = "Malala",
                            country = "Paris"
                        },
                        new
                        {
                            Id = 4,
                            Description = "about a group of shephered",
                            IsActive = true,
                            LanguageId = 1,
                            Title = "The Alchemist",
                            country = "HongKong"
                        });
                });

            modelBuilder.Entity("DbOperationWithEfCode.Data.BookPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CurrencyTypeId")
                        .IsUnique();

                    b.ToTable("BookPrices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 854,
                            BookId = 3,
                            CurrencyTypeId = 3
                        },
                        new
                        {
                            Id = 2,
                            Amount = 265,
                            BookId = 2,
                            CurrencyTypeId = 2
                        },
                        new
                        {
                            Id = 3,
                            Amount = 658,
                            BookId = 4,
                            CurrencyTypeId = 4
                        },
                        new
                        {
                            Id = 4,
                            Amount = 458,
                            BookId = 1,
                            CurrencyTypeId = 1
                        });
                });

            modelBuilder.Entity("DbOperationWithEfCode.Data.CurrencyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CurrencyTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Currency = "INR"
                        },
                        new
                        {
                            Id = 2,
                            Currency = "Dollar"
                        },
                        new
                        {
                            Id = 3,
                            Currency = "Euro"
                        },
                        new
                        {
                            Id = 4,
                            Currency = "Dinar"
                        });
                });

            modelBuilder.Entity("DbOperationWithEfCode.Data.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Indian mothertounge",
                            Title = "Hindi"
                        },
                        new
                        {
                            Id = 2,
                            Description = "American mothertounge",
                            Title = "English"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Kerala mothertounge",
                            Title = "Malyalam"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Tamil Nadu's mothertounge",
                            Title = "Telugu"
                        });
                });

            modelBuilder.Entity("DbOperationWithEfCode.Data.Book", b =>
                {
                    b.HasOne("DbOperationWithEfCode.Data.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("DbOperationWithEfCode.Data.Language", "Language")
                        .WithMany("Books")
                        .HasForeignKey("LanguageId");

                    b.Navigation("Author");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("DbOperationWithEfCode.Data.BookPrice", b =>
                {
                    b.HasOne("DbOperationWithEfCode.Data.Book", "Book")
                        .WithMany("BookPrices")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbOperationWithEfCode.Data.CurrencyType", "CurrencyType")
                        .WithOne("BookPrices")
                        .HasForeignKey("DbOperationWithEfCode.Data.BookPrice", "CurrencyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("CurrencyType");
                });

            modelBuilder.Entity("DbOperationWithEfCode.Data.Book", b =>
                {
                    b.Navigation("BookPrices");
                });

            modelBuilder.Entity("DbOperationWithEfCode.Data.CurrencyType", b =>
                {
                    b.Navigation("BookPrices");
                });

            modelBuilder.Entity("DbOperationWithEfCode.Data.Language", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}