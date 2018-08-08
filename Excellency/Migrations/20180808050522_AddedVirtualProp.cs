using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Excellency.Migrations
{
    public partial class AddedVirtualProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
