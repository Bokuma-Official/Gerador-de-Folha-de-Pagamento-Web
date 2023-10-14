namespace Gerador_de_Folha_de_Pagamento_Web.Models
{
    public class Contrato_Ataron
    {
        public int ID_Contrato_Empresa { get; set; }
        public string Data_Admissao { get; set; }
        public string Numero_Conta { get; set; }
        public int Numero_Agencia { get; set; }
        public string Nome_Agencia { get; set; }
        public string Tipo_Contrato { get; set; }
        public string Cargo { get; set; }
        public string CBO_Cargo { get; set; }
        public string Departamento { get; set; }
        public string CPF { get; set; }
    }
}
