using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Referral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReferrerUserId = table.Column<string>(type: "TEXT", nullable: false),
                    ReferralCode = table.Column<string>(type: "TEXT", nullable: false),
                    ReferredUser = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referral", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReferralReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReferralId = table.Column<int>(type: "INTEGER", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: false),
                    ReportedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferralReports_Referral_ReferralId",
                        column: x => x.ReferralId,
                        principalTable: "Referral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferralTracking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReferralId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceId = table.Column<string>(type: "TEXT", nullable: false),
                    Source = table.Column<string>(type: "TEXT", nullable: false),
                    ClickedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralTracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferralTracking_Referral_ReferralId",
                        column: x => x.ReferralId,
                        principalTable: "Referral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Referral",
                columns: new[] { "Id", "CreatedAt", "ReferralCode", "ReferredUser", "ReferrerUserId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 2, 14, 47, 22, 610, DateTimeKind.Utc).AddTicks(7942), "XY7G4D", null, "janedoe@nothingspecific.com", "Pending" },
                    { 2, new DateTime(2025, 2, 2, 14, 47, 22, 610, DateTimeKind.Utc).AddTicks(7946), "AB8H5E", null, "johndoe@nothingspecific.com", "Pending" }
                });

            migrationBuilder.InsertData(
                table: "ReferralTracking",
                columns: new[] { "Id", "ClickedAt", "DeviceId", "ReferralId", "Source" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 2, 14, 47, 22, 610, DateTimeKind.Utc).AddTicks(8055), "device001", 1, "SMS" },
                    { 2, new DateTime(2025, 2, 2, 14, 47, 22, 610, DateTimeKind.Utc).AddTicks(8056), "device002", 2, "Email" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReferralReports_ReferralId",
                table: "ReferralReports",
                column: "ReferralId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferralTracking_ReferralId",
                table: "ReferralTracking",
                column: "ReferralId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReferralReports");

            migrationBuilder.DropTable(
                name: "ReferralTracking");

            migrationBuilder.DropTable(
                name: "Referral");
        }
    }
}
