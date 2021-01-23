using CDE.Domain.Enum;

namespace CDE.Domain.Models
{
    public class ProdutoModel
    {
        public string ProdutoNome { get; private set; }
        public int ProdutoQuantidade { get; private set; }
        public bool ProdutoAtivo { get; private set; }
        public ProdutoGrupo ProdutoGrupo { get; private set; }
        public UnidadeMedida ProdutoUnidadeMedida { get; private set; }

        public ProdutoModel(string produtoNome, int produtoQuantidade, bool produtoAtivo, ProdutoGrupo produtoGrupo, UnidadeMedida produtoUnidadeMedida)
        {
            ProdutoNome = produtoNome;
            ProdutoQuantidade = produtoQuantidade;
            ProdutoAtivo = produtoAtivo;
            ProdutoGrupo = produtoGrupo;
            ProdutoUnidadeMedida = produtoUnidadeMedida;
        }
    }
}
