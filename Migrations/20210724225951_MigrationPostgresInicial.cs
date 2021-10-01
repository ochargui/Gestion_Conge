using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_Conge.Migrations
{
    public partial class MigrationPostgresInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fonctionCollaborateurs",
                columns: table => new
                {
                    idf = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: true),
                    label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fonctionCollaborateurs", x => x.idf);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    idr = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: true),
                    label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.idr);
                });

            migrationBuilder.CreateTable(
                name: "statusConges",
                columns: table => new
                {
                    ids = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: true),
                    label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statusConges", x => x.ids);
                });

            migrationBuilder.CreateTable(
                name: "typeConges",
                columns: table => new
                {
                    idc = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: true),
                    label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeConges", x => x.idc);
                });

            migrationBuilder.CreateTable(
                name: "Collaborateurs",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    idSup = table.Column<string>(type: "text", nullable: true),
                    Nom = table.Column<string>(type: "text", nullable: true),
                    Prenom = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    mdp = table.Column<string>(type: "text", nullable: true),
                    picture = table.Column<string>(type: "text", nullable: true),
                    roleidr = table.Column<string>(type: "text", nullable: true),
                    fonctionidf = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborateurs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Collaborateurs_fonctionCollaborateurs_fonctionidf",
                        column: x => x.fonctionidf,
                        principalTable: "fonctionCollaborateurs",
                        principalColumn: "idf",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Collaborateurs_roles_roleidr",
                        column: x => x.roleidr,
                        principalTable: "roles",
                        principalColumn: "idr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "conges",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    typeidc = table.Column<string>(type: "text", nullable: true),
                    statusids = table.Column<string>(type: "text", nullable: true),
                    dateDebut = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dateFin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Congeid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conges", x => x.id);
                    table.ForeignKey(
                        name: "FK_conges_conges_Congeid",
                        column: x => x.Congeid,
                        principalTable: "conges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_conges_statusConges_statusids",
                        column: x => x.statusids,
                        principalTable: "statusConges",
                        principalColumn: "ids",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_conges_typeConges_typeidc",
                        column: x => x.typeidc,
                        principalTable: "typeConges",
                        principalColumn: "idc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collaborateurs_fonctionidf",
                table: "Collaborateurs",
                column: "fonctionidf");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborateurs_roleidr",
                table: "Collaborateurs",
                column: "roleidr");

            migrationBuilder.CreateIndex(
                name: "IX_conges_Congeid",
                table: "conges",
                column: "Congeid");

            migrationBuilder.CreateIndex(
                name: "IX_conges_statusids",
                table: "conges",
                column: "statusids");

            migrationBuilder.CreateIndex(
                name: "IX_conges_typeidc",
                table: "conges",
                column: "typeidc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collaborateurs");

            migrationBuilder.DropTable(
                name: "conges");

            migrationBuilder.DropTable(
                name: "fonctionCollaborateurs");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "statusConges");

            migrationBuilder.DropTable(
                name: "typeConges");
        }
    }
}
