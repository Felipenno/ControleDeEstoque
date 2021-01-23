using CDE.Domain.Entities;
using CDE.Domain.Enum;
using System.Collections.Generic;

namespace CDE.Domain.Models
{
    public class ListarProdutosViewModel
    {
        public int ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public int ProdutoQuantidade { get; private set; }
        public bool ProdutoAtivo { get; private set; }
        public ProdutoGrupo ProdutoGrupo { get; private set; }
        public UnidadeMedida ProdutoUnidadeMedida { get; private set; }

        public List<LocalizacaoModel> ProdutoLocalizacao { get; private set; }

        public ListarProdutosViewModel(int produtoId, string produtoNome, int produtoQuantidade, bool produtoAtivo, ProdutoGrupo produtoGrupo, UnidadeMedida produtoUnidadeMedida, List<Localizacao> localizacao)
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            ProdutoQuantidade = produtoQuantidade;
            ProdutoAtivo = produtoAtivo;
            ProdutoGrupo = produtoGrupo;
            ProdutoUnidadeMedida = produtoUnidadeMedida;
            ProdutoLocalizacao = new List<LocalizacaoModel>();
            foreach (Localizacao l in localizacao)
            {
                ProdutoLocalizacao.Add(new LocalizacaoModel(l.Andar, l.Corredor, l.Prateleira, l.Vao));
            }
        }
    }
}
