﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Epra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company_types",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "invoice_statuses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "market_activities",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_market_activities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "membership_types",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membership_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_codes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_codes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "titles_internal",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titles_internal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    username = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    vat = table.Column<decimal>(nullable: true),
                    product_code_id = table.Column<int>(nullable: false),
                    email_subject = table.Column<string>(nullable: true),
                    email_banner = table.Column<string>(nullable: true),
                    email_body = table.Column<string>(nullable: true),
                    bottom_notes = table.Column<string>(nullable: true),
                    membership_type_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_membership_types_membership_type_id",
                        column: x => x.membership_type_id,
                        principalTable: "membership_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_products_product_codes_product_code_id",
                        column: x => x.product_code_id,
                        principalTable: "product_codes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    code = table.Column<string>(maxLength: 10, nullable: true),
                    region_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.id);
                    table.ForeignKey(
                        name: "FK_countries_regions_region_id",
                        column: x => x.region_id,
                        principalTable: "regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    email = table.Column<string>(nullable: true),
                    first_name = table.Column<string>(nullable: false),
                    middle_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: false),
                    prefix = table.Column<string>(nullable: true),
                    suffix = table.Column<string>(nullable: true),
                    informal_name = table.Column<string>(nullable: true),
                    title_internal_id = table.Column<int>(nullable: false),
                    title_external = table.Column<string>(nullable: true),
                    phone_direct = table.Column<string>(nullable: true),
                    phone_mobile = table.Column<string>(nullable: true),
                    fax = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    location_of_contact = table.Column<string>(nullable: true),
                    company_id = table.Column<int>(nullable: false),
                    is_main = table.Column<bool>(nullable: false),
                    online = table.Column<bool>(nullable: false),
                    address_id = table.Column<int>(nullable: true),
                    assistant_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.id);
                    table.ForeignKey(
                        name: "FK_contacts_contacts_assistant_id",
                        column: x => x.assistant_id,
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contacts_titles_internal_title_internal_id",
                        column: x => x.title_internal_id,
                        principalTable: "titles_internal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: false),
                    street = table.Column<string>(nullable: false),
                    city = table.Column<string>(nullable: false),
                    country_id = table.Column<int>(nullable: false),
                    zip = table.Column<string>(maxLength: 20, nullable: true),
                    vat_number = table.Column<string>(maxLength: 50, nullable: true),
                    fax = table.Column<string>(maxLength: 50, nullable: true),
                    phone = table.Column<string>(maxLength: 50, nullable: true),
                    is_main = table.Column<bool>(nullable: false),
                    is_nav = table.Column<bool>(nullable: false),
                    is_website = table.Column<bool>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    company_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_addresses_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: false),
                    search_name = table.Column<string>(nullable: true),
                    company_type_id = table.Column<int>(nullable: false),
                    member_index = table.Column<bool>(nullable: false),
                    online = table.Column<bool>(nullable: false),
                    market_activity_id = table.Column<int>(nullable: false),
                    market_second_specialty = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    info = table.Column<string>(nullable: true),
                    unique_stock_code = table.Column<string>(nullable: true),
                    membership_id = table.Column<int>(nullable: true),
                    is_main_member = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.id);
                    table.ForeignKey(
                        name: "FK_companies_company_types_company_type_id",
                        column: x => x.company_type_id,
                        principalTable: "company_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_companies_market_activities_market_activity_id",
                        column: x => x.market_activity_id,
                        principalTable: "market_activities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    product_id = table.Column<int>(nullable: false),
                    membership_id = table.Column<int>(nullable: true),
                    due_date = table.Column<DateTime>(nullable: false),
                    status_id = table.Column<int>(nullable: false),
                    number = table.Column<string>(maxLength: 20, nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    created_date = table.Column<DateTime>(nullable: true),
                    total = table.Column<decimal>(nullable: false),
                    email_sent_date = table.Column<DateTime>(nullable: true),
                    date_paid = table.Column<DateTime>(nullable: true),
                    is_credit = table.Column<bool>(nullable: false),
                    debit_invoice_id = table.Column<int>(nullable: true),
                    debit_invoice_nr = table.Column<string>(nullable: true),
                    email_extra = table.Column<string>(nullable: true),
                    po_nr = table.Column<string>(nullable: true),
                    total_in_different_currency = table.Column<string>(nullable: true),
                    payment_via = table.Column<string>(nullable: true),
                    details = table.Column<string>(nullable: true),
                    vat = table.Column<decimal>(nullable: true),
                    discount = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_invoices_invoices_debit_invoice_id",
                        column: x => x.debit_invoice_id,
                        principalTable: "invoices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_invoices_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_invoices_invoice_statuses_status_id",
                        column: x => x.status_id,
                        principalTable: "invoice_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "memberships",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: false),
                    is_bad_debtor = table.Column<bool>(nullable: false),
                    discount = table.Column<decimal>(nullable: true),
                    total = table.Column<decimal>(nullable: false),
                    comment = table.Column<string>(nullable: true),
                    start_date = table.Column<DateTime>(nullable: true),
                    end_date = table.Column<DateTime>(nullable: true),
                    renewable_date = table.Column<DateTime>(nullable: true),
                    product_id = table.Column<int>(nullable: false),
                    last_invoice_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberships", x => x.id);
                    table.ForeignKey(
                        name: "FK_memberships_invoices_last_invoice_id",
                        column: x => x.last_invoice_id,
                        principalTable: "invoices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_memberships_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    text = table.Column<string>(nullable: false),
                    membership_id = table.Column<int>(nullable: false),
                    author_id = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_comments_users_author_id",
                        column: x => x.author_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_memberships_membership_id",
                        column: x => x.membership_id,
                        principalTable: "memberships",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_company_id",
                table: "addresses",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_country_id",
                table: "addresses",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_author_id",
                table: "comments",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_membership_id",
                table: "comments",
                column: "membership_id");

            migrationBuilder.CreateIndex(
                name: "IX_companies_company_type_id",
                table: "companies",
                column: "company_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_companies_market_activity_id",
                table: "companies",
                column: "market_activity_id");

            migrationBuilder.CreateIndex(
                name: "IX_companies_membership_id",
                table: "companies",
                column: "membership_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_types_name",
                table: "company_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contacts_address_id",
                table: "contacts",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_assistant_id",
                table: "contacts",
                column: "assistant_id");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_company_id",
                table: "contacts",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_email",
                table: "contacts",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_title_internal_id",
                table: "contacts",
                column: "title_internal_id");

            migrationBuilder.CreateIndex(
                name: "IX_countries_name",
                table: "countries",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_countries_region_id",
                table: "countries",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_statuses_name",
                table: "invoice_statuses",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoices_debit_invoice_id",
                table: "invoices",
                column: "debit_invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_membership_id",
                table: "invoices",
                column: "membership_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_number",
                table: "invoices",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoices_product_id",
                table: "invoices",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_status_id",
                table: "invoices",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_market_activities_name",
                table: "market_activities",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_membership_types_name",
                table: "membership_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_memberships_last_invoice_id",
                table: "memberships",
                column: "last_invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_memberships_product_id",
                table: "memberships",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_codes_name",
                table: "product_codes",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_membership_type_id",
                table: "products",
                column: "membership_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_name",
                table: "products",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_product_code_id",
                table: "products",
                column: "product_code_id");

            migrationBuilder.CreateIndex(
                name: "IX_regions_name",
                table: "regions",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_roles_name",
                table: "roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_titles_internal_name",
                table: "titles_internal",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_username",
                table: "users",
                column: "username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_companies_company_id",
                table: "contacts",
                column: "company_id",
                principalTable: "companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_addresses_address_id",
                table: "contacts",
                column: "address_id",
                principalTable: "addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_companies_company_id",
                table: "addresses",
                column: "company_id",
                principalTable: "companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_companies_memberships_membership_id",
                table: "companies",
                column: "membership_id",
                principalTable: "memberships",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_memberships_membership_id",
                table: "invoices",
                column: "membership_id",
                principalTable: "memberships",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoices_memberships_membership_id",
                table: "invoices");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "titles_internal");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "company_types");

            migrationBuilder.DropTable(
                name: "market_activities");

            migrationBuilder.DropTable(
                name: "regions");

            migrationBuilder.DropTable(
                name: "memberships");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "invoice_statuses");

            migrationBuilder.DropTable(
                name: "membership_types");

            migrationBuilder.DropTable(
                name: "product_codes");
        }
    }
}
