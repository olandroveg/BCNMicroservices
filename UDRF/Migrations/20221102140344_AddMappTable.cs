using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDRF.Migrations
{
    public partial class AddMappTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterfaceBcNode_Interfaces_InterfacesId",
                table: "InterfaceBcNode");

            migrationBuilder.DropForeignKey(
                name: "FK_InterfaceBcNodesCoreBcNodes_BcNode_BcNodeId",
                table: "InterfaceBcNodesCoreBcNodes");

            migrationBuilder.DropForeignKey(
                name: "FK_InterfaceBcNodesCoreBcNodes_InterfBcNodeCores_InterfBcNodeCo~",
                table: "InterfaceBcNodesCoreBcNodes");

            migrationBuilder.DropForeignKey(
                name: "FK_RepeatSchedules_TimeSchedules_TimeScheduleId",
                table: "RepeatSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSchedules_BcNodeContent_BcNodeContentId",
                table: "TimeSchedules");

            migrationBuilder.DropIndex(
                name: "IX_InterfaceBcNode_InterfacesId",
                table: "InterfaceBcNode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSchedules",
                table: "TimeSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepeatSchedules",
                table: "RepeatSchedules");

            migrationBuilder.DropIndex(
                name: "IX_RepeatSchedules_TimeScheduleId",
                table: "RepeatSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterfBcNodeCores",
                table: "InterfBcNodeCores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterfaceBcNodesCoreBcNodes",
                table: "InterfaceBcNodesCoreBcNodes");

            migrationBuilder.DropColumn(
                name: "InterfacesId",
                table: "InterfaceBcNode");

            migrationBuilder.DropColumn(
                name: "TimeScheduleId",
                table: "RepeatSchedules");

            migrationBuilder.RenameTable(
                name: "TimeSchedules",
                newName: "TimeSchedule");

            migrationBuilder.RenameTable(
                name: "RepeatSchedules",
                newName: "RepeatSchedule");

            migrationBuilder.RenameTable(
                name: "InterfBcNodeCores",
                newName: "InterfBcNodeCore");

            migrationBuilder.RenameTable(
                name: "InterfaceBcNodesCoreBcNodes",
                newName: "InterfaceBcNodesCoreBcNode");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSchedules_BcNodeContentId",
                table: "TimeSchedule",
                newName: "IX_TimeSchedule_BcNodeContentId");

            migrationBuilder.RenameIndex(
                name: "IX_InterfaceBcNodesCoreBcNodes_InterfBcNodeCoreId",
                table: "InterfaceBcNodesCoreBcNode",
                newName: "IX_InterfaceBcNodesCoreBcNode_InterfBcNodeCoreId");

            migrationBuilder.RenameIndex(
                name: "IX_InterfaceBcNodesCoreBcNodes_BcNodeId",
                table: "InterfaceBcNodesCoreBcNode",
                newName: "IX_InterfaceBcNodesCoreBcNode_BcNodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSchedule",
                table: "TimeSchedule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepeatSchedule",
                table: "RepeatSchedule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterfBcNodeCore",
                table: "InterfBcNodeCore",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterfaceBcNodesCoreBcNode",
                table: "InterfaceBcNodesCoreBcNode",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "NFmapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NF = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Version = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Available = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFmapping", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "APImapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NFId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ServiceName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServiceApi = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APImapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_APImapping_NFmapping_NFId",
                        column: x => x.NFId,
                        principalTable: "NFmapping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_InterfaceBcNode_InterfaceId",
                table: "InterfaceBcNode",
                column: "InterfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RepeatSchedule_TimeSchduleId",
                table: "RepeatSchedule",
                column: "TimeSchduleId");

            migrationBuilder.CreateIndex(
                name: "IX_APImapping_NFId",
                table: "APImapping",
                column: "NFId");

            migrationBuilder.AddForeignKey(
                name: "FK_InterfaceBcNode_Interfaces_InterfaceId",
                table: "InterfaceBcNode",
                column: "InterfaceId",
                principalTable: "Interfaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterfaceBcNodesCoreBcNode_BcNode_BcNodeId",
                table: "InterfaceBcNodesCoreBcNode",
                column: "BcNodeId",
                principalTable: "BcNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterfaceBcNodesCoreBcNode_InterfBcNodeCore_InterfBcNodeCore~",
                table: "InterfaceBcNodesCoreBcNode",
                column: "InterfBcNodeCoreId",
                principalTable: "InterfBcNodeCore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepeatSchedule_TimeSchedule_TimeSchduleId",
                table: "RepeatSchedule",
                column: "TimeSchduleId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterfaceBcNode_Interfaces_InterfaceId",
                table: "InterfaceBcNode");

            migrationBuilder.DropForeignKey(
                name: "FK_InterfaceBcNodesCoreBcNode_BcNode_BcNodeId",
                table: "InterfaceBcNodesCoreBcNode");

            migrationBuilder.DropForeignKey(
                name: "FK_InterfaceBcNodesCoreBcNode_InterfBcNodeCore_InterfBcNodeCore~",
                table: "InterfaceBcNodesCoreBcNode");

            migrationBuilder.DropForeignKey(
                name: "FK_RepeatSchedule_TimeSchedule_TimeSchduleId",
                table: "RepeatSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSchedule_BcNodeContent_BcNodeContentId",
                table: "TimeSchedule");

            migrationBuilder.DropTable(
                name: "APImapping");

            migrationBuilder.DropTable(
                name: "NFmapping");

            migrationBuilder.DropIndex(
                name: "IX_InterfaceBcNode_InterfaceId",
                table: "InterfaceBcNode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSchedule",
                table: "TimeSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepeatSchedule",
                table: "RepeatSchedule");

            migrationBuilder.DropIndex(
                name: "IX_RepeatSchedule_TimeSchduleId",
                table: "RepeatSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterfBcNodeCore",
                table: "InterfBcNodeCore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterfaceBcNodesCoreBcNode",
                table: "InterfaceBcNodesCoreBcNode");

            migrationBuilder.RenameTable(
                name: "TimeSchedule",
                newName: "TimeSchedules");

            migrationBuilder.RenameTable(
                name: "RepeatSchedule",
                newName: "RepeatSchedules");

            migrationBuilder.RenameTable(
                name: "InterfBcNodeCore",
                newName: "InterfBcNodeCores");

            migrationBuilder.RenameTable(
                name: "InterfaceBcNodesCoreBcNode",
                newName: "InterfaceBcNodesCoreBcNodes");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSchedule_BcNodeContentId",
                table: "TimeSchedules",
                newName: "IX_TimeSchedules_BcNodeContentId");

            migrationBuilder.RenameIndex(
                name: "IX_InterfaceBcNodesCoreBcNode_InterfBcNodeCoreId",
                table: "InterfaceBcNodesCoreBcNodes",
                newName: "IX_InterfaceBcNodesCoreBcNodes_InterfBcNodeCoreId");

            migrationBuilder.RenameIndex(
                name: "IX_InterfaceBcNodesCoreBcNode_BcNodeId",
                table: "InterfaceBcNodesCoreBcNodes",
                newName: "IX_InterfaceBcNodesCoreBcNodes_BcNodeId");

            migrationBuilder.AddColumn<Guid>(
                name: "InterfacesId",
                table: "InterfaceBcNode",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TimeScheduleId",
                table: "RepeatSchedules",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSchedules",
                table: "TimeSchedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepeatSchedules",
                table: "RepeatSchedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterfBcNodeCores",
                table: "InterfBcNodeCores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterfaceBcNodesCoreBcNodes",
                table: "InterfaceBcNodesCoreBcNodes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_InterfaceBcNode_InterfacesId",
                table: "InterfaceBcNode",
                column: "InterfacesId");

            migrationBuilder.CreateIndex(
                name: "IX_RepeatSchedules_TimeScheduleId",
                table: "RepeatSchedules",
                column: "TimeScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_InterfaceBcNode_Interfaces_InterfacesId",
                table: "InterfaceBcNode",
                column: "InterfacesId",
                principalTable: "Interfaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterfaceBcNodesCoreBcNodes_BcNode_BcNodeId",
                table: "InterfaceBcNodesCoreBcNodes",
                column: "BcNodeId",
                principalTable: "BcNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterfaceBcNodesCoreBcNodes_InterfBcNodeCores_InterfBcNodeCo~",
                table: "InterfaceBcNodesCoreBcNodes",
                column: "InterfBcNodeCoreId",
                principalTable: "InterfBcNodeCores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
