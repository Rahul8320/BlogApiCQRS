﻿// <auto-generated />
using System;
using CQRSAndMediatorPattern.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CQRSAndMediatorPattern.Infra.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20240511073807_Init Database")]
    partial class InitDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("CQRSAndMediatorPattern.Domain.Entities.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Blogs", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 100111,
                            Author = "Rick Hopkins",
                            Description = "The contracts project contains all the interfaces and DTOs for the solution. The example DTOs are Author and Book. Since we decided to follow the CQRS pattern our database queries and commands are separated into separate classes. Queries are based on the IQuery interface. https://dev.to/melodicdevelopment/dapper-cqrs-2ff2",
                            LastUpdated = new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Dapper & CQRS"
                        },
                        new
                        {
                            Id = 100112,
                            Author = "lastlink",
                            Description = " A project to demonstrate using github actions for a .net core 3.1 project. Uses unit tests, json snapshots, database tests using docker service containers. Demonstrates their use in github actions, Bitbucket, azure devops, and GitLab. https://dev.to/lastlink/dotnet-ci-pipelines-opc",
                            LastUpdated = new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "dotnet-ci-pipelines"
                        },
                        new
                        {
                            Id = 100113,
                            Author = "Rick Hopkins",
                            Description = "The dotnet-api-cqrs.tests project contains (simplistic) examples for doing integration as well as unit testing. This is pretty geared towards our particular Dapper / CQRS pattern, however it could be useful for other patterns as well. https://dev.to/melodicdevelopment/unit-integration-testing-in-net-with-moq-and-xunit-238a",
                            LastUpdated = new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Unit & Integration Testing In .Net With Moq and xUnit"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
