using System;
using System.Collections.Generic;

namespace OrganizadorSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            SerieRepositorio minhasSeries = new SerieRepositorio();
            string opcao = ObterOpcaoUsusario();

            while (opcao != "X")
            {
                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("1 - Listar séries");
                        ListarSeries(minhasSeries);
                        break;
                    case "2":
                        InserirSerie(minhasSeries);
                        break;
                    case "3":
                        AtualizarSerie(minhasSeries);
                        break;
                    case "4":
                        ExcluirSerie(minhasSeries);
                        break;
                    case "5":
                        VisualizarSerie(minhasSeries);
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
                opcao = ObterOpcaoUsusario();
            }
            Console.WriteLine("Até a próxima.");
        }

        private static void VisualizarSerie(SerieRepositorio repo)
        {
            Console.WriteLine("5 - Visualizar série");
            var series = repo.Lista();
            if (series.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada!");
                return;
            }
            List<int> ids = new List<int>();
            foreach (var s in series)
            {
                ids.Add(s.RetornaId());
            }
            int id = -1;
            ListarSeries(repo);
            Console.WriteLine();
            Console.WriteLine("Informe o ID de uma série para visualizar ou 0 para cancelar.");
            while (id == -1)
            {
                try
                {
                    id = int.Parse(Console.ReadLine());
                    if (id != 0 && !ids.Contains(id))
                    {
                        id = -1;
                        Console.WriteLine();
                        Console.WriteLine("Informe um ID válido ou 0 para cancelar.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Informe um ID válido ou 0 para cancelar.");
                    id = -1;
                }
            }
            if (id == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Operação cancelada.");
            }
            else
            {
                Serie v = repo.RetornaPorId(id);
                Console.WriteLine();
                Console.WriteLine(v.ToString());
            }
        }

        private static void ExcluirSerie(SerieRepositorio repo)
        {
            Console.WriteLine("4 - Excluir série");
            var series = repo.Lista();
            if (series.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada!");
                return;
            }
            List<int> ids = new List<int>();
            foreach (var s in series)
            {
                ids.Add(s.RetornaId());
            }
            int id = -1;
            ListarSeries(repo);
            Console.WriteLine();
            Console.WriteLine("Informe o ID de uma série para excluir ou 0 para cancelar.");
            while (id == -1)
            {
                try
                {
                    id = int.Parse(Console.ReadLine());
                    if (id != 0 && !ids.Contains(id))
                    {
                        id = -1;
                        Console.WriteLine();
                        Console.WriteLine("Informe um ID válido ou 0 para cancelar.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Informe um ID válido ou 0 para cancelar.");
                    id = -1;
                }
            }
            if (id == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Operação cancelada.");
            }
            else
            {
                repo.Exclui(id);
                Console.WriteLine();
                Console.WriteLine("Série excluída!");
            }
        }

        private static void AtualizarSerie(SerieRepositorio repo)
        {
            Console.WriteLine("3 - Atualizar série");
            var series = repo.Lista();
            if (series.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada!");
                return;
            }
            List<int> ids = new List<int>();
            foreach (var s in series)
            {
                ids.Add(s.RetornaId());
            }
            int id = -1;
            ListarSeries(repo);
            Console.WriteLine();
            Console.WriteLine("Informe o ID de uma série para atualizar ou 0 para cancelar.");
            while (id == -1)
            {
                try
                {
                    id = int.Parse(Console.ReadLine());
                    if (id != 0 && !ids.Contains(id))
                    {
                        id = -1;
                        Console.WriteLine();
                        Console.WriteLine("Informe um ID válido ou 0 para cancelar.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Informe um ID válido ou 0 para cancelar.");
                    id = -1;
                }
            }
            if (id == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Operação cancelada.");
            }
            else
            {
                Console.WriteLine();
                string op = "";
                Serie s = repo.RetornaPorId(id);
                Genero genero = (Genero)1;
                string titulo = "";
                string descricao = "";
                int ano = 0;
                Console.WriteLine(s.ToString());
                Console.WriteLine();
                Console.WriteLine("Deseja atualizar o gênero dessa série?(Y/N)");
                while (op == "")
                {
                    op = Console.ReadLine().ToUpper();
                    if (op == "Y")
                    {
                        int gen = 0;
                        foreach (int i in Enum.GetValues(typeof(Genero)))
                        {
                            Console.WriteLine($"COD.: {i} - {Enum.GetName(typeof(Genero), i)}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Escolha um gênero.");
                        while (gen < 1 || gen > Enum.GetValues(typeof(Genero)).Length)
                        {
                            try
                            {
                                gen = int.Parse(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                gen = 0;
                            }
                            if (gen < 1 || gen > Enum.GetValues(typeof(Genero)).Length)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Informe apenas o COD. de um gênero válido.");
                            }
                        }
                        genero = (Genero)gen;
                    }
                    else if (op == "N")
                    {
                        genero = s.GetGenero();
                    }
                    else
                    {
                        op = "";
                        Console.WriteLine();
                        Console.WriteLine("Informe uma opção válida.");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Deseja atualizar o título dessa série?(Y/N)");
                op = "";
                while (op == "")
                {
                    op = Console.ReadLine().ToUpper();
                    if (op == "Y")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Informe o novo título.");
                        titulo = Console.ReadLine();
                    }
                    else if (op == "N")
                    {
                        titulo = s.RetornaTitulo();
                    }
                    else
                    {
                        op = "";
                        Console.WriteLine();
                        Console.WriteLine("Informe uma opção válida.");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Deseja atualizar a descrição dessa série?(Y/N)");
                op = "";
                while (op == "")
                {
                    op = Console.ReadLine().ToUpper();
                    if (op == "Y")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Informe a nova descrição.");
                        descricao = Console.ReadLine();
                    }
                    else if (op == "N")
                    {
                        descricao = s.getDescricao();
                    }
                    else
                    {
                        op = "";
                        Console.WriteLine();
                        Console.WriteLine("Informe uma opção válida.");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Deseja atualizar o ano de lançamento dessa série?(Y/N)");
                op = "";
                while (op == "")
                {
                    op = Console.ReadLine().ToUpper();
                    if (op == "Y")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Informe o novo ano de lançamento.");
                        while (ano < 1)
                        {
                            try
                            {
                                ano = int.Parse(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                ano = 0;
                            }
                            if (ano < 1)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Informe um ano de lançamento válido.");
                            }
                        }
                    }
                    else if (op == "N")
                    {
                        ano = s.getAno();
                    }
                    else
                    {
                        op = "";
                        Console.WriteLine();
                        Console.WriteLine("Informe uma opção válida.");
                    }
                }
                repo.Atualiza(id, new Serie(id, genero, titulo, descricao, ano));
                Console.WriteLine();
                Console.WriteLine("Série atualizada!");
            }
        }

        private static void InserirSerie(SerieRepositorio repo)
        {
            Console.WriteLine("2 - Inserir nova série");
            int genero = 0;
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"COD.: {i} - {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine();
            Console.WriteLine("Escolha um gênero.");
            while (genero < 1 || genero > Enum.GetValues(typeof(Genero)).Length)
            {
                try
                {
                    genero = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    genero = 0;
                }
                if (genero < 1 || genero > Enum.GetValues(typeof(Genero)).Length)
                {
                    Console.WriteLine();
                    Console.WriteLine("Informe apenas o COD. de um gênero válido.");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Informe o título da série.");
            string titulo = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Informe a descrição da série.");
            string descricao = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Informe o ano de lançamento.");
            int ano = 0;
            while (ano < 1)
            {
                try
                {
                    ano = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    ano = 0;
                }
                if (ano < 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Informe um ano de lançamento válido.");
                }
            }
            Serie serie = new Serie(repo.ProximoId(), (Genero)genero, titulo, descricao, ano);
            repo.Insere(serie);
            Console.WriteLine();
            Console.WriteLine("Série adicionada à lista.");
        }

        private static void ListarSeries(SerieRepositorio repo)
        {
            var series = repo.Lista();
            if (series.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada!");
            }
            else
            {
                foreach (var serie in series)
                {
                    Console.WriteLine($"#ID {serie.RetornaId()} - {serie.RetornaTitulo()}");
                }
            }
        }

        private static string ObterOpcaoUsusario()
        {
            Console.WriteLine();
            Console.WriteLine("Organizador de Séries!");
            Console.WriteLine();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}
