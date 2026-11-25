using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Umuhinzi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    category = table.Column<string>(type: "text", nullable: false),
                    unit_of_measurement = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "farms",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    location = table.Column<string>(type: "text", nullable: false),
                    certification_id = table.Column<string>(type: "text", nullable: true),
                    verified = table.Column<bool>(type: "boolean", nullable: false),
                    owned_id = table.Column<long>(type: "bigint", nullable: true),
                    owner_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_farms", x => x.id);
                    table.ForeignKey(
                        name: "fk_farms_users_owner_id",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "audit_reports",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    auditor_name = table.Column<string>(type: "text", nullable: false),
                    audit_date = table.Column<DateOnly>(type: "date", nullable: false),
                    report_url = table.Column<string>(type: "text", nullable: true),
                    passed = table.Column<bool>(type: "boolean", nullable: false),
                    farm_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_reports", x => x.id);
                    table.ForeignKey(
                        name: "fk_audit_reports_farms_farm_id",
                        column: x => x.farm_id,
                        principalTable: "farms",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "batches",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    harvest_date = table.Column<DateOnly>(type: "date", nullable: false),
                    origin_coardinaties = table.Column<string>(type: "text", nullable: true),
                    qr_code_url = table.Column<string>(type: "text", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    farmer_id = table.Column<long>(type: "bigint", nullable: true),
                    farm_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_batches", x => x.id);
                    table.ForeignKey(
                        name: "fk_batches_farms_farm_id",
                        column: x => x.farm_id,
                        principalTable: "farms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_batches_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "certificates",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    issued_organization = table.Column<string>(type: "text", nullable: false),
                    issued_date = table.Column<DateOnly>(type: "date", nullable: false),
                    expiry_date = table.Column<DateOnly>(type: "date", nullable: false),
                    document_url = table.Column<string>(type: "text", nullable: true),
                    farm_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_certificates", x => x.id);
                    table.ForeignKey(
                        name: "fk_certificates_farms_farm_id",
                        column: x => x.farm_id,
                        principalTable: "farms",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "harvest_records",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    harvest_date = table.Column<DateOnly>(type: "date", nullable: false),
                    yield_amount = table.Column<double>(type: "double precision", nullable: false),
                    method = table.Column<string>(type: "text", nullable: false),
                    batch_id = table.Column<long>(type: "bigint", nullable: true),
                    batch_id1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_harvest_records", x => x.id);
                    table.ForeignKey(
                        name: "fk_harvest_records_batches_batch_id1",
                        column: x => x.batch_id1,
                        principalTable: "batches",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "practice_records",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    practice_type = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    date_applied = table.Column<DateOnly>(type: "date", nullable: false),
                    batch_id = table.Column<long>(type: "bigint", nullable: true),
                    batch_id1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_practice_records", x => x.id);
                    table.ForeignKey(
                        name: "fk_practice_records_batches_batch_id1",
                        column: x => x.batch_id1,
                        principalTable: "batches",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "transport_logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    shipped_at = table.Column<DateOnly>(type: "date", nullable: false),
                    received_at = table.Column<DateOnly>(type: "date", nullable: true),
                    origin = table.Column<string>(type: "text", nullable: false),
                    destination = table.Column<string>(type: "text", nullable: false),
                    transporter = table.Column<string>(type: "text", nullable: false),
                    batch_id = table.Column<long>(type: "bigint", nullable: true),
                    batch_id1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transport_logs", x => x.id);
                    table.ForeignKey(
                        name: "fk_transport_logs_batches_batch_id1",
                        column: x => x.batch_id1,
                        principalTable: "batches",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_audit_reports_farm_id",
                table: "audit_reports",
                column: "farm_id");

            migrationBuilder.CreateIndex(
                name: "ix_batches_farm_id",
                table: "batches",
                column: "farm_id");

            migrationBuilder.CreateIndex(
                name: "ix_batches_product_id",
                table: "batches",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_certificates_farm_id",
                table: "certificates",
                column: "farm_id");

            migrationBuilder.CreateIndex(
                name: "ix_farms_owner_id",
                table: "farms",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_harvest_records_batch_id1",
                table: "harvest_records",
                column: "batch_id1");

            migrationBuilder.CreateIndex(
                name: "ix_practice_records_batch_id1",
                table: "practice_records",
                column: "batch_id1");

            migrationBuilder.CreateIndex(
                name: "ix_roles_name",
                table: "roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_transport_logs_batch_id1",
                table: "transport_logs",
                column: "batch_id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audit_reports");

            migrationBuilder.DropTable(
                name: "certificates");

            migrationBuilder.DropTable(
                name: "harvest_records");

            migrationBuilder.DropTable(
                name: "practice_records");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "transport_logs");

            migrationBuilder.DropTable(
                name: "batches");

            migrationBuilder.DropTable(
                name: "farms");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
