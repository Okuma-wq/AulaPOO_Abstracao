using System;

namespace Abstração.Classes
{
    public abstract class Pagamento
    {
        private DateTime data;
        protected double valor;

        public double Valor{
            get{return valor;}
            set{valor = value;}
        }

        public string Cancelar(){
            return "";
        }

        public abstract double Desconto(double valor);

        protected double desconto;

        public abstract double Juros(int parcelas);

        protected double juros;
    }
}