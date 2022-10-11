using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDRF.Migrations
{
    public partial class AddContentService_TimeSchedule_RepeatSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RealTime = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentServices", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TimeSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BcNodeContentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DurationSec = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSchedule_BcNodeContent_BcNodeContentId",
                        column: x => x.BcNodeContentId,
                        principalTable: "BcNodeContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RepeatSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TimeSchduleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TimeScheduleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepeatSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepeatSchedule_TimeSchedule_TimeScheduleId",
                        column: x => x.TimeScheduleId,
                        principalTable: "TimeSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Content_ServicesId",
                table: "Content",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_RepeatSchedule_TimeScheduleId",
                table: "RepeatSchedule",
                column: "TimeScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSchedule_BcNodeContentId",
                table: "TimeSchedule",
                column: "BcNodeContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_ContentServices_ServicesId",
                table: "Content",
                column: "ServicesId",
                principalTable: "ContentServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_ContentServices_ServicesId",
                table: "Content");

            migrationBuilder.DropTable(
                name: "ContentServices");

            migrationBuilder.DropTable(
                name: "RepeatSchedule");

            migrationBuilder.DropTable(
                name: "TimeSchedule");

            migrationBuilder.DropIndex(
                name: "IX_Content_ServicesId",
                table: "Content");
        }
    }
}
