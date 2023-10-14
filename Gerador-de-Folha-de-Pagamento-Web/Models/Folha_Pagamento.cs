namespace Gerador_de_Folha_de_Pagamento_Web.Models
{
    public class Folha_Pagamento
    {
        public int ID_Folha_Pagamento { get; set; }
        public string Data_Pagamento { get; set; }
        public int Horas_Trabalhadas { get; set; }
        public string Valor_Hora { get; set; }
        public int Horas_Faltas { get; set; }
        public string Desconto_Horas_Faltas { get; set; }
        public int Horas_Extras { get; set; }
        public string Valor_Horas_Extras { get; set; }
        public string Valor_Vale_Transporte { get; set; }
        public string Valor_Vale_Alimentacao { get; set; }
        public string Desconto_INSS { get; set; }
        public string Desconto_FGTS { get; set; }
        public string Desconto_IRRF { get; set; }
        public string Desconto_Vale_Transporte { get; set; }
        public string Desconto_Vale_Alimentacao { get; set; }
        public string Desconto_Seguro_Vida { get; set; }
        public int Dias_Ferias { get; set; }
        public string Valor_Ferias { get; set; }
        public string Valor_13_Salario { get; set; }
        public string Salario_Bruto { get; set; }
        public string Salario_Liquido { get; set; }
        public string CPF { get; set; }
    }
}
