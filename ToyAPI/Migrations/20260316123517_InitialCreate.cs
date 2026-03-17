using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToyAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TDS_TB_Brinquedos",
                columns: table => new
                {
                    Id_brinquedo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome_brinquedo = table.Column<string>(type: "NVARCHAR2(120)", maxLength: 120, nullable: false),
                    Tipo_brinquedo = table.Column<string>(type: "NVARCHAR2(60)", maxLength: 60, nullable: false),
                    Classificacao = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Tamanho = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDS_TB_Brinquedos", x => x.Id_brinquedo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TDS_TB_Brinquedos");
        }
    }
}
