using Biblioteca;

string filePath = "biblioteca.txt";
string directoryPath = "C:\\Arquivos\\";

List<Livro> livros = new List<Livro>();

try
{
    if (!Directory.Exists(directoryPath))
    {
        Directory.CreateDirectory(directoryPath);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.StackTrace);
    Console.WriteLine(ex.Message);
}

try
{
    if(!File.Exists(Path.Combine(directoryPath, filePath)))
    {
        File.Create(Path.Combine(directoryPath, filePath));
    }
}catch (Exception ex)
{
    Console.WriteLine(ex.StackTrace);
    Console.WriteLine(ex.Message);
}

var fullPath = Path.Combine(directoryPath, filePath);

void SalvarListaLivros(List<Livro> livros, string path)
{
    StreamWriter writer = new StreamWriter(path);

    foreach (var livro in livros)
    {
        writer.WriteLine($"{livro.Titulo} - {livro.Autor} - {livro.Categoria}");
    }
    writer.Close();
}

StreamReader sr = new StreamReader(fullPath);
using (sr)
{
    string informacao;
    Livro livro = new Livro();
    while ((informacao = sr.ReadLine()) != null)
    {
        var dados = informacao.Split(" - ");
        if (dados.Length == 3)
        {
            livro = new Livro(dados[0], dados[1], dados[2]);
            livros.Add(livro);
        }
    }
}

int op = 1;

void MostrarLivros(List<Livro> livros)
{
    Console.WriteLine("---- LISTA DE LIVROS ----");
    if (livros.Count == 0)
    {
        Console.WriteLine("Nenhum livro cadastrado.");
    }
    else
    {
        foreach (var livro in livros)
        {
            Console.WriteLine(livro.ToString());
        }
    }
}


bool EditarLivro(string titulo)
{
    var livro = livros.Find(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
    if (livro != null)
    {
        Console.Write("Digite o novo título do livro: ");
        string novoTitulo = Console.ReadLine() ?? "";
        Console.Write("Digite o novo autor do livro: ");
        string novoAutor = Console.ReadLine() ?? "";
        Console.Write("Digite a nova categoria do livro: ");
        string novaCategoria = Console.ReadLine() ?? "";
        livro.Titulo = novoTitulo;
        livro.Autor = novoAutor;
        livro.Categoria = novaCategoria;
        return true;
    }
    else
    {
        return false;
    }
}

bool ProcurarLivro(string titulo)
{
    var livro = livros.Find(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
    return livro != null;
}


do
{
    Console.WriteLine("---- MENU ----");
    Console.WriteLine("1 - Adicionar livro");
    Console.WriteLine("2 - Remover livro");
    Console.WriteLine("3 - Listar livros");
    Console.WriteLine("4 - Editar livro");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");
    op = int.Parse(Console.ReadLine() ?? "0");

    switch (op)
    {
        case 1:
            Console.Write("Digite o título do livro: ");
            string titulo = Console.ReadLine() ?? "";
            Console.Write("Digite o autor do livro: ");
            string autor = Console.ReadLine() ?? "";
            Console.Write("Digite a categoria do livro: ");
            string categoria = Console.ReadLine() ?? "";
            livros.Add(new Livro(titulo, autor, categoria));
            break;

        case 2:
            MostrarLivros(livros);
            Console.Write("Digite o título do livro a ser removido: ");
            string tituloRemover = Console.ReadLine() ?? "";
            bool existe = ProcurarLivro(tituloRemover);
            if (!existe)
                Console.WriteLine("Livro não encontrado!");
            else
            {
                livros.RemoveAll(l => l.Titulo.Equals(tituloRemover, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine("Livro removido!");
            }
            break;

        case 3:
            MostrarLivros(livros);
            break;

        case 4:
            MostrarLivros(livros);
            Console.Write("Digite o título do livro a ser editado: ");
            string tituloEditar = Console.ReadLine() ?? "";
            if (EditarLivro(tituloEditar))
                Console.WriteLine("Livro editado!");
            else
                Console.WriteLine("Livro não encontrado!");
            break;
        case 0:
            SalvarListaLivros(livros, fullPath);
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
} while (op != 0);


