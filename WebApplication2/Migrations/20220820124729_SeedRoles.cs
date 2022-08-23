using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class SeedRoles : Migration
    {
        private string FreeUserId = Guid.NewGuid().ToString();
        private string DonatUserId = Guid.NewGuid().ToString();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);
        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{FreeUserId}', 'FreeUser', 'FREEUSER', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{DonatUserId}', 'DonatUser', 'DONATUSER', null);");
        }



        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}





