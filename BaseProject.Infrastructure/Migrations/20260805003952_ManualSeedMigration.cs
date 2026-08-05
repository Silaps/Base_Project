using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ManualSeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into ElementTypes (Name) values ('Input'), ('Select')");
            migrationBuilder.Sql("insert into Elements (Name, ElementTypeId) values ('Text', 1), ('Number', 1), ('Email', 1), ('Password', 1), ('Select', 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Elements where Name in ('Text', 'Number', 'Email', 'Password', 'Select')");
            migrationBuilder.Sql("delete from ElementTypes where Name in ('Input', 'Select')");
        }
    }
}
