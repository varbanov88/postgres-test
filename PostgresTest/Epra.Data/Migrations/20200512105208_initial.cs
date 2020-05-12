using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Epra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    city = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.id);
                });

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
                name: "memberships",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberships", x => x.id);
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
                name: "companies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: false),
                    search_name = table.Column<string>(nullable: true),
                    company_type_id = table.Column<int>(nullable: false),
                    member_index = table.Column<bool>(nullable: false),
                    market_activity_id = table.Column<int>(nullable: false),
                    market_second_specialty = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    info = table.Column<string>(nullable: true),
                    unique_stock_code = table.Column<string>(nullable: true),
                    address_id = table.Column<int>(nullable: true),
                    membership_id = table.Column<int>(nullable: true),
                    is_main_member = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.id);
                    table.ForeignKey(
                        name: "FK_companies_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_companies_memberships_membership_id",
                        column: x => x.membership_id,
                        principalTable: "memberships",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    email = table.Column<string>(nullable: false),
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
                    address_id = table.Column<int>(nullable: true),
                    assistant_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.id);
                    table.ForeignKey(
                        name: "FK_contacts_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contacts_contacts_assistant_id",
                        column: x => x.assistant_id,
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contacts_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contacts_titles_internal_title_internal_id",
                        column: x => x.title_internal_id,
                        principalTable: "titles_internal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_companies_address_id",
                table: "companies",
                column: "address_id");

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
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contacts_title_internal_id",
                table: "contacts",
                column: "title_internal_id");

            migrationBuilder.CreateIndex(
                name: "IX_market_activities_name",
                table: "market_activities",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "titles_internal");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "company_types");

            migrationBuilder.DropTable(
                name: "market_activities");

            migrationBuilder.DropTable(
                name: "memberships");
        }
    }
}
