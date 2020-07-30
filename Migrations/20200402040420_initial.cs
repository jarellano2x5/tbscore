using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tbscore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BTDatos",
                columns: table => new
                {
                    BTDatoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contenido = table.Column<string>(unicode: false, maxLength: 3000, nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Origen = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BTDatos", x => x.BTDatoID);
                });

            migrationBuilder.CreateTable(
                name: "TGUsuarios",
                columns: table => new
                {
                    TGUsuarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Apellido = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    Usuario = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    Contrasena = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    Correo = table.Column<string>(unicode: false, maxLength: 70, nullable: true),
                    FecAlta = table.Column<DateTime>(nullable: false),
                    EstatusID = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TGUsuarios", x => x.TGUsuarioID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BTDatos");

            migrationBuilder.DropTable(
                name: "TGUsuarios");
        }
    }
}
