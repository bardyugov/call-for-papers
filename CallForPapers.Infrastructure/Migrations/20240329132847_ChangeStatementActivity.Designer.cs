﻿// <auto-generated />
using System;
using CallForPapers.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CallForPapers.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240329132847_ChangeStatementActivity")]
    partial class ChangeStatementActivity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CallForPapers.Domain.Models.Statement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ActivityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Author")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Outline")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.ToTable("Statements");
                });

            modelBuilder.Entity("CallForPapers.Domain.Models.StatementActivity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8ba77d07-e26e-48a4-8a52-f344dcb1b5a1"),
                            Description = "Доклад, 35-45 минут",
                            Name = "Report"
                        },
                        new
                        {
                            Id = new Guid("9adc585d-de90-4931-bb9e-5741d0c74746"),
                            Description = "Мастеркласс, 1-2 часа",
                            Name = "Masterclass"
                        },
                        new
                        {
                            Id = new Guid("babd3aaa-6cab-46e3-a0d9-2a69d134da8c"),
                            Description = "Дискуссия / круглый стол, 40-50 минут",
                            Name = "Discussion"
                        });
                });

            modelBuilder.Entity("CallForPapers.Domain.Models.Statement", b =>
                {
                    b.HasOne("CallForPapers.Domain.Models.StatementActivity", "Activity")
                        .WithMany("Statements")
                        .HasForeignKey("ActivityId");

                    b.Navigation("Activity");
                });

            modelBuilder.Entity("CallForPapers.Domain.Models.StatementActivity", b =>
                {
                    b.Navigation("Statements");
                });
#pragma warning restore 612, 618
        }
    }
}
