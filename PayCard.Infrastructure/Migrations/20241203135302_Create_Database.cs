using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "banking");

            migrationBuilder.EnsureSchema(
                name: "users");

            migrationBuilder.CreateTable(
                name: "countries",
                schema: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    iso_3166_code = table.Column<string>(type: "Varchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                schema: "banking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iso_4217_code = table.Column<string>(type: "Varchar(3)", maxLength: 3, nullable: false),
                    name = table.Column<string>(type: "Varchar(128)", maxLength: 128, nullable: false),
                    symbol = table.Column<string>(type: "Char(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "genders",
                schema: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "Varchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transaction_statuses",
                schema: "banking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "Varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction_statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transaction_types",
                schema: "banking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                schema: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country_id = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "Nvarchar(80)", maxLength: 80, nullable: false),
                    address_line_1 = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: false),
                    address_line_2 = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: true),
                    district = table.Column<string>(type: "Nvarchar(45)", maxLength: 45, nullable: true),
                    postal_code = table.Column<string>(type: "Nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adresses_countries_country_id",
                        column: x => x.country_id,
                        principalSchema: "users",
                        principalTable: "countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personal_information",
                schema: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "Nvarchar(81)", maxLength: 81, nullable: false),
                    gender_id = table.Column<int>(type: "int", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "Date", nullable: false),
                    address_id = table.Column<int>(type: "int", nullable: false),
                    email_address = table.Column<string>(type: "Varchar(320)", maxLength: 320, nullable: false),
                    phone_number = table.Column<string>(type: "Varchar(17)", maxLength: 17, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal_information", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personal_information_addresses_address_id",
                        column: x => x.address_id,
                        principalSchema: "users",
                        principalTable: "addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personal_information_genders_gender_id",
                        column: x => x.gender_id,
                        principalSchema: "users",
                        principalTable: "genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                schema: "banking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personal_information_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "Nvarchar(140)", maxLength: 140, nullable: true),
                    balance = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    currency_id = table.Column<int>(type: "int", nullable: false),
                    iban = table.Column<string>(type: "Varchar(256)", maxLength: 256, nullable: false),
                    swift_or_bic = table.Column<string>(type: "Varchar(11)", maxLength: 11, nullable: false),
                    bank_name = table.Column<string>(type: "Nvarchar(60)", maxLength: 60, nullable: false),
                    daily_transaction_limit = table.Column<int>(type: "int", nullable: false),
                    weekly_transaction_limit = table.Column<int>(type: "int", nullable: false),
                    monthly_transaction_limit = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "Bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accounts_currencies_currency_id",
                        column: x => x.currency_id,
                        principalSchema: "banking",
                        principalTable: "currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_accounts_personal_information_personal_information_id",
                        column: x => x.personal_information_id,
                        principalSchema: "users",
                        principalTable: "personal_information",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                schema: "banking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transaction_type_id = table.Column<int>(type: "Int", nullable: false),
                    amount = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    date = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    currency_id = table.Column<int>(type: "Int", nullable: false),
                    source_account_id = table.Column<int>(type: "Int", nullable: false),
                    destination_account_id = table.Column<int>(type: "Int", nullable: false),
                    transaction_status_id = table.Column<int>(type: "Int", nullable: false),
                    note = table.Column<string>(type: "Nvarchar(256)", maxLength: 256, nullable: true),
                    exchange_rate = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    fee = table.Column<decimal>(type: "Decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_accounts_account_id",
                        column: x => x.source_account_id,
                        principalSchema: "banking",
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transactions_accounts_destination_account_id",
                        column: x => x.destination_account_id,
                        principalSchema: "banking",
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_currencies_currency_id",
                        column: x => x.currency_id,
                        principalSchema: "banking",
                        principalTable: "currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transactions_transaction_statuses_transaction_status_id",
                        column: x => x.transaction_status_id,
                        principalSchema: "banking",
                        principalTable: "transaction_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transactions_transaction_types_transaction_type_id",
                        column: x => x.transaction_type_id,
                        principalSchema: "banking",
                        principalTable: "transaction_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_currency_id",
                schema: "banking",
                table: "accounts",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_personal_information_id",
                schema: "banking",
                table: "accounts",
                column: "personal_information_id");

            migrationBuilder.CreateIndex(
                name: "UQ_accounts_iban",
                schema: "banking",
                table: "accounts",
                column: "iban",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_addresses_country_id",
                schema: "users",
                table: "addresses",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "UQ_countries_iso_3166_code_name",
                schema: "users",
                table: "countries",
                columns: new[] { "iso_3166_code", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_currencies_iso_4217_code_name",
                schema: "banking",
                table: "currencies",
                columns: new[] { "iso_4217_code", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_genders_type",
                schema: "users",
                table: "genders",
                column: "type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_personal_information_address_id",
                schema: "users",
                table: "personal_information",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_personal_information_gender_id",
                schema: "users",
                table: "personal_information",
                column: "gender_id");

            migrationBuilder.CreateIndex(
                name: "UQ_personal_information_email_address_phone_number",
                schema: "users",
                table: "personal_information",
                columns: new[] { "email_address", "phone_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_transaction_statuses_status",
                schema: "banking",
                table: "transaction_statuses",
                column: "status",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_transaction_types_type",
                schema: "banking",
                table: "transaction_types",
                column: "type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_transactions_currency_id",
                schema: "banking",
                table: "transactions",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_destination_account_id",
                schema: "banking",
                table: "transactions",
                column: "destination_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_source_account_id",
                schema: "banking",
                table: "transactions",
                column: "source_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_transaction_status_id",
                schema: "banking",
                table: "transactions",
                column: "transaction_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_transaction_type_id",
                schema: "banking",
                table: "transactions",
                column: "transaction_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions",
                schema: "banking");

            migrationBuilder.DropTable(
                name: "accounts",
                schema: "banking");

            migrationBuilder.DropTable(
                name: "transaction_statuses",
                schema: "banking");

            migrationBuilder.DropTable(
                name: "transaction_types",
                schema: "banking");

            migrationBuilder.DropTable(
                name: "currencies",
                schema: "banking");

            migrationBuilder.DropTable(
                name: "personal_information",
                schema: "users");

            migrationBuilder.DropTable(
                name: "addresses",
                schema: "users");

            migrationBuilder.DropTable(
                name: "genders",
                schema: "users");

            migrationBuilder.DropTable(
                name: "countries",
                schema: "users");
        }
    }
}
