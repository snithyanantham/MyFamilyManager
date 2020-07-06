using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFamilyManager.API.Repositories.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("baf5cfac-b37e-11ea-b3de-0242ac130004"), "Income", "Income" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("baf5dfac-b37e-11ea-b3de-0242ac130004"), "Expenses", "Expenses" });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[] { new Guid("baf5d1e6-b37e-11ea-b3de-0242ac130004"), new Guid("baf5cfac-b37e-11ea-b3de-0242ac130004"), "Salary", "Salary" });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[] { new Guid("baf5d2e6-b37e-11ea-b3de-0242ac130004"), new Guid("baf5dfac-b37e-11ea-b3de-0242ac130004"), "Rent", "Rent" });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[] { new Guid("baf5d3e6-b37e-11ea-b3de-0242ac130004"), new Guid("baf5dfac-b37e-11ea-b3de-0242ac130004"), "Others", "Others" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("baf5d1e6-b37e-11ea-b3de-0242ac130004"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("baf5d2e6-b37e-11ea-b3de-0242ac130004"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("baf5d3e6-b37e-11ea-b3de-0242ac130004"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("baf5cfac-b37e-11ea-b3de-0242ac130004"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("baf5dfac-b37e-11ea-b3de-0242ac130004"));
        }
    }
}
