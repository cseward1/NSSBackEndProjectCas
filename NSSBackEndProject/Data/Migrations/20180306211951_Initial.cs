using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NSSBackEndProject.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(nullable: false),
                    BookImage = table.Column<string>(nullable: false),
                    BookTitle = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Genre = table.Column<string>(nullable: false),
                    Hashtags = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "FanFiction",
                columns: table => new
                {
                    FanFictionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovalRating = table.Column<bool>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: false),
                    FanFictionEssay = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FanFiction", x => x.FanFictionId);
                    table.ForeignKey(
                        name: "FK_FanFiction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friendship",
                columns: table => new
                {
                    FriendshipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FriendshipStatus = table.Column<bool>(nullable: false),
                    UserRecieverId = table.Column<string>(nullable: false),
                    UserSenderId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendship", x => x.FriendshipId);
                    table.ForeignKey(
                        name: "FK_Friendship_AspNetUsers_UserRecieverId",
                        column: x => x.UserRecieverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friendship_AspNetUsers_UserSenderId",
                        column: x => x.UserSenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizAnswers",
                columns: table => new
                {
                    QuizAnswersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answers = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizAnswers", x => x.QuizAnswersId);
                    table.ForeignKey(
                        name: "FK_QuizAnswers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    QuizQuestionsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Questions = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => x.QuizQuestionsId);
                });

            migrationBuilder.CreateTable(
                name: "BookQuiz",
                columns: table => new
                {
                    BookQuizId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    QuizAnswers = table.Column<string>(nullable: false),
                    QuizQuestions = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookQuiz", x => x.BookQuizId);
                    table.ForeignKey(
                        name: "FK_BookQuiz_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookQuiz_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookShelf",
                columns: table => new
                {
                    BookShelfId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookShelf", x => x.BookShelfId);
                    table.ForeignKey(
                        name: "FK_BookShelf_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookShelf_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recommendations",
                columns: table => new
                {
                    RecommendationsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: false),
                    UserRecieverId = table.Column<string>(nullable: false),
                    UserSenderId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendations", x => x.RecommendationsId);
                    table.ForeignKey(
                        name: "FK_Recommendations_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recommendations_AspNetUsers_UserRecieverId",
                        column: x => x.UserRecieverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recommendations_AspNetUsers_UserSenderId",
                        column: x => x.UserSenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookQuiz_BookId",
                table: "BookQuiz",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookQuiz_UserId",
                table: "BookQuiz",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookShelf_BookId",
                table: "BookShelf",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookShelf_UserId",
                table: "BookShelf",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FanFiction_UserId",
                table: "FanFiction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendship_UserRecieverId",
                table: "Friendship",
                column: "UserRecieverId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendship_UserSenderId",
                table: "Friendship",
                column: "UserSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswers_UserId",
                table: "QuizAnswers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_BookId",
                table: "Recommendations",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_UserRecieverId",
                table: "Recommendations",
                column: "UserRecieverId");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_UserSenderId",
                table: "Recommendations",
                column: "UserSenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookQuiz");

            migrationBuilder.DropTable(
                name: "BookShelf");

            migrationBuilder.DropTable(
                name: "FanFiction");

            migrationBuilder.DropTable(
                name: "Friendship");

            migrationBuilder.DropTable(
                name: "QuizAnswers");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "Recommendations");

            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
