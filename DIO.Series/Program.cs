using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string option = GetOption();
            while(option.ToUpper() != "X")
            {
                switch (option)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ShowSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                option = GetOption();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListSeries()
        {
            Console.WriteLine("Listar séries");
            var listSeries = repository.GetList();
            if (listSeries.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in listSeries)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.ReturnId(), serie.GetTitle());
            }
        }

        private static void InsertSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int inputGenre = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o título da série: ");
            string inputTitle = Console.ReadLine();
            Console.WriteLine("Digite o ano de início da série: ");
            int inputYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição da série: ");
            string inputDescription = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.NextId(), 
                                       genero: (Genre)inputGenre,
                                       titulo: inputTitle,
                                       descricao: inputDescription,
                                       ano: inputYear);
            repository.Add(newSerie);
        }

        private static void UpdateSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indexSerie = int.Parse(Console.ReadLine());

            foreach (int index in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", index, Enum.GetName(typeof(Genre), index));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int inputGenre = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o título da série: ");
            string inputTitle = Console.ReadLine();
            Console.WriteLine("Digite o ano de início da série: ");
            int inputYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição da série: ");
            string inputDescription = Console.ReadLine();

            Serie updateSerie = new Serie(id: indexSerie, 
                                          genero: (Genre)inputGenre, 
                                          titulo: inputTitle, 
                                          descricao: inputDescription, 
                                          ano: inputYear);
            repository.Update(indexSerie, updateSerie);
        }

        private static void DeleteSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indexSerie = int.Parse(Console.ReadLine());
            repository.Delete(indexSerie);
        }

        private static void ShowSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indexSerie = int.Parse(Console.ReadLine());
            var serie = repository.ReturnById(indexSerie);
            Console.WriteLine(serie);
        }

        private static string GetOption()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string option = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return option;
        }
    }
}
