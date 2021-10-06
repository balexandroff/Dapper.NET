using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dapper.NET.Infrastructure.Data.Migrations.Identity
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "F0E12839-4C29-4622-98C9-82585C756DBC", 0, "bdf321f7-4e5a-4321-9dd5-6c5467b122ca", "system@cleanarchitecture.com", true, true, null, "SYSTEM@CLEANARCHITECTURE.COM", "SYSTEM@CLEANARCHITECTURE.COM", "AEHAOa8JTgCClddiRV02HyKRtiYS38H2+Mk0lnXXlsDmw4DsuIRwxHCxe5DSStIPew==", "1234567890", true, null, false, "system@cleanarchitecture.com" });
        }
    }
}
