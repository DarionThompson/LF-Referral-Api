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

            migrationBuilder.InsertData(
                table: "Referrals",
                columns: new[] { "Id", "CreatedAt", "ReferralCode", "ReferredUserEmail", "ReferrerUserId", "RefferedTrackingId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 3, 11, 0, 58, 884, DateTimeKind.Local).AddTicks(8097), "XY7G4D", "joe@gmail.com", "janedoe@nothingspecific.com", new Guid("89562468-222a-4661-bee0-5d9b9749cd90"), "Pending" },
                    { 2, new DateTime(2025, 2, 3, 11, 0, 58, 884, DateTimeKind.Local).AddTicks(8150), "AB8H5E", "joe@gmail.com", "johndoe@nothingspecific.com", new Guid("26a3bd92-3917-401e-98c3-fd8f8d9d02b4"), "Pending" },
                    { 3, new DateTime(2025, 2, 3, 11, 0, 58, 884, DateTimeKind.Local).AddTicks(8153), "XY7G4D", "joe@gmail.com", "janedoe@nothingspecific.com", new Guid("f273be35-eb54-4bb5-977c-31aec7506bad"), "Redeemed" },
                    { 4, new DateTime(2025, 2, 3, 11, 0, 58, 884, DateTimeKind.Local).AddTicks(8157), "XY7G4D", "Eli@gmail.com", "janedoe@nothingspecific.com", new Guid("995822ad-9064-425d-8a67-4aed6272c09b"), "Pending" },
                    { 5, new DateTime(2025, 2, 3, 11, 0, 58, 884, DateTimeKind.Local).AddTicks(8159), "XY7G4D", "kate@gmail.com", "janedoe@nothingspecific.com", new Guid("7578daa8-8ad6-42f7-b46c-988a41bc6fd1"), "Pending" },
                    { 6, new DateTime(2025, 2, 3, 11, 0, 58, 884, DateTimeKind.Local).AddTicks(8162), "XY7G4D", "bill@gmail.com", "janedoe@nothingspecific.com", new Guid("3adfad83-068d-4d9c-acea-881610593d06"), "Redeemed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Referrals");
        }
    }
}
