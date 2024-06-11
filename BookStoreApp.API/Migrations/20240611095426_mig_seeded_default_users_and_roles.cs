using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class mig_seeded_default_users_and_roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5bdab554-0ee1-4982-9504-954f7d8fc914", null, "Administrator", "ADMINISTRATOR" },
                    { "9aa8bc2f-4ec2-407d-8eec-68f51888f551", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "529b907c-4e62-4323-8daf-32c21bf5bc27", 0, "0b31a84f-6e21-4994-ac53-6babdf372ff4", "mertgnd36@gmail.com", false, "System", "Admin", false, null, "MERTGND36@GMAIL.COM", "MERTGND36@GMAIL.COM", "AQAAAAIAAYagAAAAEKNil3cudzGlx/HfR7bMK4lThGolndYg0qlpIR3PXNWzyvPxmWobyRAgWow3LCXbFg==", null, false, "6b13c541-3c62-4017-8749-224fa5d4e083", false, "mertgnd36@gmail.com" },
                    { "7468628c-d10b-4d62-9a95-b23799423771", 0, "ce255729-7d6c-487f-b0d2-5aa56f513239", "user@gmail.com", false, "System", "User", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEHEYiaapVytSp9ekbc2fb9DRqCGG6SDIChgHu83BKGwtf63llDH6Z+GTOPBHViRaPA==", null, false, "6429b2e5-a40c-421c-9694-2b74c2fd3eee", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5bdab554-0ee1-4982-9504-954f7d8fc914", "529b907c-4e62-4323-8daf-32c21bf5bc27" },
                    { "9aa8bc2f-4ec2-407d-8eec-68f51888f551", "7468628c-d10b-4d62-9a95-b23799423771" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5bdab554-0ee1-4982-9504-954f7d8fc914", "529b907c-4e62-4323-8daf-32c21bf5bc27" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9aa8bc2f-4ec2-407d-8eec-68f51888f551", "7468628c-d10b-4d62-9a95-b23799423771" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bdab554-0ee1-4982-9504-954f7d8fc914");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa8bc2f-4ec2-407d-8eec-68f51888f551");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "529b907c-4e62-4323-8daf-32c21bf5bc27");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7468628c-d10b-4d62-9a95-b23799423771");
        }
    }
}
