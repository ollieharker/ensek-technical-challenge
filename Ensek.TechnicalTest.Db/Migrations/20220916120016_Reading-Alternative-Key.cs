using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ensek.TechnicalTest.Db.Migrations
{
    public partial class ReadingAlternativeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadings_Accounts_AccountId",
                table: "MeterReadings");

            migrationBuilder.DropIndex(
                name: "IX_MeterReadings_AccountId",
                table: "MeterReadings");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "MeterReadings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadings_AccountId_Value",
                table: "MeterReadings",
                columns: new[] { "AccountId", "Value" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReadings_Accounts_AccountId",
                table: "MeterReadings",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadings_Accounts_AccountId",
                table: "MeterReadings");

            migrationBuilder.DropIndex(
                name: "IX_MeterReadings_AccountId_Value",
                table: "MeterReadings");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "MeterReadings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadings_AccountId",
                table: "MeterReadings",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReadings_Accounts_AccountId",
                table: "MeterReadings",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
