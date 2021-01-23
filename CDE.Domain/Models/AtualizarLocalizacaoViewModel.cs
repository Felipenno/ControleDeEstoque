namespace CDE.Domain.Models
{
    public class AtualizarLocalizacaoViewModel
    {
        public int LocalizacaoId { get; set; }
        public string Andar { get; set; }
        public string Corredor { get; set; }
        public string Prateleira { get; set; }
        public string Vao { get; set; }
        public int ProdutoId { get; set; }
    }
}
