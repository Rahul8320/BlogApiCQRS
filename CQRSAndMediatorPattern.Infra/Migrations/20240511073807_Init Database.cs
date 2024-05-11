using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CQRSAndMediatorPattern.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Author", "Description", "LastUpdated", "Name" },
                values: new object[,]
                {
                    { 100111, "Rick Hopkins", "The contracts project contains all the interfaces and DTOs for the solution. The example DTOs are Author and Book. Since we decided to follow the CQRS pattern our database queries and commands are separated into separate classes. Queries are based on the IQuery interface. https://dev.to/melodicdevelopment/dapper-cqrs-2ff2", new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dapper & CQRS" },
                    { 100112, "lastlink", " A project to demonstrate using github actions for a .net core 3.1 project. Uses unit tests, json snapshots, database tests using docker service containers. Demonstrates their use in github actions, Bitbucket, azure devops, and GitLab. https://dev.to/lastlink/dotnet-ci-pipelines-opc", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "dotnet-ci-pipelines" },
                    { 100113, "Rick Hopkins", "The dotnet-api-cqrs.tests project contains (simplistic) examples for doing integration as well as unit testing. This is pretty geared towards our particular Dapper / CQRS pattern, however it could be useful for other patterns as well. https://dev.to/melodicdevelopment/unit-integration-testing-in-net-with-moq-and-xunit-238a", new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unit & Integration Testing In .Net With Moq and xUnit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
