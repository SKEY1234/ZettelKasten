using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZettelKasten.Migrations
{
    /// <inheritdoc />
    public partial class ZettelKastenDbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    tagid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tags_pkey", x => x.tagid);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    login = table.Column<string>(type: "character varying", nullable: false),
                    pass = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    noteid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    content = table.Column<string>(type: "text", nullable: true),
                    creationdate = table.Column<DateOnly>(type: "date", nullable: true),
                    userid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("notes_pkey", x => x.noteid);
                    table.ForeignKey(
                        name: "notes_userid_fkey",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateTable(
                name: "noterelations",
                columns: table => new
                {
                    relationid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    sourcenoteid = table.Column<Guid>(type: "uuid", nullable: true),
                    targetnoteid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("noterelations_pkey", x => x.relationid);
                    table.ForeignKey(
                        name: "noterelations_sourcenoteid_fkey",
                        column: x => x.sourcenoteid,
                        principalTable: "notes",
                        principalColumn: "noteid");
                    table.ForeignKey(
                        name: "noterelations_targetnoteid_fkey",
                        column: x => x.targetnoteid,
                        principalTable: "notes",
                        principalColumn: "noteid");
                });

            migrationBuilder.CreateTable(
                name: "notetagrelations",
                columns: table => new
                {
                    relationid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    noteid = table.Column<Guid>(type: "uuid", nullable: true),
                    tagid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("notetagrelations_pkey", x => x.relationid);
                    table.ForeignKey(
                        name: "notetagrelations_noteid_fkey",
                        column: x => x.noteid,
                        principalTable: "notes",
                        principalColumn: "noteid");
                    table.ForeignKey(
                        name: "notetagrelations_tagid_fkey",
                        column: x => x.tagid,
                        principalTable: "tags",
                        principalColumn: "tagid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_noterelations_sourcenoteid",
                table: "noterelations",
                column: "sourcenoteid");

            migrationBuilder.CreateIndex(
                name: "IX_noterelations_targetnoteid",
                table: "noterelations",
                column: "targetnoteid");

            migrationBuilder.CreateIndex(
                name: "IX_notes_userid",
                table: "notes",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_notetagrelations_noteid",
                table: "notetagrelations",
                column: "noteid");

            migrationBuilder.CreateIndex(
                name: "IX_notetagrelations_tagid",
                table: "notetagrelations",
                column: "tagid");

            migrationBuilder.CreateIndex(
                name: "tags_name_key",
                table: "tags",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "noterelations");

            migrationBuilder.DropTable(
                name: "notetagrelations");

            migrationBuilder.DropTable(
                name: "notes");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
