﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoListWeekSix.Data;

namespace ToDoListWeekSix.Migrations
{
    [DbContext(typeof(ListDbContext))]
    [Migration("20200608204310_SeedListData")]
    partial class SeedListData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToDoListWeekSix.Models.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assignee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Task")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Assignee = "Chase",
                            DueDate = new DateTime(2020, 6, 8, 15, 43, 9, 803, DateTimeKind.Local).AddTicks(2696),
                            Task = "Start up injection"
                        },
                        new
                        {
                            Id = 2,
                            Assignee = "Chase",
                            DueDate = new DateTime(2020, 6, 8, 15, 43, 9, 807, DateTimeKind.Local).AddTicks(7600),
                            Task = "Routing"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
