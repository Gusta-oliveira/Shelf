using System.ComponentModel.Design;
using Shelf;

internal class Program
{
    static int Menu()
    {
        Console.WriteLine("-------Estante de Livros-------");
        Console.Write("1 - Adicionar Livro;\n2 - Emprestar livro;\n3 - Mover Livro para Lendo;\n4 - Consultar Livros;\n5 - Fechar Estante;\n");
        Console.Write("-------------------------------\nInforme a operação: ");
        var op = int.Parse(Console.ReadLine());
        Console.Clear();
        return op;
    }
    private static void Main(string[] args)
    {
        string shelffile = "shelf.txt";
        string lend = "lends.txt";
        List<Book> mybook = new List<Book>();
        List<Book> lendbook = new List<Book>();
        mybook = LoadFile(mybook, shelffile);
        lendbook = LoadFile(lendbook, lend);

        do
        {
            switch (Menu())
            {
                case 1:
                    Console.WriteLine("Adicionando Livro a Estante\n ");
                    mybook = CreatBook(mybook);
                    WriteFile(mybook, shelffile);
                    Thread.Sleep(1800);
                    Console.Clear();
                    break;
                case 2:
                    lendbook = Lend(lendbook, mybook);
                    WriteFile(lendbook, lend);
                    break;
                case 3:
                    break;
                case 4:
                    Console.WriteLine("Consulta de Livros.");
                    foreach (Book book in mybook)
                    {
                        Console.WriteLine(book.ToString());
                    }
                    Console.WriteLine("\nAperte qualquer tecla para voltar ao menu.");

                    Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("Fechando Estante!");
                    Thread.Sleep(2000);
                    System.Environment.Exit(0);
                    break;
            }
        } while (true);
    }

    private static List<Book> CreatBook(List<Book> lis)
    {
        Console.Write("Informe o Titúlo: ");
        string title = Console.ReadLine();
        Console.Write("Informe o Autor: ");
        string author = Console.ReadLine();
        Console.Write("Informe o ISBN: ");
        long isbn = long.Parse(Console.ReadLine());
        Console.Write("Informe a Edição: ");
        int edition = int.Parse(Console.ReadLine());
        lis.Add(new(title, author, isbn, edition));
        return lis;
    }
    private static List<Book> WriteFile(List<Book> l, string f)
    {
        StreamWriter sw = new(f);
        try
        {
            
            foreach (var i in l)
            {
                sw.WriteLine(i.ToFile());
            }
            Console.WriteLine("Processando...");
            Thread.Sleep(1000);
            
        }
        catch (Exception e)
        {

        }
        finally
        {
            sw.Close();
            Console.WriteLine("Livro registrado com sucesso.");
        }
        return l;
    }
    private static List<Book> LoadFile(List<Book> lb, string f)
    {
        StreamReader sr = new(f);
        try
        {
            
            if (File.Exists(f))
            {
                
                while (!sr.EndOfStream)
                {
                    string[] aux = sr.ReadLine().Split(",");
                    string title = aux[0];
                    string autor = aux[1];
                    long isbn = long.Parse(aux[2]);
                    int edition = int.Parse(aux[3]);
                    lb.Add(new(title, autor, isbn, edition));
                }
                
            }
            else
            {
                Console.WriteLine("Criando.");
                Thread.Sleep(1200);
            }
        }
        catch
        {
        }
        finally
        {
            sr.Close();
        }
        return lb;
    }
    private static List<Book> Lend(List<Book> lb, List<Book> mb)
    {
        try
        {
            if (lb.Count == 0)
            {
                Console.WriteLine("Nenhum item na lista...");
                Thread.Sleep(2000);
            }
            else
            {
                foreach (var item in mb)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine("Deseja aprovar esta cotação? (S/N)");
                    char c = char.Parse(Console.ReadLine().ToLower());
                    if (c == 's')
                    {
                        lb.Add(item);

                    }
                }
            }
        }
        catch (Exception e)
        {
        }
        finally
        {
        }
        return lb;
    }
}