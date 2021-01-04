using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_RoleModel_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkDatas_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RoleModel",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("aeeccc6d-e50f-43d9-92cf-e5b89acb8c83"), "Admin" });

            migrationBuilder.InsertData(
                table: "RoleModel",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("6f6c4608-4b39-11eb-ae93-0242ac130002"), "Employee" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FullName", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("ad7e7c58-4b3a-11eb-ae93-0242ac130002"), "mail_2@mail.com", "Nguyen Van N", "AQAAAAEAACcQAAAAEAQHjBEpm9tKrt5Yw+zB8zrnLY95exiqUOdpHJNm/ILfP3UAJEAwojYEpS+qyjWVWA==", new Guid("aeeccc6d-e50f-43d9-92cf-e5b89acb8c83"), "admin" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FullName", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("ffbed34c-4b39-11eb-ae93-0242ac130002"), "mail_1@mail.com", "Nguyen Van A", "AQAAAAEAACcQAAAAECMlJV52Aw8+h6TCbnioD7WiBDsf6wYRKp7QP2InaVJcSMdxqfzHJ3Lv90PxdNO7hA==", new Guid("6f6c4608-4b39-11eb-ae93-0242ac130002"), "user" });

            migrationBuilder.InsertData(
                table: "LinkDatas",
                columns: new[] { "Id", "CreatedAt", "EmployeeId", "FullLink", "ShortLink" },
                values: new object[] { new Guid("867e6316-4b44-11eb-ae93-0242ac130002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ffbed34c-4b39-11eb-ae93-0242ac130002"), "https://www.google.com", "google" });

            migrationBuilder.InsertData(
                table: "LinkDatas",
                columns: new[] { "Id", "CreatedAt", "EmployeeId", "FullLink", "ShortLink" },
                values: new object[] { new Guid("a63771fc-4b44-11eb-ae93-0242ac130002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ffbed34c-4b39-11eb-ae93-0242ac130002"), "https://www.uuidgenerator.net/version1", "uuidgen" });

            migrationBuilder.InsertData(
                table: "LinkDatas",
                columns: new[] { "Id", "CreatedAt", "EmployeeId", "FullLink", "ShortLink" },
                values: new object[] { new Guid("11f7fba0-4b45-11eb-ae93-0242ac130002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ffbed34c-4b39-11eb-ae93-0242ac130002"), "https://www.uuidgenerator.net/version4", "uuidgen4" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkDatas_EmployeeId",
                table: "LinkDatas",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkDatas");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "RoleModel");
        }
    }
}
