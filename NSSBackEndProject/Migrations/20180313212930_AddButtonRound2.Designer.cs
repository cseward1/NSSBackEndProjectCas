﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NSSBackEndProject.Data;
using System;

namespace NSSBackEndProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180313212930_AddButtonRound2")]
    partial class AddButtonRound2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("NSSBackEndProject.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ReadingInterests")
                        .IsRequired();

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("NSSBackEndProject.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApiId")
                        .IsRequired();

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("BookImage")
                        .IsRequired();

                    b.Property<string>("BookTitle")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("BookId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("NSSBackEndProject.Models.BookQuiz", b =>
                {
                    b.Property<int>("BookQuizId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<string>("QuizAnswers")
                        .IsRequired();

                    b.Property<string>("QuizQuestions")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("BookQuizId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookQuiz");
                });

            modelBuilder.Entity("NSSBackEndProject.Models.BookShelf", b =>
                {
                    b.Property<int>("BookShelfId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<int>("BookId");

                    b.Property<string>("BookImage")
                        .IsRequired();

                    b.Property<string>("BookTitle")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("BookShelfId");

                    b.HasIndex("UserId");

                    b.ToTable("BookShelf");
                });

            modelBuilder.Entity("NSSBackEndProject.Models.BookUser", b =>
                {
                    b.Property<int>("BookUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<bool>("Favorited");

                    b.Property<string>("Genre");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<bool>("Watched");

                    b.HasKey("BookUserId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookUser");
                });

            modelBuilder.Entity("NSSBackEndProject.Models.FanFiction", b =>
                {
                    b.Property<int>("FanFictionId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ApprovalRating");

                    b.Property<int>("BookId");

                    b.Property<string>("Comments")
                        .IsRequired();

                    b.Property<string>("EssayTitle")
                        .IsRequired();

                    b.Property<string>("FanFictionEssay")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("FanFictionId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("FanFiction");
                });

            modelBuilder.Entity("NSSBackEndProject.Models.Friendship", b =>
                {
                    b.Property<int>("FriendshipId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("FriendshipStatus");

                    b.Property<string>("UserRecieverId")
                        .IsRequired();

                    b.Property<string>("UserSenderId")
                        .IsRequired();

                    b.HasKey("FriendshipId");

                    b.HasIndex("UserRecieverId");

                    b.HasIndex("UserSenderId");

                    b.ToTable("Friendship");
                });

            modelBuilder.Entity("NSSBackEndProject.Models.QuizAnswers", b =>
                {
                    b.Property<int>("QuizAnswersId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answers")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("QuizAnswersId");

                    b.HasIndex("UserId");

                    b.ToTable("QuizAnswers");
                });

            modelBuilder.Entity("NSSBackEndProject.Models.QuizQuestions", b =>
                {
                    b.Property<int>("QuizQuestionsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Questions")
                        .IsRequired();

                    b.HasKey("QuizQuestionsId");

                    b.ToTable("QuizQuestions");
                });

            modelBuilder.Entity("NSSBackEndProject.Models.Recommendations", b =>
                {
                    b.Property<int>("RecommendationsId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<string>("Note")
                        .IsRequired();

                    b.Property<string>("UserRecieverId")
                        .IsRequired();

                    b.Property<string>("UserSenderId")
                        .IsRequired();

                    b.HasKey("RecommendationsId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserRecieverId");

                    b.HasIndex("UserSenderId");

                    b.ToTable("Recommendations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NSSBackEndProject.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NSSBackEndProject.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NSSBackEndProject.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("NSSBackEndProject.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NSSBackEndProject.Models.BookQuiz", b =>
                {
                    b.HasOne("NSSBackEndProject.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NSSBackEndProject.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NSSBackEndProject.Models.BookShelf", b =>
                {
                    b.HasOne("NSSBackEndProject.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NSSBackEndProject.Models.BookUser", b =>
                {
                    b.HasOne("NSSBackEndProject.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NSSBackEndProject.Models.ApplicationUser", "User")
                        .WithMany("BookUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NSSBackEndProject.Models.FanFiction", b =>
                {
                    b.HasOne("NSSBackEndProject.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NSSBackEndProject.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NSSBackEndProject.Models.Friendship", b =>
                {
                    b.HasOne("NSSBackEndProject.Models.ApplicationUser", "UserReciever")
                        .WithMany()
                        .HasForeignKey("UserRecieverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NSSBackEndProject.Models.ApplicationUser", "UserSender")
                        .WithMany()
                        .HasForeignKey("UserSenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NSSBackEndProject.Models.QuizAnswers", b =>
                {
                    b.HasOne("NSSBackEndProject.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NSSBackEndProject.Models.Recommendations", b =>
                {
                    b.HasOne("NSSBackEndProject.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NSSBackEndProject.Models.ApplicationUser", "UserReciever")
                        .WithMany()
                        .HasForeignKey("UserRecieverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NSSBackEndProject.Models.ApplicationUser", "UserSender")
                        .WithMany()
                        .HasForeignKey("UserSenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
