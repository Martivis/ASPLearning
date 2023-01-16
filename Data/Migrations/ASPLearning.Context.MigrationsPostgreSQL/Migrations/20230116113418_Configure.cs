using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ASPLearning.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Configure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "appdb",
                table: "users",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "AverageSpeed",
                schema: "appdb",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TextsCount",
                schema: "appdb",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "texts",
                schema: "appdb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_texts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trials",
                schema: "appdb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TextId = table.Column<int>(type: "integer", nullable: false),
                    AverageSpeed = table.Column<int>(type: "integer", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trials_texts_TextId",
                        column: x => x.TextId,
                        principalSchema: "appdb",
                        principalTable: "texts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trials_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "appdb",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_Name",
                schema: "appdb",
                table: "users",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_texts_Uid",
                schema: "appdb",
                table: "texts",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trials_TextId",
                schema: "appdb",
                table: "trials",
                column: "TextId");

            migrationBuilder.CreateIndex(
                name: "IX_trials_Uid",
                schema: "appdb",
                table: "trials",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trials_UserId",
                schema: "appdb",
                table: "trials",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trials",
                schema: "appdb");

            migrationBuilder.DropTable(
                name: "texts",
                schema: "appdb");

            migrationBuilder.DropIndex(
                name: "IX_users_Name",
                schema: "appdb",
                table: "users");

            migrationBuilder.DropColumn(
                name: "AverageSpeed",
                schema: "appdb",
                table: "users");

            migrationBuilder.DropColumn(
                name: "TextsCount",
                schema: "appdb",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "appdb",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);
        }
    }
}
