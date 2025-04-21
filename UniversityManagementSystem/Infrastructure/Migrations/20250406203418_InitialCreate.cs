using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Groups_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("8a5fcac4-3e4c-4c66-bd7f-5f2f909d2a4d"), "AI principles, algorithms, and practical applications of machine learning.", "Artificial Intelligence and Machine Learning" },
                    { new Guid("9d28bdbc-cda2-4d4b-b421-16db5de017cf"), "Design, development, and maintenance of software systems.", "Software Engineering" },
                    { new Guid("b10e1d67-3f77-4a43-9e6f-1cfe8d09fba4"), "Fundamentals of computer science and modern information technologies.", "Computer Science and Information Technology" },
                    { new Guid("c5fbb908-4f91-4b1a-a9e6-4df5b1f0f7b4"), "Development and management of information systems and digital technologies.", "Information Systems and Technology" },
                    { new Guid("e18f0912-62a1-448e-9332-bdb04c3e46b5"), "Principles and practices of protecting systems, networks, and programs from cyber attacks.", "Cybersecurity" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "CourseId", "Name" },
                values: new object[,]
                {
                    { new Guid("b82f93c2-6e1b-4a66-b3c1-3a6f34f1d6d7"), new Guid("8a5fcac4-3e4c-4c66-bd7f-5f2f909d2a4d"), "AI-501" },
                    { new Guid("c80e2b37-2b72-4d7f-8a9f-1a2b73f9f0d1"), new Guid("e18f0912-62a1-448e-9332-bdb04c3e46b5"), "CY-301" },
                    { new Guid("d67cba09-45a7-4f2b-9c5b-8a0f8d4e6e6f"), new Guid("c5fbb908-4f91-4b1a-a9e6-4df5b1f0f7b4"), "IT-401" },
                    { new Guid("f06c2b13-5d3c-4bfb-9c8f-81968b1c43b7"), new Guid("b10e1d67-3f77-4a43-9e6f-1cfe8d09fba4"), "CS-101" },
                    { new Guid("fdba714b-5b56-4b07-9e93-541fc57f2b85"), new Guid("9d28bdbc-cda2-4d4b-b421-16db5de017cf"), "SE-201" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "GroupId", "LastName" },
                values: new object[,]
                {
                    { new Guid("a6b7c8d9-2f1a-4e3d-0b5f-7f4e9d5c6a8b"), "Kate", new Guid("b82f93c2-6e1b-4a66-b3c1-3a6f34f1d6d7"), "Adams" },
                    { new Guid("a9b6f7c5-2b1a-4e7d-3a0f-6e9c2f4d8b5a"), "Frank", new Guid("c80e2b37-2b72-4d7f-8a9f-1a2b73f9f0d1"), "Brown" },
                    { new Guid("b6a3c8f5-3a4f-4c66-8a4b-5d2f9f1c6a1a"), "Alice", new Guid("f06c2b13-5d3c-4bfb-9c8f-81968b1c43b7"), "Johnson" },
                    { new Guid("c7d6f8b9-4a0f-5b7c-2b1a-6e9b4e7f3c2d"), "Dave", new Guid("fdba714b-5b56-4b07-9e93-541fc57f2b85"), "Wilson" },
                    { new Guid("d2b1f9e2-8a0f-4a7b-9c5b-6e4e6f8d3c5b"), "Bob", new Guid("f06c2b13-5d3c-4bfb-9c8f-81968b1c43b7"), "Smith" },
                    { new Guid("d9f8b7c6-4a0f-2b1a-6e7d-3c4e5f9a8b5b"), "Henry", new Guid("d67cba09-45a7-4f2b-9c5b-8a0f8d4e6e6f"), "Clark" },
                    { new Guid("e3f9d6b2-7c5b-4a0f-8a9b-1a2f4e7b9d6c"), "Charlie", new Guid("fdba714b-5b56-4b07-9e93-541fc57f2b85"), "Davis" },
                    { new Guid("e7b9c6f5-2a1a-4d3c-0f6e-8b5a7f4b9d6c"), "Ivy", new Guid("d67cba09-45a7-4f2b-9c5b-8a0f8d4e6e6f"), "Moore" },
                    { new Guid("f2b1a9b6-4e7b-6c5d-3a0f-9d4c2e7f8b5a"), "Eve", new Guid("fdba714b-5b56-4b07-9e93-541fc57f2b85"), "Taylor" },
                    { new Guid("f4e7c5b6-2b1a-3a0f-9d6e-9b4d8b5a7f2b"), "Grace", new Guid("c80e2b37-2b72-4d7f-8a9f-1a2b73f9f0d1"), "Miller" },
                    { new Guid("f8c7b6a9-2b1a-4d3c-0f6e-5b4e7f9d6a5b"), "Jack", new Guid("b82f93c2-6e1b-4a66-b3c1-3a6f34f1d6d7"), "Evans" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseId",
                table: "Groups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
