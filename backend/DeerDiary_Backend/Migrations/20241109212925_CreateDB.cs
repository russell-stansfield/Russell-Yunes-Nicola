using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DeerDiary_Backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RandomQuestions",
                columns: table => new
                {
                    RandomQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RandomQuestionText = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomQuestions", x => x.RandomQuestionId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TokenBlacklists",
                columns: table => new
                {
                    TokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Token = table.Column<string>(type: "longtext", nullable: false),
                    TokenExpiry = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenBlacklists", x => x.TokenId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "longtext", nullable: false),
                    UserPassword = table.Column<string>(type: "longtext", nullable: false),
                    UserMail = table.Column<string>(type: "longtext", nullable: false),
                    PasswordSalt = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JournalEntries",
                columns: table => new
                {
                    JournalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    JournalDate = table.Column<string>(type: "longtext", nullable: false),
                    JournalText = table.Column<string>(type: "longtext", nullable: false),
                    JournalTitle = table.Column<string>(type: "longtext", nullable: false),
                    fk_RandomQuestionId = table.Column<int>(type: "int", nullable: true),
                    fk_UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntries", x => x.JournalId);
                    table.ForeignKey(
                        name: "FK_JournalEntries_RandomQuestions_fk_RandomQuestionId",
                        column: x => x.fk_RandomQuestionId,
                        principalTable: "RandomQuestions",
                        principalColumn: "RandomQuestionId");
                    table.ForeignKey(
                        name: "FK_JournalEntries_Users_fk_UserId",
                        column: x => x.fk_UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    ReplyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ReplyText = table.Column<string>(type: "longtext", nullable: false),
                    ReplyGeneratedQuestion = table.Column<string>(type: "longtext", nullable: false),
                    fk_JournalEntryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.ReplyId);
                    table.ForeignKey(
                        name: "FK_Replies_JournalEntries_fk_JournalEntryId",
                        column: x => x.fk_JournalEntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "JournalId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_fk_RandomQuestionId",
                table: "JournalEntries",
                column: "fk_RandomQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_fk_UserId",
                table: "JournalEntries",
                column: "fk_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_fk_JournalEntryId",
                table: "Replies",
                column: "fk_JournalEntryId");

            migrationBuilder.InsertData(
        table: "RandomQuestions",
        columns: new[] { "RandomQuestionId", "RandomQuestionText" },
        values: new object[,] { { 1, "What is your favorite memory from childhood?" }, { 2, "If you could travel anywhere, where would you go?" }, { 3, "What is one skill you would like to learn and why?" }, { 4, "Describe a time you faced a challenge and overcame it." }, { 5, "What is your biggest goal for the next year?" }, { 6, "How are you feeling today?" }, {7, "What do you appreciate in your life?" }, { 8, "Is there a thing that makes you smile?" } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "TokenBlacklists");

            migrationBuilder.DropTable(
                name: "JournalEntries");

            migrationBuilder.DropTable(
                name: "RandomQuestions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
