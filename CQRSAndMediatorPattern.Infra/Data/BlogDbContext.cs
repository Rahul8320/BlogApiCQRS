using CQRSAndMediatorPattern.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatorPattern.Infra.Data;

public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
{
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // database table name
        modelBuilder.Entity<Blog>().ToTable("Blogs");

        // seed data to blog table
        modelBuilder.Entity<Blog>().HasData(
            new Blog
            {
                Id = 100111,
                Name = "Dapper & CQRS",
                Description = "The contracts project contains all the interfaces and DTOs for the solution. The example DTOs are Author and Book. Since we decided to follow the CQRS pattern our database queries and commands are separated into separate classes. Queries are based on the IQuery interface. https://dev.to/melodicdevelopment/dapper-cqrs-2ff2",
                Author = "Rick Hopkins",
                LastUpdated = DateTime.Parse("11-8-2021"),
            },
            new Blog
            {
                Id = 100112,
                Name = "dotnet-ci-pipelines",
                Description = " A project to demonstrate using github actions for a .net core 3.1 project. Uses unit tests, json snapshots, database tests using docker service containers. Demonstrates their use in github actions, Bitbucket, azure devops, and GitLab. https://dev.to/lastlink/dotnet-ci-pipelines-opc",
                Author = "lastlink",
                LastUpdated = DateTime.Parse("10-11-2021"),
            },
            new Blog
            {
                Id = 100113,
                Name = "Unit & Integration Testing In .Net With Moq and xUnit",
                Description = "The dotnet-api-cqrs.tests project contains (simplistic) examples for doing integration as well as unit testing. This is pretty geared towards our particular Dapper / CQRS pattern, however it could be useful for other patterns as well. https://dev.to/melodicdevelopment/unit-integration-testing-in-net-with-moq-and-xunit-238a",
                Author = "Rick Hopkins",
                LastUpdated = DateTime.Parse("15-8-2021"),
            }
        );
    }
}
