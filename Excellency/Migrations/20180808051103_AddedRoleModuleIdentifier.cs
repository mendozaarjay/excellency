using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Excellency.Migrations
{
    public partial class AddedRoleModuleIdentifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleModulesHeader_RoleModulesLine_ModulesLineId",
                table: "RoleModulesHeader");

            migrationBuilder.DropIndex(
                name: "IX_RoleModulesHeader_ModulesLineId",
                table: "RoleModulesHeader");

            migrationBuilder.DropColumn(
                name: "ModulesLineId",
                table: "RoleModulesHeader");

            migrationBuilder.AddColumn<int>(
                name: "RoleModulesHeaderId",
                table: "RoleModulesLine",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleModulesLine_RoleModulesHeaderId",
                table: "RoleModulesLine",
                column: "RoleModulesHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleModulesLine_RoleModulesHeader_RoleModulesHeaderId",
                table: "RoleModulesLine",
                column: "RoleModulesHeaderId",
                principalTable: "RoleModulesHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleModulesLine_RoleModulesHeader_RoleModulesHeaderId",
                table: "RoleModulesLine");

            migrationBuilder.DropIndex(
                name: "IX_RoleModulesLine_RoleModulesHeaderId",
                table: "RoleModulesLine");

            migrationBuilder.DropColumn(
                name: "RoleModulesHeaderId",
                table: "RoleModulesLine");

            migrationBuilder.AddColumn<int>(
                name: "ModulesLineId",
                table: "RoleModulesHeader",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleModulesHeader_ModulesLineId",
                table: "RoleModulesHeader",
                column: "ModulesLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleModulesHeader_RoleModulesLine_ModulesLineId",
                table: "RoleModulesHeader",
                column: "ModulesLineId",
                principalTable: "RoleModulesLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
