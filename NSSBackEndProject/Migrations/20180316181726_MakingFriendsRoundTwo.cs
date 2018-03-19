using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NSSBackEndProject.Migrations
{
    public partial class MakingFriendsRoundTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FanFictionEssay",
                table: "FanFiction",
                newName: "FileURL");

            migrationBuilder.AlterColumn<string>(
                name: "BookTitle",
                table: "FanFiction",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileURL",
                table: "FanFiction",
                newName: "FanFictionEssay");

            migrationBuilder.AlterColumn<int>(
                name: "BookTitle",
                table: "FanFiction",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
