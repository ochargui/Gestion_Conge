using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Gestion_Conge.Migrations
{
    public partial class finalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fonctionCollaborateurs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fonctionCollaborateurs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "statusConges",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statusConges", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "typeConges",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeConges", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Collaborateurs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idSup = table.Column<int>(type: "integer", nullable: false),
                    Nom = table.Column<string>(type: "text", nullable: true),
                    Prenom = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    RestPassword = table.Column<string>(type: "text", nullable: true),
                    mdp = table.Column<string>(type: "text", nullable: true),
                    picture = table.Column<string>(type: "text", nullable: true),
                    roleid = table.Column<int>(type: "integer", nullable: false),
                    fonctionid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborateurs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Collaborateurs_fonctionCollaborateurs_fonctionid",
                        column: x => x.fonctionid,
                        principalTable: "fonctionCollaborateurs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collaborateurs_roles_roleid",
                        column: x => x.roleid,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "conges",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dateDebut = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    dateFin = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    libelle = table.Column<string>(type: "text", nullable: true),
                    Collaborateurid = table.Column<int>(type: "integer", nullable: false),
                    typeid = table.Column<int>(type: "integer", nullable: false),
                    statuid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conges", x => x.id);
                    table.ForeignKey(
                        name: "FK_conges_Collaborateurs_Collaborateurid",
                        column: x => x.Collaborateurid,
                        principalTable: "Collaborateurs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_conges_statusConges_statuid",
                        column: x => x.statuid,
                        principalTable: "statusConges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_conges_typeConges_typeid",
                        column: x => x.typeid,
                        principalTable: "typeConges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collaborateurs_fonctionid",
                table: "Collaborateurs",
                column: "fonctionid");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborateurs_roleid",
                table: "Collaborateurs",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "IX_conges_Collaborateurid",
                table: "conges",
                column: "Collaborateurid");

            migrationBuilder.CreateIndex(
                name: "IX_conges_statuid",
                table: "conges",
                column: "statuid");

            migrationBuilder.CreateIndex(
                name: "IX_conges_typeid",
                table: "conges",
                column: "typeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "conges");

            migrationBuilder.DropTable(
                name: "Collaborateurs");

            migrationBuilder.DropTable(
                name: "statusConges");

            migrationBuilder.DropTable(
                name: "typeConges");

            migrationBuilder.DropTable(
                name: "fonctionCollaborateurs");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
