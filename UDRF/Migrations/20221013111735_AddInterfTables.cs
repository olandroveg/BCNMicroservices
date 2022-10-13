using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDRF.Migrations
{
    public partial class AddInterfTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepeatSchedule_TimeSchedule_TimeScheduleId",
                table: "RepeatSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSchedule_BcNodeContent_BcNodeContentId",
                table: "TimeSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSchedule",
                table: "TimeSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepeatSchedule",
                table: "RepeatSchedule");

            migrationBuilder.RenameTable(
                name: "TimeSchedule",
                newName: "TimeSchedules");

            migrationBuilder.RenameTable(
                name: "RepeatSchedule",
                newName: "RepeatSchedules");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSchedule_BcNodeContentId",
                table: "TimeSchedules",
                newName: "IX_TimeSchedules_BcNodeContentId");

            migrationBuilder.RenameIndex(
                name: "IX_RepeatSchedule_TimeScheduleId",
                table: "RepeatSchedules",
                newName: "IX_RepeatSchedules_TimeScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSchedules",
                table: "TimeSchedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepeatSchedules",
                table: "RepeatSchedules",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Interfaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interfaces", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InterfBcNodeCores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterfBcNodeCores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InterfaceBcNode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InterfaceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InterfacesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BcNodeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterfaceBcNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterfaceBcNode_BcNode_BcNodeId",
                        column: x => x.BcNodeId,
                        principalTable: "BcNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterfaceBcNode_Interfaces_InterfacesId",
                        column: x => x.InterfacesId,
                        principalTable: "Interfaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InterfaceBcNodesCoreBcNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InterfBcNodeCoreId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BcNodeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterfaceBcNodesCoreBcNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterfaceBcNodesCoreBcNodes_BcNode_BcNodeId",
                        column: x => x.BcNodeId,
                        principalTable: "BcNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterfaceBcNodesCoreBcNodes_InterfBcNodeCores_InterfBcNodeCo~",
                        column: x => x.InterfBcNodeCoreId,
                        principalTable: "InterfBcNodeCores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_InterfaceBcNode_BcNodeId",
                table: "InterfaceBcNode",
                column: "BcNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_InterfaceBcNode_InterfacesId",
                table: "InterfaceBcNode",
                column: "InterfacesId");

            migrationBuilder.CreateIndex(
                name: "IX_InterfaceBcNodesCoreBcNodes_BcNodeId",
                table: "InterfaceBcNodesCoreBcNodes",
                column: "BcNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_InterfaceBcNodesCoreBcNodes_InterfBcNodeCoreId",
                table: "InterfaceBcNodesCoreBcNodes",
                column: "InterfBcNodeCoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepeatSchedules_TimeSchedules_TimeScheduleId",
                table: "RepeatSchedules",
                column: "TimeScheduleId",
                principalTable: "TimeSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSchedules_BcNodeContent_BcNodeContentId",
                table: "TimeSchedules",
                column: "BcNodeContentId",
                principalTable: "BcNodeContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepeatSchedules_TimeSchedules_TimeScheduleId",
                table: "RepeatSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSchedules_BcNodeContent_BcNodeContentId",
                table: "TimeSchedules");

            migrationBuilder.DropTable(
                name: "InterfaceBcNode");

            migrationBuilder.DropTable(
                name: "InterfaceBcNodesCoreBcNodes");

            migrationBuilder.DropTable(
                name: "Interfaces");

            migrationBuilder.DropTable(
                name: "InterfBcNodeCores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSchedules",
                table: "TimeSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepeatSchedules",
                table: "RepeatSchedules");

            migrationBuilder.RenameTable(
                name: "TimeSchedules",
                newName: "TimeSchedule");

            migrationBuilder.RenameTable(
                name: "RepeatSchedules",
                newName: "RepeatSchedule");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSchedules_BcNodeContentId",
                table: "TimeSchedule",
                newName: "IX_TimeSchedule_BcNodeContentId");

            migrationBuilder.RenameIndex(
                name: "IX_RepeatSchedules_TimeScheduleId",
                table: "RepeatSchedule",
                newName: "IX_RepeatSchedule_TimeScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSchedule",
                table: "TimeSchedule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepeatSchedule",
                table: "RepeatSchedule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RepeatSchedule_TimeSchedule_TimeScheduleId",
                table: "RepeatSchedule",
                column: "TimeScheduleId",
                principalTable: "TimeSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSchedule_BcNodeContent_BcNodeContentId",
                table: "TimeSchedule",
                column: "BcNodeContentId",
                principalTable: "BcNodeContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
