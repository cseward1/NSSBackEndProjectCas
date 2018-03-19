using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NSSBackEndProject.Migrations
{
    public partial class AnotherRoundofFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FileURL",
                table: "FanFiction",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FileURL",
                table: "FanFiction",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
