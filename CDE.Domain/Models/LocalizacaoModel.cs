namespace CDE.Domain.Models
{
    public class LocalizacaoModel
    {
        public string Andar { get; private set; }
        public string Corredor { get; private set; }
        public string Prateleira { get; private set; }
        public string Vao { get; private set; }

        public LocalizacaoModel(string andar, string corredor, string prateleira, string vao)
        {
            Andar = andar;
            Corredor = corredor;
            Prateleira = prateleira;
            Vao = vao;
        }
    }
}
