using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContratosOP1.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CT");

            migrationBuilder.CreateTable(
                name: "Cargo",
                schema: "CT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                schema: "CT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoContrato",
                schema: "CT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoTipo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DescripcionTipo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoContrato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidad",
                schema: "CT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoUnidad = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DescripcionUnidad = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                schema: "CT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipio_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalSchema: "CT",
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                schema: "CT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inss = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleado_Municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalSchema: "CT",
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contratacion",
                schema: "CT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    Salario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    TipoDeContratoId = table.Column<int>(type: "int", nullable: false),
                    UnidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratacion_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalSchema: "CT",
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratacion_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalSchema: "CT",
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratacion_TipoContrato_TipoDeContratoId",
                        column: x => x.TipoDeContratoId,
                        principalSchema: "CT",
                        principalTable: "TipoContrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratacion_Unidad_UnidadId",
                        column: x => x.UnidadId,
                        principalSchema: "CT",
                        principalTable: "Unidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratacion_CargoId",
                schema: "CT",
                table: "Contratacion",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratacion_EmpleadoId",
                schema: "CT",
                table: "Contratacion",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratacion_TipoDeContratoId",
                schema: "CT",
                table: "Contratacion",
                column: "TipoDeContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratacion_UnidadId",
                schema: "CT",
                table: "Contratacion",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_MunicipioId",
                schema: "CT",
                table: "Empleado",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_DepartamentoId",
                schema: "CT",
                table: "Municipio",
                column: "DepartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratacion",
                schema: "CT");

            migrationBuilder.DropTable(
                name: "Cargo",
                schema: "CT");

            migrationBuilder.DropTable(
                name: "Empleado",
                schema: "CT");

            migrationBuilder.DropTable(
                name: "TipoContrato",
                schema: "CT");

            migrationBuilder.DropTable(
                name: "Unidad",
                schema: "CT");

            migrationBuilder.DropTable(
                name: "Municipio",
                schema: "CT");

            migrationBuilder.DropTable(
                name: "Departamento",
                schema: "CT");
        }
    }
}
