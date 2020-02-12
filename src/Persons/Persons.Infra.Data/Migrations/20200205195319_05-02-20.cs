using Microsoft.EntityFrameworkCore.Migrations;

namespace Persons.Infra.Data.Migrations
{
    public partial class _050220 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.EnsureSchema(
                name: "Account");

            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "User");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "User",
                table: "Users",
                newName: "Last_Name");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                schema: "User",
                table: "Users",
                type: "varchar(20)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                schema: "User",
                table: "Users",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<short>(
                name: "Roles",
                schema: "User",
                table: "Users",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Status",
                schema: "User",
                table: "Users",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Id_User = table.Column<long>(maxLength: 100, nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_Id_User",
                        column: x => x.Id_User,
                        principalSchema: "User",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "User",
                table: "Users",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Id_User",
                schema: "Account",
                table: "Accounts",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Login",
                schema: "Account",
                table: "Accounts",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                schema: "User",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Roles",
                schema: "User",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "User",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "User",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastName",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Users",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
