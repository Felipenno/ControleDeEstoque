using CDE.Domain.Enum;
using System.Collections.Generic;

namespace CDE.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public int ProdutoQuantidade { get; set; }
        public bool ProdutoAtivo { get; set; }
        public ProdutoGrupo ProdutoGrupo { get; set; }
        public UnidadeMedida ProdutoUnidadeMedida { get; set; }

        public List<Localizacao> ProdutoLocalizacao { get; set; }

        public Produto(int produtoId, string produtoNome, int produtoQuantidade, bool produtoAtivo, ProdutoGrupo produtoGrupo, UnidadeMedida produtoUnidadeMedida, List<Localizacao> produtoLocalizacao)
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            ProdutoQuantidade = produtoQuantidade;
            ProdutoAtivo = produtoAtivo;
            ProdutoGrupo = produtoGrupo;
            ProdutoUnidadeMedida = produtoUnidadeMedida;
            ProdutoLocalizacao = produtoLocalizacao;
        }

        protected Produto() { }
    }
}
