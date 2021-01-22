using CDE.Domain.Entities;
using CDE.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDE.Domain.Models
{
    public class AtualizarProdutoViewModel
    {
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public int ProdutoQuantidade { get; set; }
        public bool ProdutoAtivo { get; set; }
        public ProdutoGrupo ProdutoGrupo { get; set; }
        public UnidadeMedida ProdutoUnidadeMedida { get; set; }

        public List<Localizacao> ProdutoLocalizacao { get; set; }
    }
}
