using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MTS.Migrations
{
    public partial class ChangeForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Clients_Id",
                schema: "Mts",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Costs_Id",
                schema: "Mts",
                table: "Calls");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Mts",
                table: "Calls",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "IdClient",
                schema: "Mts",
                table: "Calls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCost",
                schema: "Mts",
                table: "Calls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Calls_IdClient",
                schema: "Mts",
                table: "Calls",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_IdCost",
                schema: "Mts",
                table: "Calls",
                column: "IdCost");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Clients_IdClient",
                schema: "Mts",
                table: "Calls",
                column: "IdClient",
                principalSchema: "Mts",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Costs_IdCost",
                schema: "Mts",
                table: "Calls",
                column: "IdCost",
                principalSchema: "Mts",
                principalTable: "Costs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Clients_IdClient",
                schema: "Mts",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Costs_IdCost",
                schema: "Mts",
                table: "Calls");

            migrationBuilder.DropIndex(
                name: "IX_Calls_IdClient",
                schema: "Mts",
                table: "Calls");

            migrationBuilder.DropIndex(
                name: "IX_Calls_IdCost",
                schema: "Mts",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "IdClient",
                schema: "Mts",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "IdCost",
                schema: "Mts",
                table: "Calls");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Mts",
                table: "Calls",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Clients_Id",
                schema: "Mts",
                table: "Calls",
                column: "Id",
                principalSchema: "Mts",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Costs_Id",
                schema: "Mts",
                table: "Calls",
                column: "Id",
                principalSchema: "Mts",
                principalTable: "Costs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
