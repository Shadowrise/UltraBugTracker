﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UltraBugTracker.API.Data;

namespace UltraBugTracker.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190225181955_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UltraBugTracker.API.Models.Bug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId");

                    b.Property<int>("AuthorId");

                    b.Property<DateTime>("CloseDate");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Bugs");

                    b.HasData(
                        new { Id = 1, AreaId = 0, AuthorId = 0, CloseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CreateDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Ultra bug new", Status = 1 },
                        new { Id = 2, AreaId = 0, AuthorId = 0, CloseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CreateDate = new DateTime(2000, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Ultra bug in progress", Status = 2 },
                        new { Id = 3, AreaId = 0, AuthorId = 0, CloseDate = new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CreateDate = new DateTime(2000, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Ultra bug closed", Status = 3 }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
