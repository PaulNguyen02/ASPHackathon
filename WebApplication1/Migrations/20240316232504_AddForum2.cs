using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEnvironment_Hackathon_GaMo.Migrations
{
    /// <inheritdoc />
    public partial class AddForum2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Forum",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9e656ac3-aeaa-40ea-a069-fb8ddf2d070a", "AQAAAAIAAYagAAAAEPQSORMLUV8FaVWy6k41KNbpjkAUOIMluR6/q/oA8iAuyLViwNrYKH97BDjpZQepPw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b64cc01d-4317-4a44-88f6-a0cc4e2709ab"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6c193b8f-9fe1-4b34-8ebd-b91c6f10f7bd", "AQAAAAIAAYagAAAAEAEvmZDTTWMFAToHN7Be928aUfuUvNuDyV+NpslgPNN1LeVsNm7uW0i3UEWkCEMjCg==" });

            migrationBuilder.UpdateData(
                table: "Forum",
                keyColumn: "ID_Post",
                keyValue: 1,
                columns: new[] { "Created_At", "ImageUrl" },
                values: new object[] { new DateTime(2024, 3, 17, 6, 25, 2, 363, DateTimeKind.Local).AddTicks(8908), "/themes/img/gallery/services1.png" });

            migrationBuilder.UpdateData(
                table: "New",
                keyColumn: "Id_New",
                keyValue: 1,
                column: "Created_at",
                value: new DateTime(2024, 3, 17, 6, 25, 2, 363, DateTimeKind.Local).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "New",
                keyColumn: "Id_New",
                keyValue: 2,
                column: "Created_at",
                value: new DateTime(2024, 3, 17, 6, 25, 2, 363, DateTimeKind.Local).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "New",
                keyColumn: "Id_New",
                keyValue: 3,
                column: "Created_at",
                value: new DateTime(2024, 3, 17, 6, 25, 2, 363, DateTimeKind.Local).AddTicks(8763));

            migrationBuilder.UpdateData(
                table: "New",
                keyColumn: "Id_New",
                keyValue: 4,
                column: "Created_at",
                value: new DateTime(2024, 3, 17, 6, 25, 2, 363, DateTimeKind.Local).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "New",
                keyColumn: "Id_New",
                keyValue: 5,
                column: "Created_at",
                value: new DateTime(2024, 3, 17, 6, 25, 2, 363, DateTimeKind.Local).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "New",
                keyColumn: "Id_New",
                keyValue: 6,
                column: "Created_at",
                value: new DateTime(2024, 3, 17, 6, 25, 2, 363, DateTimeKind.Local).AddTicks(8767));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Forum");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4b8b6a7b-39fa-4511-8c49-8435ec69cbfa", "AQAAAAIAAYagAAAAEOK/niXGSWUvMzfHXaC6gx1fR+WEUYUjjkKWygxNtyEb2uclqOBX3E9wr4FCdBilnA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b64cc01d-4317-4a44-88f6-a0cc4e2709ab"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d10867fa-0b79-4a30-b365-dd00fbc98887", "AQAAAAIAAYagAAAAEDsx9SsPGdwtje8HCXV2jYlhIJY3fFFX2B9S7rpCnWG89x7SyH13O4Uyb2jBa0jJZw==" });

            migrationBuilder.UpdateData(
                table: "Forum",
                keyColumn: "ID_Post",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 3, 17, 2, 54, 23, 961, DateTimeKind.Local).AddTicks(379));

            migrationBuilder.UpdateData(
                table: "New",
                keyColumn: "Id_New",
                keyValue: 1,
                column: "Created_at",
                value: new DateTime(2024, 3, 17, 2, 54, 23, 961, DateTimeKind.Local).AddTicks(224));

            migrationBuilder.UpdateData(
                table: "New",
                keyColumn: "Id_New",
                keyValue: 2,
                column: "Created_at",
                value: new DateTime(2024, 3, 17, 2, 54, 23, 961, DateTimeKind.Local).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "New",
                keyColumn: "Id_New",
                keyValue: 3,
                column: "Created_at",
                value: new DateTime(2024, 3, 17, 2, 54, 23, 961, DateTimeKind.Local).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "New",
                keyColumn: "Id_New",
                keyValue: 4,
                column: "Created_at",
                value: new DateTime(2024, 3, 17, 2, 54, 23, 961, DateTimeKind.Local).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "New",
                keyColumn: "Id_New",
                keyValue: 5,
                column: "Created_at",
                value: new DateTime(2024, 3, 17, 2, 54, 23, 961, DateTimeKind.Local).AddTicks(242));

            migrationBuilder.UpdateData(
                table: "New",
                keyColumn: "Id_New",
                keyValue: 6,
                column: "Created_at",
                value: new DateTime(2024, 3, 17, 2, 54, 23, 961, DateTimeKind.Local).AddTicks(244));
        }
    }
}
