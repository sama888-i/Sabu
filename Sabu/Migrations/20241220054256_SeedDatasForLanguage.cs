using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sabu.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatasForLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Languages",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Code", "Icon", "Name" },
                values: new object[] { "az", "https://banner2.cleanpng.com/20180614/ubx/kisspng-flag-of-azerbaijan-stock-photography-flag-of-azerbaijan-5b223219c10062.9993313215289677057906.jpg", "Azərbaycan" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Code",
                keyValue: "az");

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Languages",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800);
        }
    }
}
