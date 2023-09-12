﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REST_Practise.Data;

#nullable disable

namespace SOAPPractise.Migrations
{
    [DbContext(typeof(ERPContext))]
    [Migration("20230912093059_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SOAPPractise.Model.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("730a74ec-14a8-4692-ae92-cdd1a4117782"),
                            DepartmentName = "Engineering"
                        },
                        new
                        {
                            Id = new Guid("da87329a-5cd4-4917-b506-3f088109544d"),
                            DepartmentName = "Quality Assuarance"
                        },
                        new
                        {
                            Id = new Guid("4c1bd9a6-ae71-4c3d-9c11-e0e70a7d3a6b"),
                            DepartmentName = "Human Resource"
                        },
                        new
                        {
                            Id = new Guid("41804ac3-f675-42aa-8796-4a8b2ddb9ed9"),
                            DepartmentName = "Support"
                        },
                        new
                        {
                            Id = new Guid("14977c82-4005-4831-a4aa-4607e64174dd"),
                            DepartmentName = "Managed Services"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
