using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeedMarketData.Migrations
{
    public partial class firstLoadOfModelsInDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "Statuses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "ProductPhotos",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductGroupBaseName",
                table: "ProductGroups",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ProductGroups",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "ApplicationUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserName",
                table: "ApplicationUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationRoleId",
                table: "ApplicationUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ApplicationRoles",
                columns: table => new
                {
                    ApplicationRoleId = table.Column<Guid>(nullable: false),
                    RoleName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoles", x => x.ApplicationRoleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroups_ProductId",
                table: "ProductGroups",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_ApplicationRoleId",
                table: "ApplicationUsers",
                column: "ApplicationRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_ApplicationRoles_ApplicationRoleId",
                table: "ApplicationUsers",
                column: "ApplicationRoleId",
                principalTable: "ApplicationRoles",
                principalColumn: "ApplicationRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroups_Products_ProductId",
                table: "ProductGroups",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_ApplicationRoles_ApplicationRoleId",
                table: "ApplicationUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroups_Products_ProductId",
                table: "ProductGroups");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropIndex(
                name: "IX_ProductGroups_ProductId",
                table: "ProductGroups");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_ApplicationRoleId",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "ProductPhotos",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductGroups");

            migrationBuilder.DropColumn(
                name: "ApplicationRoleId",
                table: "ApplicationUsers");

            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "Statuses",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProductGroupBaseName",
                table: "ProductGroups",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "ApplicationUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserName",
                table: "ApplicationUsers",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
