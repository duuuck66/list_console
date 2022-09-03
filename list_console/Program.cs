using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static string _rootPath = AppDomain.CurrentDomain.BaseDirectory;
    
    public static void Main(string[] args)
    {
        WriteDirectory(_rootPath);
        Thread.Sleep(1000);
        ReadDirectories(_rootPath);
        Console.Read();
    }

    public static void WriteDirectory(string path)
    {
        DirectoryInfo sd = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        StreamWriter sw2 = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sd.Name + ".txt"), true);

        Console.WriteLine("Начальная папка: {0}", sd.Name);
        sw2.WriteLine("Начальная папка: {0}", sd.Name);
        sw2.Close();
    }

    public static void ReadDirectories(string path,  string directoryName = "")
    {
        DirectoryInfo sd = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sd.Name + ".txt"), true);

        if (!string.IsNullOrEmpty(directoryName))
        {
            Console.WriteLine("{0}", directoryName);
            path = @$"{path}\{directoryName}";
            sw.WriteLine("\n------------------------------------\n" +
                "               Папка: {0} \n------------------------------------\n", directoryName);
        }

        DirectoryInfo dir_place = new DirectoryInfo(path);

        FileInfo[] Files = dir_place.GetFiles();
        foreach (FileInfo i in Files)
        {
            Console.WriteLine("{1}", directoryName, i.Name);
            sw.WriteLine("{1}", directoryName, i.Name);
        }
        sw.Close();

        DirectoryInfo[] directories = dir_place.GetDirectories();
        foreach (var directory in directories)
        {
            ReadDirectories(path, directory.Name);
        };
    }
}
