using Shelf;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Book> listbook = new List<Book>();
        listbook = LoadFile();
        do
        {
            switch (Menu())
            {
                case 1:
                    Console.WriteLine("Adicionando Livro a Estante\n ");
                    WriteFile(CreatBook());
                    Thread.Sleep(1800);
                    Console.Clear();
                    break;
                case 2:
                    Lend();

                    Console.ReadLine();
                    break;
                case 3:
                    break;
                case 4:
                    Console.WriteLine("Consulta de Livros.");
                    foreach (Book book in listbook)
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

        int Menu()
        {
            Console.WriteLine("-------Estante de Livros-------");
            Console.Write("1 - Adicionar Livro;\n2 - Emprestar livro;\n3 - Mover Livro para Lendo;\n4 - Consultar Livros;\n5 - Fechar Estante;\n");
            Console.Write("-------------------------------\nInforme a operação: ");
            var op = int.Parse(Console.ReadLine());
            Console.Clear();
            return op;
        }
        Book CreatBook()
        {
            Console.Write("Informe o Titúlo: ");
            string title = Console.ReadLine();
            Console.Write("Informe o Autor: ");
            string author = Console.ReadLine();
            Console.Write("Informe o ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Informe a Edição: ");
            string edition = Console.ReadLine();
            return new(title, author, isbn, edition);
        }
        void WriteFile(Book book)
        {
            try
            {
                listbook.Add(book);
                if (File.Exists("shelf.txt"))
                {
                    StreamWriter sw = new("shelf.txt");
                    foreach (var i in listbook)
                    {
                        sw.WriteLine(i.ToString());
                    }
                    Console.WriteLine("Processando...");
                    Thread.Sleep(1000);
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new("shelf.txt");
                    sw.Write(book.ToString());
                    Console.WriteLine("Processando...");
                    Thread.Sleep(1000);
                    sw.Close();
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                Console.WriteLine("Livro registrado com sucesso.");

            }
        }
        List<Book> LoadFile()
        {

            Book book = new Book();
            string txt = "";
            try
            {
                

                if (File.Exists("shelf.txt"))
                {
                    StreamReader sr = new("shelf.txt");
                    string[] aux;
                    txt = sr.ReadLine();
                    do
                    {
                        
                        aux = txt.Split(",");
                        book.Title = aux[0];
                        book.Author = aux[1];
                        book.Isbn = aux[2];
                        book.Edition = aux[3];
                        listbook.Add(book);
                    } while(sr.Read() != null);
                    sr.Close();
                }
                else
                {
                    Console.WriteLine("Estante vazia!");
                    Thread.Sleep(1200);
                    Menu();
                }
            }
            catch
            {

            }
            finally
            {

            }
            return listbook;
        }
        void Lend()
        {
            Console.WriteLine("Livros na estante.");
            foreach (Book book in listbook)
            {
                Console.WriteLine(book.ToString());
            }
        }

        //string ReadFile(string f)
        //{
        //    StreamReader sr = new("shelf.txt");
        //    string t = "";
        //    try
        //    {
        //        t = sr.ReadToEnd();
        //    }
        //    catch (Exception e)
        //    {
        //    }
        //    finally
        //    {
        //        sr.Close();
        //    }
        //    return t;
        //}
        //void Lend(List<Book> lb, string t)
        //{
        //    foreach (var item in lb)
        //    {
        //        if (t == item.Title)
        //        {
        //            lb.Remove();
        //        }
        //    }
        //}
    }
}