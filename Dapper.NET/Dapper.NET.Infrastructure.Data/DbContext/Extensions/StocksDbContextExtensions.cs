using Dapper.NET.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dapper.NET.Infrastructure.Data
{
    public static class StocksDbContextExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = Guid.Parse("5CD26786-63BC-404E-BBDB-C7C72496499A"),
                    Name = "United States",
                    CreatedDate = new DateTime(2021, 01, 01),
                    ModifiedDate = new DateTime(2021, 01, 01),
                },
                new Country
                {
                    Id = Guid.Parse("2C4CD64B-1A82-4F47-A282-F4FF3B2223B4"),
                    Name = "Germany",
                    CreatedDate = new DateTime(2021, 01, 01),
                    ModifiedDate = new DateTime(2021, 01, 01),
                },
                new Country
                {
                    Id = Guid.Parse("457C8ADB-BA18-4AC9-B3AC-9D5B534B849C"),
                    Name = "Netherlands",
                    CreatedDate = new DateTime(2021, 01, 01),
                    ModifiedDate = new DateTime(2021, 01, 01),
                },
                new Country
                {
                    Id = Guid.Parse("6FA36D7D-82E8-4AB3-9027-751F9D6CFE5B"),
                    Name = "United Kingdom",
                    CreatedDate = new DateTime(2021, 01, 01),
                    ModifiedDate = new DateTime(2021, 01, 01),
                }
            );

            modelBuilder.Entity<Stock>().HasData(
                new Stock
                {
                    Id = Guid.Parse("6EF6471A-8962-453B-A9F8-A24E8293F657"),
                    Name = "Tesla",
                    Ticker = "TSLA",
                    CountryId = Guid.Parse("5CD26786-63BC-404E-BBDB-C7C72496499A"),
                    Description = "Tesla, Inc. is an American electric vehicle and clean energy company based in Palo Alto, California, United States. Tesla designs and manufactures electric cars, battery energy storage from home to grid-scale, solar panels and solar roof tiles, and related products and services.",
                    CreatedDate = new DateTime(2021, 01, 01),
                    ModifiedDate = new DateTime(2021, 01, 01),
                },
                new Stock
                {
                    Id = Guid.Parse("8BA5FBD5-ECA4-4D2C-8FD8-C4EE135DB2C6"),
                    Name = "Apple Inc.",
                    Ticker = "AAPL",
                    CountryId = Guid.Parse("5CD26786-63BC-404E-BBDB-C7C72496499A"),
                    Description = "Apple Inc. is an American multinational technology company that specializes in consumer electronics, computer software, and online services. Apple is the world's largest technology company by revenue and, since January 2021, the world's most valuable company.",
                    CreatedDate = new DateTime(2021, 01, 01),
                    ModifiedDate = new DateTime(2021, 01, 01),
                },
                new Stock
                {
                    Id = Guid.Parse("17141C4B-DF47-4130-9810-45D6CCE7D360"),
                    Name = "Deutsche Telekom",
                    Ticker = "DTE",
                    CountryId = Guid.Parse("2C4CD64B-1A82-4F47-A282-F4FF3B2223B4"),
                    Description = "Deutsche Telekom AG is a German telecommunications company headquartered in Bonn and by revenue the largest telecommunications provider in Europe. Deutsche Telekom was formed in 1995, as the former state-owned monopoly Deutsche Bundespost was privatised.",
                    CreatedDate = new DateTime(2021, 01, 01),
                    ModifiedDate = new DateTime(2021, 01, 01),
                }
            );

            modelBuilder.Entity<Investment>().HasData(
                new Investment
                {
                    Id = Guid.Parse("150376C1-6DE4-4E7F-BBF9-7204A0E5F244"),
                    StockId = Guid.Parse("6EF6471A-8962-453B-A9F8-A24E8293F657"),
                    PurchasePrice = 719,
                    CurrentPrice = 739,
                    PurchaseDate = new DateTime(2021, 01, 01),
                    CreatedDate = new DateTime(2021, 01, 01),
                    ModifiedDate = new DateTime(2021, 01, 01),
                },
                new Investment
                {
                    Id = Guid.Parse("FF68A44D-A103-41A0-A1C9-5FB84180C187"),
                    StockId = Guid.Parse("8BA5FBD5-ECA4-4D2C-8FD8-C4EE135DB2C6"),
                    PurchasePrice = 103,
                    CurrentPrice = 120,
                    PurchaseDate = new DateTime(2021, 01, 01),
                    CreatedDate = new DateTime(2021, 01, 01),
                    ModifiedDate = new DateTime(2021, 01, 01),
                },
                new Investment
                {
                    Id = Guid.Parse("6B98C637-7F15-4A97-AF1F-5A984203AFED"),
                    StockId = Guid.Parse("17141C4B-DF47-4130-9810-45D6CCE7D360"),
                    CreatedDate = new DateTime(2021, 01, 01),
                    ModifiedDate = new DateTime(2021, 01, 01),
                }
            );
        }

        public static void IdentitySeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "F0E12839-4C29-4622-98C9-82585C756DBC",
                    UserName = "system@cleanarchitecture.com",
                    NormalizedUserName = "SYSTEM@CLEANARCHITECTURE.COM",
                    Email = "system@cleanarchitecture.com",
                    NormalizedEmail = "SYSTEM@CLEANARCHITECTURE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AEHAOa8JTgCClddiRV02HyKRtiYS38H2+Mk0lnXXlsDmw4DsuIRwxHCxe5DSStIPew==", //Cl3@nArch
                    PhoneNumber = "1234567890",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                }
            );
        }
    }
}
