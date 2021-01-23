using CDE.Domain.Enum;
using System.Collections.Generic;

namespace CDE.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public int ProdutoQuantidade { get; private set; }
        public bool ProdutoAtivo { get; private set; }
        public ProdutoGrupo ProdutoGrupo { get; private set; }
        public UnidadeMedida ProdutoUnidadeMedida { get; private set; }

        public List<Localizacao> ProdutoLocalizacao { get; private set; }

        public Produto(string produtoNome, int produtoQuantidade, bool produtoAtivo, ProdutoGrupo produtoGrupo, UnidadeMedida produtoUnidadeMedida)
        {
            ProdutoNome = produtoNome;
            ProdutoQuantidade = produtoQuantidade;
            ProdutoAtivo = produtoAtivo;
            ProdutoGrupo = produtoGrupo;
            ProdutoUnidadeMedida = produtoUnidadeMedida;
        }

        public Produto(int produtoId, string produtoNome, int produtoQuantidade, bool produtoAtivo, ProdutoGrupo produtoGrupo, UnidadeMedida produtoUnidadeMedida) : this(produtoNome, produtoQuantidade, produtoAtivo, produtoGrupo, produtoUnidadeMedida)
        {
            ProdutoId = produtoId;

        }

        protected Produto() { }
    }
}
