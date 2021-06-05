using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }


        //******************************MÉTODO DE SACAR*******************************
        public bool Sacar(double valorSaque)
        {
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque; //é o mesmo que fazer:   this.Saldo = this.Saldo - valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            // https://docs.microsoft.com/pt-br/dotnet/standerd/base-types/composite-formatting 

            return true;
        }

        //******************************MÉTODO DE DEPÓSITO******************************
        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;  // é o mesmo que:   this.Saldo = this.Saldo + valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        //***************************MÉTODO DE TRANSFERÊNCIA**************************
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        //***********************REPRESENTAÇÃO DA INTÂNCIA NO CONSOLE**********************
        public override string ToString()     // ToString serve para gravar (log) e entender o que ocorre na aplicação 
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
            return retorno;
        }
    }
}