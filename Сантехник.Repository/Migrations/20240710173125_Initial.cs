using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Сантехник.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdateDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Call = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Map = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdateDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomePages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    VideoLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdateDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdateDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linkedin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdateDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linkedin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdateDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdateDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdateDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Clients = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Projects = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    HardWorkers = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    HoursOfSupport = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialMediaId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdateDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abouts_SocialMedias_SocialMediaId",
                        column: x => x.SocialMediaId,
                        principalTable: "SocialMedias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "082f1b6e-f029-48dd-96c6-65ed997c52ed", "3087e9f4-6a9d-4b84-b421-a5d91642f427", "Member", "MEMBER" },
                    { "799d7862-0ed0-4c31-bf73-d31162d7795a", "737696f3-5d96-4612-8c2b-9e32e186fd45", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FileName", "FileType", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4802aed0-8173-4fc3-8bcd-376fb946c05b", 0, "222f29fb-3baa-4143-811a-1c46b005a6ca", "obergannikita@gmail.com", false, null, null, false, null, "OBERGANNIKITA@GMAIL.COM", "TESTADMIN", "AQAAAAIAAYagAAAAEM489c4mDd6FlTn4FDwGGilsxf5MYnBqj2KkcwrT/Nd/O1cr6f9WVeQF8bSdR8kmqQ==", null, false, "2343c9fc-6452-4da0-a458-edb11cd85eff", false, "TestAdmin" },
                    { "b2451b7d-f879-424a-9b48-816f44b7b5a9", 0, "709efdad-0fb8-41a6-b3fc-c74f0e16a384", "obergannikita2@gmail.com", false, null, null, false, null, "OBERGANNIKITA2@GMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAEEAQWW+nE/5WBo6GkOyACvhIxG+druWUChLhLWnXuU6l4BwEx6jC6blemZftQ5LMtg==", null, false, "0162591d-97b7-4f84-a79c-d66757a0991a", false, "TestMember" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "7/10/2024", "Pojects", null },
                    { 2, "7/10/2024", "Proplets", null }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Call", "CreatedDate", "Email", "Location", "Map", "UpdateDate" },
                values: new object[] { 1, "123456789", "7/10/2024", "test@gmail.com", "123 Demon St.", "testlink", null });

            migrationBuilder.InsertData(
                table: "HomePages",
                columns: new[] { "Id", "CreatedDate", "Description", "Header", "UpdateDate", "VideoLink" },
                values: new object[] { 1, "7/10/2024", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Test header for Home Page", null, "Video link test" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedDate", "Description", "Icon", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "7/10/2024", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "bi bi-facebook", "Plumbing Service", null },
                    { 2, "7/10/2024", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "bi bi-facebook", "Plumbing Service2", null },
                    { 3, "7/10/2024", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "bi bi-facebook", "Plumbing Service3", null },
                    { 4, "7/10/2024", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "bi bi-facebook", "Plumbing Service4", null }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "AboutUsId", "CreatedDate", "Facebook", "Instagram", "Linkedin", "Twitter", "UpdateDate" },
                values: new object[] { 1, 0, "7/10/2024", "test", "test", "test", "test", null });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedDate", "Facebook", "FileName", "FileType", "FullName", "Instagram", "Linkedin", "Title", "Twitter", "UpdateDate" },
                values: new object[] { 1, "7/10/2024", "test", "test", "test", "Test FullName for Team", "test", "test", "Test Title Name", "test", null });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "Comment", "CreatedDate", "FileName", "FileType", "FullName", "Title", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "Test comment for Testimonial", "7/10/2024", "test", "test", "Test FullName for Testimonial", "Test title for Testimonial", null },
                    { 2, "Test comment for Testimonial", "7/10/2024", "test2", "test2", "Test FullName for Testimonial", "Test title for Testimonial", null },
                    { 3, "Test comment for Testimonial", "7/10/2024", "test3", "test3", "Test FullName for Testimonial", "Test title for Testimonial", null }
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Clients", "CreatedDate", "Description", "FileName", "FileType", "HardWorkers", "Header", "HoursOfSupport", "Projects", "SocialMediaId", "UpdateDate" },
                values: new object[] { 1, 5, "7/10/2024", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "test", "test", 12, "Lorem Ipsum is simply dummy text of the printing", 120, 4, 1, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { "799d7862-0ed0-4c31-bf73-d31162d7795a", "4802aed0-8173-4fc3-8bcd-376fb946c05b", "AppUserRole" },
                    { "082f1b6e-f029-48dd-96c6-65ed997c52ed", "b2451b7d-f879-424a-9b48-816f44b7b5a9", "AppUserRole" }
                });

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "FileName", "FileType", "Title", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, "7/10/2024", "test", "test", "Test portfolio title", null },
                    { 2, 1, "7/10/2024", "test2", "test2", "Test2 portfolio title", null },
                    { 3, 2, "7/10/2024", "test3", "test3", "Test3 portfolio title", null },
                    { 4, 2, "7/10/2024", "test4", "test4", "Test4 portfolio title", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_SocialMediaId",
                table: "Abouts",
                column: "SocialMediaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_CategoryId",
                table: "Portfolios",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "HomePages");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
