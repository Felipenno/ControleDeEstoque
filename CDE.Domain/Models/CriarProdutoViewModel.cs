using CDE.Domain.Enum;

namespace CDE.Domain.Models
{
    public class CriarProdutoViewModel
    {
        public string ProdutoNome { get; set; }
        public int ProdutoQuantidade { get; set; }
        public bool ProdutoAtivo { get; set; }
        public ProdutoGrupo ProdutoGrupo { get; set; }
        public UnidadeMedida ProdutoUnidadeMedida { get; set; }

    }
}
