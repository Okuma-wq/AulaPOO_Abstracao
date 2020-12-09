namespace Abstração.Classes
{
    public class Credito : Cartao
    {
        private float limite = 1000;

        public float Limite{
            get{return limite;}
            set{limite = value;}
        }

        public override double Juros(int parcelas){
            if(parcelas > 12){
                return 1.05;
            } else{
                return 0;
            }
        }

        public override double Desconto(double valor){
            if(valor >= 400){
                return 0.9;
            }else{
                return 0;
            }
        }

        public double Pagar(double valor){
            this.valor =  this.valor * desconto;
            return this.valor;
        }
    }
}