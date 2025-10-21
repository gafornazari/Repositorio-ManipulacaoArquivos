string filePath = "exemplo.txt";
string directoryPath = "C:\\Arquivos\\";


try
{
    if (!Directory.Exists(directoryPath))
    {
        Directory.CreateDirectory(directoryPath);
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.StackTrace);
    Console.WriteLine(ex.Message);
}

var fullPath = Path.Combine(directoryPath, filePath);

//StreamReader reader = new StreamReader(filePath);

//using (reader)
//{
//    string content = reader.ReadToEnd();
//    Console.WriteLine(content);
//    reader.Close();
//}

StreamWriter writer = new StreamWriter(fullPath, append : true);

writer.WriteLine("Escrevendo no arquivo");
writer.WriteLine("Escrevendo no arquivo - parte 2");

writer.Close();

StreamReader sr = new StreamReader(fullPath);

using (sr)
{
    string content = sr.ReadToEnd();
    Console.WriteLine(content);
    sr.Close();
}