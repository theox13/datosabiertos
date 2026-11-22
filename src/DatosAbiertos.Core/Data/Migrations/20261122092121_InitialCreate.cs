using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatosAbiertos.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fuentes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    slug = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    licencia = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    formato = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    frecuencia = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cobertura_geografica = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    last_attempt_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    last_success_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    coverage_from = table.Column<DateOnly>(type: "date", nullable: true),
                    coverage_to = table.Column<DateOnly>(type: "date", nullable: true),
                    status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fuentes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "provincias",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ine_code = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ccaa = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provincias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ingest_runs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    source_id = table.Column<Guid>(type: "uuid", nullable: false),
                    started_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    finished_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    rows_read = table.Column<int>(type: "integer", nullable: false),
                    rows_upserted = table.Column<int>(type: "integer", nullable: false),
                    error = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingest_runs", x => x.id);
                    table.ForeignKey(
                        name: "FK_ingest_runs_fuentes_source_id",
                        column: x => x.source_id,
                        principalTable: "fuentes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "raw_payloads",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    source_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fetched_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    http_status = table.Column<int>(type: "integer", nullable: false),
                    content_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raw_payloads", x => x.id);
                    table.ForeignKey(
                        name: "FK_raw_payloads_fuentes_source_id",
                        column: x => x.source_id,
                        principalTable: "fuentes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "municipios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ine_code = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    provincia_id = table.Column<Guid>(type: "uuid", nullable: false),
                    lat = table.Column<double>(type: "double precision", nullable: true),
                    lon = table.Column<double>(type: "double precision", nullable: true),
                    poblacion = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipios", x => x.id);
                    table.ForeignKey(
                        name: "FK_municipios_provincias_provincia_id",
                        column: x => x.provincia_id,
                        principalTable: "provincias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "farmacias",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    provincia_id = table.Column<Guid>(type: "uuid", nullable: false),
                    soe_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    direccion = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    municipio_id = table.Column<Guid>(type: "uuid", nullable: true),
                    lat = table.Column<double>(type: "double precision", nullable: true),
                    lon = table.Column<double>(type: "double precision", nullable: true),
                    telefono = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    source_id = table.Column<Guid>(type: "uuid", nullable: false),
                    external_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    fingerprint = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farmacias", x => x.id);
                    table.ForeignKey(
                        name: "FK_farmacias_fuentes_source_id",
                        column: x => x.source_id,
                        principalTable: "fuentes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_farmacias_municipios_municipio_id",
                        column: x => x.municipio_id,
                        principalTable: "municipios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_farmacias_provincias_provincia_id",
                        column: x => x.provincia_id,
                        principalTable: "provincias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "guardias",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    farmacia_id = table.Column<Guid>(type: "uuid", nullable: false),
                    source_id = table.Column<Guid>(type: "uuid", nullable: false),
                    valid_from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    valid_to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    raw_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    last_verified_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guardias", x => x.id);
                    table.ForeignKey(
                        name: "FK_guardias_farmacias_farmacia_id",
                        column: x => x.farmacia_id,
                        principalTable: "farmacias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_guardias_fuentes_source_id",
                        column: x => x.source_id,
                        principalTable: "fuentes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_farmacias_fingerprint",
                table: "farmacias",
                column: "fingerprint",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_farmacias_municipio_id",
                table: "farmacias",
                column: "municipio_id");

            migrationBuilder.CreateIndex(
                name: "IX_farmacias_provincia_id_soe_code",
                table: "farmacias",
                columns: new[] { "provincia_id", "soe_code" },
                unique: true,
                filter: "soe_code IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_farmacias_source_id_external_id",
                table: "farmacias",
                columns: new[] { "source_id", "external_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fuentes_slug",
                table: "fuentes",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_guardias_farmacia_id_source_id_valid_from",
                table: "guardias",
                columns: new[] { "farmacia_id", "source_id", "valid_from" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_guardias_source_id",
                table: "guardias",
                column: "source_id");

            migrationBuilder.CreateIndex(
                name: "IX_guardias_valid_from_valid_to",
                table: "guardias",
                columns: new[] { "valid_from", "valid_to" });

            migrationBuilder.CreateIndex(
                name: "IX_ingest_runs_source_id_started_at",
                table: "ingest_runs",
                columns: new[] { "source_id", "started_at" });

            migrationBuilder.CreateIndex(
                name: "IX_municipios_ine_code",
                table: "municipios",
                column: "ine_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_municipios_provincia_id",
                table: "municipios",
                column: "provincia_id");

            migrationBuilder.CreateIndex(
                name: "IX_provincias_ine_code",
                table: "provincias",
                column: "ine_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_raw_payloads_source_id_fetched_at",
                table: "raw_payloads",
                columns: new[] { "source_id", "fetched_at" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guardias");

            migrationBuilder.DropTable(
                name: "ingest_runs");

            migrationBuilder.DropTable(
                name: "raw_payloads");

            migrationBuilder.DropTable(
                name: "farmacias");

            migrationBuilder.DropTable(
                name: "fuentes");

            migrationBuilder.DropTable(
                name: "municipios");

            migrationBuilder.DropTable(
                name: "provincias");
        }
    }
}
