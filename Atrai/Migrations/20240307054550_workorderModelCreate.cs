using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class workorderModelCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprovedBy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprovedByName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ApprovedByShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovedBy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkOCOM_MachineryLCMasterrderMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LCNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LCDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    PaymentTermsId = table.Column<int>(type: "int", nullable: true),
                    DefferredPaymentDays = table.Column<int>(type: "int", nullable: true),
                    ShipDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsuranceCompanyId = table.Column<int>(type: "int", nullable: true),
                    InsurancePayStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImportBillNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImportBillDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillMacturityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillPayDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalBillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Addedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOCOM_MachineryLCMasterrderMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOCOM_MachineryLCMasterrderMaster_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkOCOM_MachineryLCMasterrderMaster_PaymentTermss_PaymentTermsId",
                        column: x => x.PaymentTermsId,
                        principalTable: "PaymentTermss",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOCOM_MachineryLCMasterrderMaster_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOCOM_MachineryLCMasterrderMaster_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WorkorderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkorderStatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WorkorderStatusShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkorderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommercialCompanyId = table.Column<int>(type: "int", nullable: true),
                    WorkOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    ToPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgreementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceContractStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceContractEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    ConversionRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WorkOrderType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WorkOrderRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SalesTax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtherExp = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WorkOrderAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AdvancePayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetPayable = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    ServiceContract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderStatusId = table.Column<int>(type: "int", nullable: true),
                    WODetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shipping = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApprovedById = table.Column<int>(type: "int", nullable: true),
                    RecommenedById = table.Column<int>(type: "int", nullable: true),
                    DateApproval = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ItemDescList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemGroupId = table.Column<int>(type: "int", nullable: true),
                    ItemGroupName = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true),
                    ItemDescription = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true),
                    ItemDescId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrderMaster_ApprovedBy_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "ApprovedBy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrderMaster_ApprovedBy_RecommenedById",
                        column: x => x.RecommenedById,
                        principalTable: "ApprovedBy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrderMaster_Commercial_CommercialCompanyId",
                        column: x => x.CommercialCompanyId,
                        principalTable: "Commercial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrderMaster_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkOrderMaster_Country_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrderMaster_ItemDescription_ItemDescId",
                        column: x => x.ItemDescId,
                        principalTable: "ItemDescription",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrderMaster_ItemGroup_ItemGroupId",
                        column: x => x.ItemGroupId,
                        principalTable: "ItemGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrderMaster_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrderMaster_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkOrderMaster_WorkorderStatus_WorkOrderStatusId",
                        column: x => x.WorkOrderStatusId,
                        principalTable: "WorkorderStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "COM_MachineryLCDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineryLCId = table.Column<int>(type: "int", nullable: false),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false),
                    WorkOrderRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_MachineryLCDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COM_MachineryLCDetails_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_MachineryLCDetails_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_MachineryLCDetails_WorkOCOM_MachineryLCMasterrderMaster_MachineryLCId",
                        column: x => x.MachineryLCId,
                        principalTable: "WorkOCOM_MachineryLCMasterrderMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_MachineryLCDetails_WorkOrderMaster_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrderMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachineryLCDetails_ComId",
                table: "COM_MachineryLCDetails",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachineryLCDetails_LuserId",
                table: "COM_MachineryLCDetails",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachineryLCDetails_MachineryLCId",
                table: "COM_MachineryLCDetails",
                column: "MachineryLCId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachineryLCDetails_WorkOrderId",
                table: "COM_MachineryLCDetails",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOCOM_MachineryLCMasterrderMaster_ComId",
                table: "WorkOCOM_MachineryLCMasterrderMaster",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOCOM_MachineryLCMasterrderMaster_LuserId",
                table: "WorkOCOM_MachineryLCMasterrderMaster",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOCOM_MachineryLCMasterrderMaster_PaymentTermsId",
                table: "WorkOCOM_MachineryLCMasterrderMaster",
                column: "PaymentTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOCOM_MachineryLCMasterrderMaster_SupplierId",
                table: "WorkOCOM_MachineryLCMasterrderMaster",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderMaster_ApprovedById",
                table: "WorkOrderMaster",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderMaster_ComId",
                table: "WorkOrderMaster",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderMaster_CommercialCompanyId",
                table: "WorkOrderMaster",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderMaster_CurrencyId",
                table: "WorkOrderMaster",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderMaster_ItemDescId",
                table: "WorkOrderMaster",
                column: "ItemDescId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderMaster_ItemGroupId",
                table: "WorkOrderMaster",
                column: "ItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderMaster_LuserId",
                table: "WorkOrderMaster",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderMaster_RecommenedById",
                table: "WorkOrderMaster",
                column: "RecommenedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderMaster_SupplierId",
                table: "WorkOrderMaster",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderMaster_WorkOrderStatusId",
                table: "WorkOrderMaster",
                column: "WorkOrderStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COM_MachineryLCDetails");

            migrationBuilder.DropTable(
                name: "WorkOCOM_MachineryLCMasterrderMaster");

            migrationBuilder.DropTable(
                name: "WorkOrderMaster");

            migrationBuilder.DropTable(
                name: "ApprovedBy");

            migrationBuilder.DropTable(
                name: "WorkorderStatus");
        }
    }
}
