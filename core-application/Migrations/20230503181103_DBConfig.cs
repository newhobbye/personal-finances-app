using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace core_application.Migrations
{
    /// <inheritdoc />
    public partial class DBConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<int>(type: "INTEGER", nullable: false),
                    Balance = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDepositCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDepositCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserExpenseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExpenseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OldBalances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OldBalanceValue = table.Column<double>(type: "REAL", nullable: false),
                    AccountId1 = table.Column<Guid>(type: "TEXT", nullable: false),
                    BalanceDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OldBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OldBalances_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OldBalances_Accounts_AccountId1",
                        column: x => x.AccountId1,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    UserCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposits_UserDepositCategories_UserCategoryId",
                        column: x => x.UserCategoryId,
                        principalTable: "UserDepositCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    UserCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_UserExpenseCategories_UserCategoryId",
                        column: x => x.UserCategoryId,
                        principalTable: "UserExpenseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_UserCategoryId",
                table: "Deposits",
                column: "UserCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserCategoryId",
                table: "Expenses",
                column: "UserCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OldBalances_AccountId",
                table: "OldBalances",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OldBalances_AccountId1",
                table: "OldBalances",
                column: "AccountId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "OldBalances");

            migrationBuilder.DropTable(
                name: "UserDepositCategories");

            migrationBuilder.DropTable(
                name: "UserExpenseCategories");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
