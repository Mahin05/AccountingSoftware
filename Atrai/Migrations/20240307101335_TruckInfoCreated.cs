using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class TruckInfoCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TruckInfoId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TruckInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LCId = table.Column<int>(type: "int", nullable: true),
                    LCNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PINo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupLcId = table.Column<int>(type: "int", nullable: true),
                    MasterLC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TruckInfo_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TruckInfo_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_TruckInfoId",
                table: "BBLCMaster",
                column: "TruckInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TruckInfo_ComId",
                table: "TruckInfo",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_TruckInfo_LuserId",
                table: "TruckInfo",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_TruckInfo_TruckInfoId",
                table: "BBLCMaster",
                column: "TruckInfoId",
                principalTable: "TruckInfo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_TruckInfo_TruckInfoId",
                table: "BBLCMaster");

            migrationBuilder.DropTable(
                name: "TruckInfo");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_TruckInfoId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "TruckInfoId",
                table: "BBLCMaster");
        }
    }
}
