using System;
using System.Collections.Generic;
using ProjetoConta.Classes;
using ProjetoConta.Enum;

namespace ProjetoConta
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            int opcaoUsuario = ObterOpcao();
            while (opcaoUsuario > 0)
            {
                switch (opcaoUsuario)
                {
                    case 1:
                        ListarContas();
                        break;
                    case 2:
                        InserirConta();
                        break;
                    case 3:
                        Transferencia();
                        break;
                    case 4: 
                        Saque();
                        break;
                    case 5:
                        Deposito();    
                        break;
                    default:
                        throw new ArgumentNullException("Número inválido");
                }
                opcaoUsuario = ObterOpcao();
            }
            Console.WriteLine("Finalizando...");
        }

        private static int ObterOpcao(){
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Tranferência");
            Console.WriteLine("4 - Saque");
            Console.WriteLine("5 - Deposito");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
            Console.Write("Digite a opção: ");
            int opcaoUsuario = int.Parse(Console.ReadLine());
            return opcaoUsuario; 
        }

        private static void ListarContas(){
            Console.WriteLine("Relação de Contas Cadastradas.");
            int contador = 0;
            if (listContas.Count == 0){
                Console.WriteLine("Não há contas cadastradas.");
                return;
            }
            foreach (Conta conta in listContas)
            {
                Console.WriteLine($"Conta nº {contador} - " + conta.ToString());
                contador++;
            }
        }

        private static void Transferencia(){
            ListarContas();

            Console.Write("Digite o numero da conta de origem: ");
            int contaOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o numero da conta de destino: ");
            int contaDestino = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor da transferência: ");
            double valor = double.Parse(Console.ReadLine());

            if (!listContas[contaOrigem].Transferir(valor, listContas[contaDestino])){
                Console.WriteLine("Saldo insuficiente!");
                return;
            }
            Console.WriteLine("Tranferência realizada com sucesso.");
        }

        private static void Saque(){
            ListarContas();

            Console.Write("Digite o número da conta: ");
            int nuconta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor do saque: ");
            double valor = double.Parse(Console.ReadLine());
            if (!listContas[nuconta].Sacar(valor)){
                Console.WriteLine("Saldo insuficiente!");
                return;
            }
            Console.WriteLine("Saque realizado com sucesso.");
        }

        private static void Deposito(){
            ListarContas();

            Console.Write("Digite o número da conta: ");
            int nuconta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor do deposito: ");
            double valor = double.Parse(Console.ReadLine());
            listContas[nuconta].Depositar(valor);
        }

        private static void InserirConta(){
            Console.WriteLine("Entre com os dados da nova conta.");

            Console.Write("Tipo da Conta: 1 (Fisica) ou 2 (Juridica): ");
            int tipoConta = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Saldo Inicial: ");
            double saldo = double.Parse(Console.ReadLine());
            Console.Write("Limite da Conta: ");
            double limite = double.Parse(Console.ReadLine());

            Conta conta = new Conta(nome, limite, saldo, (TipoConta)tipoConta);
            listContas.Add(conta);
        }
    }
}
