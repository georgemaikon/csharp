using ProjetoConta.Enum;

namespace ProjetoConta.Classes
{
    public class Conta
    {
        private string Nome { get; set; }
        private double Credito { get; set; }
        private double Saldo { get; set; }
        private TipoConta TipoConta { get; set; }

        public Conta(string nome, double credito, double saldo, TipoConta tipoconta){
            this.Nome = nome;
            this.Credito = credito;
            this.Saldo = saldo;
            this.TipoConta = tipoconta;
        }

        public bool Sacar(double valor){
            if ((this.Saldo + this.Credito) < valor){
                return false;
            }
            this.Saldo -= valor;
            return true;
        }

        public void Depositar(double valor){
            this.Saldo += valor;
        }

        public bool Transferir(double valor, Conta contaDestino){
            if (this.Sacar(valor)){
                contaDestino.Depositar(valor);
                return true;
            }
            else {
                return false;
            }
        }

        public override string ToString(){
            string retorno = "Nome: " + this.Nome + " | ";
            retorno += "Tipo Conta: " + this.TipoConta + " | ";
            retorno += "Limite Crédito: " + this.Credito + " | ";
            retorno += "Saldo Atual: " + this.Saldo;
            return retorno;
        }

    }
}
