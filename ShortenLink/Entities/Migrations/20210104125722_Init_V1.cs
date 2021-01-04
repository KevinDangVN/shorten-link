using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Init_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ad7e7c58-4b3a-11eb-ae93-0242ac130002"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEPcPMtALuM8X4iqdr36bOnatKe4K9x9cbrKJk927J59gUd5Wsi8tjCjVesqEdU3PjA==");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ffbed34c-4b39-11eb-ae93-0242ac130002"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEFpwdfiXgpRNNXTstwjvL26HP2SeavaGX2hXDV16TUaMoMNk4DDRwhqnj9mJzERfFQ==");

            migrationBuilder.InsertData(
                table: "LinkDatas",
                columns: new[] { "Id", "CreatedAt", "EmployeeId", "FullLink", "ShortLink" },
                values: new object[] { new Guid("a4a31ddf-d56a-4209-8030-d3a696edf8eb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ffbed34c-4b39-11eb-ae93-0242ac130002"), "https://www.google.com", "Google" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LinkDatas",
                keyColumn: "Id",
                keyValue: new Guid("a4a31ddf-d56a-4209-8030-d3a696edf8eb"));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ad7e7c58-4b3a-11eb-ae93-0242ac130002"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEAQHjBEpm9tKrt5Yw+zB8zrnLY95exiqUOdpHJNm/ILfP3UAJEAwojYEpS+qyjWVWA==");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ffbed34c-4b39-11eb-ae93-0242ac130002"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAECMlJV52Aw8+h6TCbnioD7WiBDsf6wYRKp7QP2InaVJcSMdxqfzHJ3Lv90PxdNO7hA==");
        }
    }
}
