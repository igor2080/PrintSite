using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrintSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000000", null, "regular", "regular" },
                    { "5df4e6c4-8441-4851-952d-6f9bdd2b4026", null, "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d408ddd2-3b69-412a-a8ca-da422c7ee890", 0, "a7a08895-7a35-4ad8-b6ef-b714bb7f7384", "admin@printsite.com", true, false, null, "admin@printsite.com", "admin", "AQAAAAIAAYagAAAAEHFSMoqQm9E3Fp8ClF7++Zz9U6qLPwh9FqJzLOOvWHlZwHmVda0FSxcwq270rNZA1g==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5df4e6c4-8441-4851-952d-6f9bdd2b4026", "d408ddd2-3b69-412a-a8ca-da422c7ee890" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5df4e6c4-8441-4851-952d-6f9bdd2b4026", "d408ddd2-3b69-412a-a8ca-da422c7ee890" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5df4e6c4-8441-4851-952d-6f9bdd2b4026");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d408ddd2-3b69-412a-a8ca-da422c7ee890");
        }
    }
}
