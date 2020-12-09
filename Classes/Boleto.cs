namespace Abstração.Classes
{
    public class Boleto : Pagamento
    {
        private string codigoDeBarras;

        public string CodigoDeBarras{
            get{return codigoDeBarras;}
        }

        public void Registrar(string valor){
            this.codigoDeBarras = valor;
        }

       public override double Juros(int parcelas){
            if(parcelas > 12){
                juros = 1.05;
            } else{
                juros = 1;
            }
            return juros;
        }

        public override double Desconto(double Valor){
            desconto = 0.88;
            return desconto;
        }

        public double ValorFinal(double valor){
            double valorfinal = this.valor * desconto * juros;
            return valorfinal;
        }
    }
}