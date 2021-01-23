using CDE.Domain.Enum;

namespace CDE.Domain.Models
{
    public class ListarLocalizacoesViewModel
    {
        public int LocalizacaoId { get; private set; }
        public string Andar { get; private set; }
        public string Corredor { get; private set; }
        public string Prateleira { get; private set; }
        public string Vao { get; private set; }

        public ProdutoModel Produto { get; set; }

        public ListarLocalizacoesViewModel(int localizacaoId, string andar, string corredor, string prateleira, string vao, string produtoNome, int produtoQuantidade, bool produtoAtivo, ProdutoGrupo produtoGrupo, UnidadeMedida produtoUnidadeMedida)
        {
            LocalizacaoId = localizacaoId;
            Andar = andar;
            Corredor = corredor;
            Prateleira = prateleira;
            Vao = vao;

            Produto = new ProdutoModel(produtoNome, produtoQuantidade, produtoAtivo, produtoGrupo, produtoUnidadeMedida);
        }
    }
}
