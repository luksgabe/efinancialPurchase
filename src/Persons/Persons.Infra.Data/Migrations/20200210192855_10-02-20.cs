using Microsoft.EntityFrameworkCore.Migrations;

namespace Persons.Infra.Data.Migrations
{
    public partial class _100220 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "User",
                table: "Users",
                columns: new[] { "Id", "Cpf", "Email", "Last_Name", "Name", "Roles", "Status" },
                values: new object[] { 1L, "85100790059", "85100790059", "Pereira da Silva", "Lucas Gabriel", (short)3, (short)1 });

            migrationBuilder.InsertData(
                schema: "Account",
                table: "Accounts",
                columns: new[] { "Id", "Id_User", "Login", "Password", "Status" },
                values: new object[] { 1L, 1L, "vjQeBi/dPnPLFVDwZRJUHEE17h2i7Sjmwh188EcNgt7UuAugafd2c9OkojKw33mf0o/UopfzbeZALFQildtJUg==", "z8uY8pIDZ/SjS6/dQjksAkqzNXqQ2qL+GP8+UV/bZfDCqLZLF9X2QkgMUFZIqwUhX1HLTitxHSU54u23Erz+vA==", (short)1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Account",
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
