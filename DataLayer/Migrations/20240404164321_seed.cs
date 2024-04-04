using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { new Guid("683b30d6-70b8-4e1d-b531-cfc5e327f124"), "Basic subscription", "Basic", 10.00m });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d39ea4fd-2900-4ce6-a81e-8fed108fe5e7"), "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "ProfileId", "TypeId" },
                values: new object[] { new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3301"), "john@email.com", "John", "**********", new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"), new Guid("d39ea4fd-2900-4ce6-a81e-8fed108fe5e7") });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Followers", "Name", "UserId" },
                values: new object[] { new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"), "This is John's profile", 2, "John's profile", new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3301") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("683b30d6-70b8-4e1d-b531-cfc5e327f124"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3301"));

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: new Guid("d39ea4fd-2900-4ce6-a81e-8fed108fe5e7"));

        }
    }
}
