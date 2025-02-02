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
                name: "Referrals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReferrerUserId = table.Column<string>(type: "TEXT", nullable: false),
                    ReferralCode = table.Column<string>(type: "TEXT", nullable: false),
                    ReferredUserEmail = table.Column<string>(type: "TEXT", nullable: true),
                    RefferedTrackingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referrals", x => x.Id);
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
                        name: "FK_ReferralReports_Referrals_ReferralId",
                        column: x => x.ReferralId,
                        principalTable: "Referrals",
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
                        name: "FK_ReferralTracking_Referrals_ReferralId",
                        column: x => x.ReferralId,
                        principalTable: "Referrals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Referrals",
                columns: new[] { "Id", "CreatedAt", "ReferralCode", "ReferredUserEmail", "ReferrerUserId", "RefferedTrackingId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 2, 16, 26, 19, 693, DateTimeKind.Local).AddTicks(5820), "XY7G4D", null, "janedoe@nothingspecific.com", new Guid("89562468-222a-4661-bee0-5d9b9749cd90"), "Pending" },
                    { 2, new DateTime(2025, 2, 2, 16, 26, 19, 693, DateTimeKind.Local).AddTicks(5878), "AB8H5E", null, "johndoe@nothingspecific.com", new Guid("26a3bd92-3917-401e-98c3-fd8f8d9d02b4"), "Pending" },
                    { 3, new DateTime(2025, 2, 2, 16, 26, 19, 693, DateTimeKind.Local).AddTicks(5882), "XY7G4D", null, "janedoe@nothingspecific.com", new Guid("f273be35-eb54-4bb5-977c-31aec7506bad"), "Redeemed" },
                    { 4, new DateTime(2025, 2, 2, 16, 26, 19, 693, DateTimeKind.Local).AddTicks(5885), "XY7G4D", null, "janedoe@nothingspecific.com", new Guid("995822ad-9064-425d-8a67-4aed6272c09b"), "Pending" },
                    { 5, new DateTime(2025, 2, 2, 16, 26, 19, 693, DateTimeKind.Local).AddTicks(5888), "XY7G4D", null, "janedoe@nothingspecific.com", new Guid("7578daa8-8ad6-42f7-b46c-988a41bc6fd1"), "Pending" },
                    { 6, new DateTime(2025, 2, 2, 16, 26, 19, 693, DateTimeKind.Local).AddTicks(5890), "XY7G4D", null, "janedoe@nothingspecific.com", new Guid("3adfad83-068d-4d9c-acea-881610593d06"), "Redeemed" }
                });

            migrationBuilder.InsertData(
                table: "ReferralTracking",
                columns: new[] { "Id", "ClickedAt", "DeviceId", "ReferralId", "Source" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 2, 21, 26, 19, 693, DateTimeKind.Utc).AddTicks(6013), "device001", 1, "SMS" },
                    { 2, new DateTime(2025, 2, 2, 21, 26, 19, 693, DateTimeKind.Utc).AddTicks(6014), "device002", 2, "Email" }
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
                name: "Referrals");
        }
    }
}
