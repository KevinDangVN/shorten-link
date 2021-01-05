using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class init_v1 : Migration
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
                    Count = table.Column<int>(type: "int", nullable: false),
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
                values: new object[] { new Guid("ad7e7c58-4b3a-11eb-ae93-0242ac130002"), "mail_2@mail.com", "Nguyen Van N", "AQAAAAEAACcQAAAAEP7z3pyKo4Jczkv3Ki+QsDOk/etv81vjUOo4YPQC/7YdIwoNMatOfHl7YDc5aIlS3Q==", new Guid("aeeccc6d-e50f-43d9-92cf-e5b89acb8c83"), "admin" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FullName", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("ffbed34c-4b39-11eb-ae93-0242ac130002"), "mail_1@mail.com", "Nguyen Van A", "AQAAAAEAACcQAAAAEMgx+n/MIyy/JV2Zc0eKsPIUx6wp1K+DQOLPowCESO2RNpQ3AKdYoe1L7z478MMVvw==", new Guid("6f6c4608-4b39-11eb-ae93-0242ac130002"), "user" });

            migrationBuilder.InsertData(
                table: "LinkDatas",
                columns: new[] { "Id", "Count", "CreatedAt", "EmployeeId", "FullLink", "ShortLink" },
                values: new object[,]
                {
                    { new Guid("867e6316-4b44-11eb-ae93-0242ac130002"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ffbed34c-4b39-11eb-ae93-0242ac130002"), "https://www.google.com", "google" },
                    { new Guid("a63771fc-4b44-11eb-ae93-0242ac130002"), 0, new DateTime(2021, 1, 5, 10, 44, 44, 4, DateTimeKind.Local).AddTicks(3435), new Guid("ffbed34c-4b39-11eb-ae93-0242ac130002"), "https://www.uuidgenerator.net/version1", "uuidgen" },
                    { new Guid("a4a31ddf-d56a-4209-8030-d3a696edf8eb"), 0, new DateTime(2021, 1, 5, 10, 44, 44, 5, DateTimeKind.Local).AddTicks(739), new Guid("ffbed34c-4b39-11eb-ae93-0242ac130002"), "https://thanhnien.vn/", "thanhnien" },
                    { new Guid("11f7fba0-4b45-11eb-ae93-0242ac130002"), 0, new DateTime(2021, 1, 5, 10, 44, 44, 5, DateTimeKind.Local).AddTicks(756), new Guid("ffbed34c-4b39-11eb-ae93-0242ac130002"), "https://www.uuidgenerator.net/version4", "uuidgen4" }
                });

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
