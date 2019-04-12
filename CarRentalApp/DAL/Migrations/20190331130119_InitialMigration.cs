using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Mark = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    ReleaseYear = table.Column<int>(nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    DrivingLicenseNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    RentalBeginDate = table.Column<DateTime>(nullable: false),
                    RentalEndDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Class", "Mark", "Model", "RegistrationNumber", "ReleaseYear" },
                values: new object[,]
                {
                    { 1, "A", "BMW", "X5", "d12e", 1998 },
                    { 2, "B", "Volkswagen", "B3", "d12e123", 1991 },
                    { 3, "C", "Reno", "Megane", "qwerty", 2006 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "DrivingLicenseNumber", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1977, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "123-abcd", "John", "Wick" },
                    { 2, new DateTime(1980, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "456-wert", "Vasya", "Petrov" },
                    { 3, new DateTime(1990, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "789-dsff", "Ivan", "Ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CarId", "Comment", "RentalBeginDate", "RentalEndDate", "UserId" },
                values: new object[] { 1, 1, "Some comment 1", new DateTime(2019, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CarId", "Comment", "RentalBeginDate", "RentalEndDate", "UserId" },
                values: new object[] { 2, 2, "Some comment 2", new DateTime(2019, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CarId", "Comment", "RentalBeginDate", "RentalEndDate", "UserId" },
                values: new object[] { 3, 3, "Some comment 3", new DateTime(2019, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                table: "Orders",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
