namespace Abstração.Classes
{
    public class Debito : Cartao
    {
        private double saldo = 2000;

        public double Saldo{
            get{return saldo;}
            set{saldo = value;}
        }

         public override double Juros(int parcelas){
            return 0;
        }

        public override double Desconto(double valor){
            if(valor >= 400){
                desconto = 0.95;
            }else{
                desconto = 1;
            }
            return desconto;
        }


        public double Pagar(double valor){
            this.valor =  this.valor * desconto;
            return this.valor;
        }
    }
}