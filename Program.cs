internal class Program
{
    //   ""  ""
    private static void Main(string[] args)
    {
        Menu();
    }


    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("O que deseja realizar?");
        Console.WriteLine("======================");
        Console.WriteLine("1 --- Abrir arquivo existente");
        Console.WriteLine("2 --- Criar novo arquivo");
        Console.WriteLine("0 --- Fechar programa");
        short opcao = short.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 0:
                System.Environment.Exit(0);
                break;

            case 1:
                OpenFile();
                break;

            case 2:
                CreateFile();
                break;

            default:
                Menu();
                break;
        }
    }

    /* o que ocoore na open file

        */
    static void OpenFile()
    {
        Console.Clear();
        Console.WriteLine("qual o caminho para o arquivo?");
        string path = Console.ReadLine();

        using (var arquivo = new StreamReader(path))
        {
            string texto = arquivo.ReadToEnd();
            Console.WriteLine(texto);
        }

        Console.ReadKey();
        Menu();
    }


    /* o que ocoore na função create file

        */

    static void CreateFile()
    {
        Console.Clear();
        Console.WriteLine("Escreva o texto abaixo");
        Console.WriteLine("(ESC para sair)");
        Console.WriteLine("------------------------");
        string texto = "";

        do
        {
            texto += Console.ReadLine();
            texto += Environment.NewLine;
        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);
        Console.WriteLine("------------------------");
        Salvar(texto);
    }


    /* o que ocoore na função salvar

    */
    static void Salvar(string texto)
    {
        Console.Clear();
        Console.WriteLine("onde deseja alvar?");
        var path = Console.ReadLine();

        using (var arquivo = new StreamWriter(path))
        {
            arquivo.Write(texto);
        }
        Console.WriteLine($"texto salvo com exito em {path}");
        Console.ReadKey();
        Menu();
    }
}