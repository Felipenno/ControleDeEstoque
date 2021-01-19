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
        public Produto Produto { get; set; }

        public Localizacao(int localizacaoId, string andar, string corredor, string prateleira, string vao)
        {
            LocalizacaoId = localizacaoId;
            Andar = andar;
            Corredor = corredor;
            Prateleira = prateleira;
            Vao = vao;
        }

        protected Localizacao() { }
        

        
    }
}
