using Microsoft.EntityFrameworkCore.Migrations;

namespace CDE.Infra.Migrations
{
    public partial class primeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoNome = table.Column<string>(type: "varchar(40)", nullable: false),
                    ProdutoQuantidade = table.Column<int>(nullable: false),
                    ProdutoAtivo = table.Column<bool>(nullable: false),
                    ProdutoGrupo = table.Column<string>(type: "varchar(20)", nullable: false),
                    ProdutoUnidadeMedida = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioNome = table.Column<string>(type: "varchar(50)", nullable: false),
                    UsuarioCpf = table.Column<string>(type: "varchar(20)", nullable: false),
                    UsuarioEmail = table.Column<string>(type: "varchar(50)", nullable: false),
                    UsuarioSenha = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Localizacao",
                columns: table => new
                {
                    LocalizacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Andar = table.Column<string>(type: "char(3)", nullable: false),
                    Corredor = table.Column<string>(type: "varchar(20)", nullable: false),
                    Prateleira = table.Column<string>(type: "varchar(10)", nullable: false),
                    Vao = table.Column<string>(type: "varchar(10)", nullable: false),
                    ProdutoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacao", x => x.LocalizacaoId);
                    table.ForeignKey(
                        name: "FK_Localizacao_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Localizacao_ProdutoId",
                table: "Localizacao",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Localizacao");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
