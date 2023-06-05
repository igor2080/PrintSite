using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class adminfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d408ddd2-3b69-412a-a8ca-da422c7ee890",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "c5507630-a200-4837-837f-fc7fdb615747", "admin@printsite.com", "AQAAAAIAAYagAAAAEGEXvJwgZmeLiOYH0C7fTzbXDQzlUtrUk5gC6WFYD9X0hEYPiF8q6LRwvcVHxuCXVg==", "admin@printsite.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d408ddd2-3b69-412a-a8ca-da422c7ee890",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "72ed76d8-0531-4dd1-b7f4-a24a4d259e9b", "admin", "AQAAAAIAAYagAAAAEOYGS3R7/Dz6eyQDupYl+GWzyX7yj8UydnleDOe7wwaC6GYqZi+V/UeV0VXzlGvxFg==", "admin" });
        }
    }
}
