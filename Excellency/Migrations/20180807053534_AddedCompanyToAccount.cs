using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Excellency.Migrations
{
    public partial class AddedCompanyToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BranchId",
                table: "Accounts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CompanyId",
                table: "Accounts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_DepartmentId",
                table: "Accounts",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PositionId",
                table: "Accounts",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Branches_BranchId",
                table: "Accounts",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Companies_CompanyId",
                table: "Accounts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Departments_DepartmentId",
                table: "Accounts",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Positions_PositionId",
                table: "Accounts",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Branches_BranchId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Companies_CompanyId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Departments_DepartmentId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Positions_PositionId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_BranchId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CompanyId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_DepartmentId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_PositionId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Accounts");
        }
    }
}
