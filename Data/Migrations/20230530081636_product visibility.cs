using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class productvisibility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d408ddd2-3b69-412a-a8ca-da422c7ee890",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "72ed76d8-0531-4dd1-b7f4-a24a4d259e9b", "AQAAAAIAAYagAAAAEOYGS3R7/Dz6eyQDupYl+GWzyX7yj8UydnleDOe7wwaC6GYqZi+V/UeV0VXzlGvxFg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Visible",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Visible",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Visible",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d408ddd2-3b69-412a-a8ca-da422c7ee890",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a7a08895-7a35-4ad8-b6ef-b714bb7f7384", "AQAAAAIAAYagAAAAEHFSMoqQm9E3Fp8ClF7++Zz9U6qLPwh9FqJzLOOvWHlZwHmVda0FSxcwq270rNZA1g==" });
        }
    }
}
