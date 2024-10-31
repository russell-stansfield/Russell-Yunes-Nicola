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
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "longtext", nullable: false),
                    UserPassword = table.Column<string>(type: "longtext", nullable: false),
                    UserMail = table.Column<string>(type: "longtext", nullable: false)
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
                    JournalDate = table.Column<string>(type: "longtext", nullable: true),
                    JournalText = table.Column<string>(type: "longtext", nullable: true),
                    JournalTitle = table.Column<string>(type: "longtext", nullable: true),
                    RandomQuestionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntries", x => x.JournalId);
                    table.ForeignKey(
                        name: "FK_JournalEntries_RandomQuestions_RandomQuestionId",
                        column: x => x.RandomQuestionId,
                        principalTable: "RandomQuestions",
                        principalColumn: "RandomQuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalEntries_Users_UserId",
                        column: x => x.UserId,
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
                    JournalEntryId = table.Column<string>(type: "longtext", nullable: false),
                    _journalentryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.ReplyId);
                    table.ForeignKey(
                        name: "FK_Replies_JournalEntries__journalentryId",
                        column: x => x._journalentryId,
                        principalTable: "JournalEntries",
                        principalColumn: "JournalId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_RandomQuestionId",
                table: "JournalEntries",
                column: "RandomQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_UserId",
                table: "JournalEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies__journalentryId",
                table: "Replies",
                column: "_journalentryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "JournalEntries");

            migrationBuilder.DropTable(
                name: "RandomQuestions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
