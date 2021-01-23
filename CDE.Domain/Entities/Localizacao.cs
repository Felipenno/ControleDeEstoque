namespace CDE.Domain.Entities
{
    public class Localizacao
    {
        public int LocalizacaoId { get; private set; }
        public string Andar { get; private set; }
        public string Corredor { get; private set; }
        public string Prateleira { get; private set; }
        public string Vao { get; private set; }

        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        public Localizacao(string andar, string corredor, string prateleira, string vao, int produtoId)
        {
            Andar = andar;
            Corredor = corredor;
            Prateleira = prateleira;
            Vao = vao;
            ProdutoId = produtoId;
        }

        public Localizacao(int localizacaoId, string andar, string corredor, string prateleira, string vao, int produtoId) : this(andar, corredor, prateleira, vao, produtoId)
        {
            LocalizacaoId = localizacaoId;
        }

        protected Localizacao() { }



    }
}
