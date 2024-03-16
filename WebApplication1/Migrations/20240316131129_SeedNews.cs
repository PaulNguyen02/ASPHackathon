using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEnvironment_Hackathon_GaMo.Migrations
{
    /// <inheritdoc />
    public partial class SeedNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "48751f1f-5636-4a3a-9671-ab50ba8aee64", "AQAAAAIAAYagAAAAEOAfkzvJ9+E0us0Bukmh68Of6y1rl6nQ6AxE6SQuv4vVUXxHetrG7twoSohyW0uS2g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b64cc01d-4317-4a44-88f6-a0cc4e2709ab"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "288ad6ab-cb4a-4127-b854-805a018ed0d2", "AQAAAAIAAYagAAAAEPqioHzilOmw1+1s7wMkxdHagxdDYnRieXmpAGze1NQphAEVkdvB5FgOuAJhd2QZdQ==" });

            migrationBuilder.InsertData(
                table: "New",
                columns: new[] { "Id_New", "Created_at", "Created_by", "Description", "ImageUrl", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2024, 3, 16, 20, 11, 27, 380, DateTimeKind.Local).AddTicks(4501), new DateTime(2024, 3, 16, 20, 11, 27, 380, DateTimeKind.Local).AddTicks(4520), "Tin tức về rác thải nhựa", "/themes/img/gallery/case1.png", "Tin tức về rác thải nhựa", new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "New",
                keyColumn: "Id_New",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f1fac3c6-3583-4de8-9bf4-0e9da0a38128", "AQAAAAIAAYagAAAAELr2o01cLN4Glfagiyias8J3FouLp4xUkrlbQ71zOEINtnJ/Ou8G3vpOY1V4CWPE7A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b64cc01d-4317-4a44-88f6-a0cc4e2709ab"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "92aa0a01-0c55-4c19-9d70-8b0497ae1d34", "AQAAAAIAAYagAAAAEJsDxX0gLydvx6hC8XAiK28FUV+Qb0bQuCHHuxkpe7yxL1PEgBdPz9mNt3LOzE+9iQ==" });
        }
    }
}
