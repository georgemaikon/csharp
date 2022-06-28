using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != "X")
            {   
                switch (opcaoUsuario)
                {                   
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        public static void ListarSeries()
        {
            System.Console.WriteLine("Lista de Séries:");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma Série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                System.Console.WriteLine($"#ID {serie.retornarId()}: - {serie.retornarTitulo()}");
            }
        }

        public static void InserirSerie()
        {
            System.Console.WriteLine("Inserir nova série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            System.Console.Write("Digite o código do gênero dentre as opções listadas: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o título: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a descrição: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(repositorio.ProximoId(), (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);
                                    
            repositorio.Inserir(novaSerie);
        }

        public static void AtualizarSerie()
        {
            System.Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            System.Console.Write("Digite o código do gênero dentre as opções listadas: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o título: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a descrição: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(idSerie, (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);

            repositorio.Atualizar(idSerie, atualizaSerie);
        }

        public static void ExcluirSerie()
        {
            System.Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(idSerie);
        }

        public static void VisualizarSerie()
        {
            System.Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());
            
            var serie = repositorio.RetornaPorId(idSerie);
            System.Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine("SériesFlix - Plataforma de séries.");
            System.Console.WriteLine("Opções:");
            System.Console.WriteLine("1 - Listar séries");
            System.Console.WriteLine("2 - Inserir nova série");
            System.Console.WriteLine("3 - Atualizar série");
            System.Console.WriteLine("4 - Excluir série");
            System.Console.WriteLine("5 - Visualizar série");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();
            System.Console.Write("Digite a opção desejada: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
