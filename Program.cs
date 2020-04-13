using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace Arquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\PROJETOS\VISUALSTUDIO\udemy\Arquivos\arquivo_teste.txt";
            string patpastas = @"D:\PROJETOS\VISUALSTUDIO\udemy\Arquivos\";
            //instanciando um obj arquivo
            FileInfo file = new FileInfo(path);
            try {
                //escrevendo em arquivo
                StreamWriter sw = file.AppendText();
                for (int i = 0; i < 100; i++)
                {
                    sw.WriteLine(i.ToString()+"uahnuahewuaehu");
                }
                sw.WriteLine(Path.GetTempPath().ToString());
                sw.Close();

            } catch(IOException e) {
                Console.WriteLine("erro"+e.Message);
            }

            //lendo arquivo sem precisar de try catch
            string linha = "";
            using (StreamReader ler = file.OpenText()) {
                
                while ((linha = ler.ReadLine()) != null)
                {
                    Console.WriteLine(linha);
                }
                
            }
            //lendo todas as pastas e subpastas
            IEnumerable<string> patas = Directory.EnumerateDirectories(patpastas, "*.*", SearchOption.AllDirectories);
            foreach (string pas in patas) {
                Console.WriteLine(pas);
            }
            //criando pasta
            Directory.CreateDirectory(patpastas + @"\novapasta");
            Directory.CreateDirectory(patpastas + @"\lixo");
            Thread.Sleep(6000);//6 segundos
            Console.WriteLine("apagando");
            Directory.Delete(patpastas + @"\lixo");

            //pegando nome do arquivo com a clase path
            Console.WriteLine(Path.GetFileName(path));
            //pegando só o nome
            Console.WriteLine(Path.GetFileNameWithoutExtension(path));
            //pegando a extenção do arquivo
            Console.WriteLine(Path.GetExtension(path));
            //pegando a pasta temporaria
            Console.WriteLine(Path.GetTempPath());
        }
    }
}
