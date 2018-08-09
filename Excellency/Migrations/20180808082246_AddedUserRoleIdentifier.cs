using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Excellency.Migrations
{
    public partial class AddedUserRoleIdentifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleHeaderId",
                table: "UserRoleLine",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleLine_RoleHeaderId",
                table: "UserRoleLine",
                column: "RoleHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleLine_UserRoleHeader_RoleHeaderId",
                table: "UserRoleLine",
                column: "RoleHeaderId",
                principalTable: "UserRoleHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleLine_UserRoleHeader_RoleHeaderId",
                table: "UserRoleLine");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleLine_RoleHeaderId",
                table: "UserRoleLine");

            migrationBuilder.DropColumn(
                name: "RoleHeaderId",
                table: "UserRoleLine");
        }
    }
}
