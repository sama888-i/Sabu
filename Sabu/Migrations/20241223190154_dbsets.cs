using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sabu.Migrations
{
    /// <inheritdoc />
    public partial class dbsets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannedWord_Word_WordId",
                table: "BannedWord");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Languages_LanguageCode",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Word_Languages_LanguageCode",
                table: "Word");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Word",
                table: "Word");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BannedWord",
                table: "BannedWord");

            migrationBuilder.RenameTable(
                name: "Word",
                newName: "Words");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameTable(
                name: "BannedWord",
                newName: "BannedWords");

            migrationBuilder.RenameIndex(
                name: "IX_Word_LanguageCode",
                table: "Words",
                newName: "IX_Words_LanguageCode");

            migrationBuilder.RenameIndex(
                name: "IX_Game_LanguageCode",
                table: "Games",
                newName: "IX_Games_LanguageCode");

            migrationBuilder.RenameIndex(
                name: "IX_BannedWord_WordId",
                table: "BannedWords",
                newName: "IX_BannedWords_WordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Words",
                table: "Words",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BannedWords",
                table: "BannedWords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BannedWords_Words_WordId",
                table: "BannedWords",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Languages_LanguageCode",
                table: "Games",
                column: "LanguageCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Languages_LanguageCode",
                table: "Words",
                column: "LanguageCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannedWords_Words_WordId",
                table: "BannedWords");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Languages_LanguageCode",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Languages_LanguageCode",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Words",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BannedWords",
                table: "BannedWords");

            migrationBuilder.RenameTable(
                name: "Words",
                newName: "Word");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameTable(
                name: "BannedWords",
                newName: "BannedWord");

            migrationBuilder.RenameIndex(
                name: "IX_Words_LanguageCode",
                table: "Word",
                newName: "IX_Word_LanguageCode");

            migrationBuilder.RenameIndex(
                name: "IX_Games_LanguageCode",
                table: "Game",
                newName: "IX_Game_LanguageCode");

            migrationBuilder.RenameIndex(
                name: "IX_BannedWords_WordId",
                table: "BannedWord",
                newName: "IX_BannedWord_WordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Word",
                table: "Word",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BannedWord",
                table: "BannedWord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BannedWord_Word_WordId",
                table: "BannedWord",
                column: "WordId",
                principalTable: "Word",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Languages_LanguageCode",
                table: "Game",
                column: "LanguageCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Word_Languages_LanguageCode",
                table: "Word",
                column: "LanguageCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
