tusing Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NSSBackEndProject.Migrations
{
    public partial class FixFanFiction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FanFiction_Book_BookId",
                table: "FanFiction");

            migrationBuilder.DropIndex(
                name: "IX_FanFiction_BookId",
                table: "FanFiction");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "FanFiction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "FanFiction",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FanFiction_BookId",
                table: "FanFiction",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_FanFiction_Book_BookId",
                table: "FanFiction",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
