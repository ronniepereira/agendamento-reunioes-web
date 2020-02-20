using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendamentoReunioesApp.Migrations
{
    public partial class AddTituloAgendamentoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Agendamento",
                type: "varchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Agendamento");
        }
    }
}
