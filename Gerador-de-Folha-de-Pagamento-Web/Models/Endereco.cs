namespace Gerador_de_Folha_de_Pagamento_Web.Models
{
    public class Endereco
    {
        public int ID_Endereco { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CPF { get; set; }
    }
}
