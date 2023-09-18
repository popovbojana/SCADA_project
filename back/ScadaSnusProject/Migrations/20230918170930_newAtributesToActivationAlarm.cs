using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScadaSnusProject.Migrations
{
    public partial class newAtributesToActivationAlarm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "AlarmActivations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "AlarmActivations",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_AlarmActivations_TagId",
                table: "AlarmActivations",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlarmActivations_Tags_TagId",
                table: "AlarmActivations",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlarmActivations_Tags_TagId",
                table: "AlarmActivations");

            migrationBuilder.DropIndex(
                name: "IX_AlarmActivations_TagId",
                table: "AlarmActivations");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "AlarmActivations");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "AlarmActivations");
        }
    }
}
