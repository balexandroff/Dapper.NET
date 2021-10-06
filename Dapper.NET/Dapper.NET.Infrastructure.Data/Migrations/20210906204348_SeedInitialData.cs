using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dapper.NET.Infrastructure.Data.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                                { new Guid("5cd26786-63bc-404e-bbdb-c7c72496499a"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States" },
                                { new Guid("2c4cd64b-1a82-4f47-a282-f4ff3b2223b4"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Germany" },
                                { new Guid("457c8adb-ba18-4ac9-b3ac-9d5b534b849c"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Netherlands" },
                                { new Guid("6fa36d7d-82e8-4ab3-9027-751f9d6cfe5b"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("5cd26786-63bc-404e-bbdb-c7c72496499a"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States" },
                    { new Guid("2c4cd64b-1a82-4f47-a282-f4ff3b2223b4"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Germany" },
                    { new Guid("457c8adb-ba18-4ac9-b3ac-9d5b534b849c"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Netherlands" },
                    { new Guid("6fa36d7d-82e8-4ab3-9027-751f9d6cfe5b"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" }
                });

            migrationBuilder.InsertData(
                table: "Investments",
                columns: new[] { "Id", "CreatedDate", "CurrentPrice", "ModifiedDate", "PurchaseDate", "PurchasePrice", "StockId" },
                values: new object[,]
                {
                    { new Guid("150376c1-6de4-4e7f-bbf9-7204a0e5f244"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 739m, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 719m, new Guid("6ef6471a-8962-453b-a9f8-a24e8293f657") },
                    { new Guid("ff68a44d-a103-41a0-a1c9-5fb84180c187"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120m, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 103m, new Guid("8ba5fbd5-eca4-4d2c-8fd8-c4ee135db2c6") },
                    { new Guid("6b98c637-7f15-4a97-af1f-5a984203afed"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, new Guid("17141c4b-df47-4130-9810-45d6cce7d360") }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CountryId", "CreatedDate", "Description", "ModifiedDate", "Name", "Ticker" },
                values: new object[] { new Guid("6ef6471a-8962-453b-a9f8-a24e8293f657"), new Guid("5cd26786-63bc-404e-bbdb-c7c72496499a"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tesla, Inc. is an American electric vehicle and clean energy company based in Palo Alto, California, United States. Tesla designs and manufactures electric cars, battery energy storage from home to grid-scale, solar panels and solar roof tiles, and related products and services.", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tesla", "TSLA" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CountryId", "CreatedDate", "Description", "ModifiedDate", "Name", "Ticker" },
                values: new object[] { new Guid("8ba5fbd5-eca4-4d2c-8fd8-c4ee135db2c6"), new Guid("5cd26786-63bc-404e-bbdb-c7c72496499a"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple Inc. is an American multinational technology company that specializes in consumer electronics, computer software, and online services. Apple is the world's largest technology company by revenue and, since January 2021, the world's most valuable company.", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple Inc.", "AAPL" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CountryId", "CreatedDate", "Description", "ModifiedDate", "Name", "Ticker" },
                values: new object[] { new Guid("17141c4b-df47-4130-9810-45d6cce7d360"), new Guid("2c4cd64b-1a82-4f47-a282-f4ff3b2223b4"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deutsche Telekom AG is a German telecommunications company headquartered in Bonn and by revenue the largest telecommunications provider in Europe. Deutsche Telekom was formed in 1995, as the former state-owned monopoly Deutsche Bundespost was privatised.", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deutsche Telekom", "DTE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("457c8adb-ba18-4ac9-b3ac-9d5b534b849c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6fa36d7d-82e8-4ab3-9027-751f9d6cfe5b"));

            migrationBuilder.DeleteData(
                table: "Investments",
                keyColumn: "Id",
                keyValue: new Guid("150376c1-6de4-4e7f-bbf9-7204a0e5f244"));

            migrationBuilder.DeleteData(
                table: "Investments",
                keyColumn: "Id",
                keyValue: new Guid("6b98c637-7f15-4a97-af1f-5a984203afed"));

            migrationBuilder.DeleteData(
                table: "Investments",
                keyColumn: "Id",
                keyValue: new Guid("ff68a44d-a103-41a0-a1c9-5fb84180c187"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("17141c4b-df47-4130-9810-45d6cce7d360"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("6ef6471a-8962-453b-a9f8-a24e8293f657"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("8ba5fbd5-eca4-4d2c-8fd8-c4ee135db2c6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2c4cd64b-1a82-4f47-a282-f4ff3b2223b4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5cd26786-63bc-404e-bbdb-c7c72496499a"));
        }
    }
}
