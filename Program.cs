using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != "X")
            {
                switch(opcaoUsuario)
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
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void ListarSeries()
        {
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                if (!serie.excluido)
                {
                    Console.WriteLine($"#ID {serie.getId()}: - {serie.getTitulo()}");
                }
            }
        }

        private static void InserirSerie()
        {
            foreach (var genero in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{(int)genero} - {genero}");
            }
            
            Console.Write("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                repositorio.ProximoId(),
                (Genero)entradaGenero,
                entradaTitulo,
                entradaDescricao,
                entradaAno
                );
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da série que desejas alterar: ");
            int entradaId = int.Parse(Console.ReadLine());

            foreach (var genero in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{(int)genero} - {genero}");
            }
            
            Console.Write("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizadaSerie = new Serie(
                entradaId,
                (Genero)entradaGenero,
                entradaTitulo,
                entradaDescricao,
                entradaAno
                );
            repositorio.Atualiza(entradaId, atualizadaSerie);
        }

        private static void ExcluirSerie() 
        {
            Console.Write("Digite o ID da série que você deseja exluir: ");
            int entradaId = int.Parse(Console.ReadLine());
            repositorio.Exclui(entradaId);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o ID da série que você deseja visualizar: ");
            int entradaId = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(entradaId);
            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("APP Séries a seu dispor");
            Console.WriteLine("Informa a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
