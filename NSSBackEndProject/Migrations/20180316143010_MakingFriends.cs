using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NSSBackEndProject.Migrations
{
    public partial class MakingFriends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FanFiction_Book_BookId",
                table: "FanFiction");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "FanFiction",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BookTitle",
                table: "FanFiction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_FanFiction_Book_BookId",
                table: "FanFiction",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FanFiction_Book_BookId",
                table: "FanFiction");

            migrationBuilder.DropColumn(
                name: "BookTitle",
                table: "FanFiction");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "FanFiction",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FanFiction_Book_BookId",
                table: "FanFiction",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
