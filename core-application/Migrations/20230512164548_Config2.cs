using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace core_application.Migrations
{
    /// <inheritdoc />
    public partial class Config2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_UserDepositCategories_UserCategoryId",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_UserExpenseCategories_UserCategoryId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_UserCategoryId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Deposits_UserCategoryId",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "UserCategoryId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "UserCategoryId",
                table: "Deposits");

            migrationBuilder.AddColumn<Guid>(
                name: "ExpenseId",
                table: "UserExpenseCategories",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DepositId",
                table: "UserDepositCategories",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserExpenseCategories_ExpenseId",
                table: "UserExpenseCategories",
                column: "ExpenseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDepositCategories_DepositId",
                table: "UserDepositCategories",
                column: "DepositId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDepositCategories_Deposits_DepositId",
                table: "UserDepositCategories",
                column: "DepositId",
                principalTable: "Deposits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExpenseCategories_Expenses_ExpenseId",
                table: "UserExpenseCategories",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDepositCategories_Deposits_DepositId",
                table: "UserDepositCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExpenseCategories_Expenses_ExpenseId",
                table: "UserExpenseCategories");

            migrationBuilder.DropIndex(
                name: "IX_UserExpenseCategories_ExpenseId",
                table: "UserExpenseCategories");

            migrationBuilder.DropIndex(
                name: "IX_UserDepositCategories_DepositId",
                table: "UserDepositCategories");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "UserExpenseCategories");

            migrationBuilder.DropColumn(
                name: "DepositId",
                table: "UserDepositCategories");

            migrationBuilder.AddColumn<int>(
                name: "UserCategoryId",
                table: "Expenses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCategoryId",
                table: "Deposits",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserCategoryId",
                table: "Expenses",
                column: "UserCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_UserCategoryId",
                table: "Deposits",
                column: "UserCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_UserDepositCategories_UserCategoryId",
                table: "Deposits",
                column: "UserCategoryId",
                principalTable: "UserDepositCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_UserExpenseCategories_UserCategoryId",
                table: "Expenses",
                column: "UserCategoryId",
                principalTable: "UserExpenseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
