using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UPro.Core.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSettingsCompanyProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Settings");

            migrationBuilder.CreateTable(
                name: "CompanyProfiles",
                schema: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FictitiousBusinessName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    State = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TelephoneAlternate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    CompanyLogo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CompanyLogoPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProfileDefaults",
                schema: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstMonthFiscalYear = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EmployerIdentificationNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StateTaxID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DefaultARGL = table.Column<int>(type: "int", nullable: true),
                    DefaultARGLBank = table.Column<int>(type: "int", nullable: true),
                    DefaultAPGL = table.Column<int>(type: "int", nullable: true),
                    DefaultAPGLBank = table.Column<int>(type: "int", nullable: true),
                    DefaultPRBankAccount = table.Column<int>(type: "int", nullable: true),
                    DefaultARCreditLiability = table.Column<int>(type: "int", nullable: true),
                    DefaultInventoryGL = table.Column<int>(type: "int", nullable: true),
                    DefaultRevenueGL = table.Column<int>(type: "int", nullable: true),
                    LastGLStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastGLStopDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastGLType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastPeriodClosedYear = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LastPeriodClosedMonth = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CurrentPeriodGLID = table.Column<int>(type: "int", nullable: true),
                    EndingInventory = table.Column<int>(type: "int", nullable: true),
                    SumAPPayments = table.Column<bool>(type: "bit", nullable: false),
                    SumARPayments = table.Column<bool>(type: "bit", nullable: false),
                    SumJE = table.Column<bool>(type: "bit", nullable: false),
                    SumAR = table.Column<bool>(type: "bit", nullable: false),
                    SumAP = table.Column<bool>(type: "bit", nullable: false),
                    CompanyProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryCostingMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfileDefaults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProfileDefaults_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalSchema: "Settings",
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfileDefaults_CompanyProfileId",
                schema: "Settings",
                table: "CompanyProfileDefaults",
                column: "CompanyProfileId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyProfileDefaults",
                schema: "Settings");

            migrationBuilder.DropTable(
                name: "CompanyProfiles",
                schema: "Settings");
        }
    }
}
