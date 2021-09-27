using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelecionandoArquivosPorData
{
    class Program
    {
        static void Main(string[] args)
        {

            string diretorioAtualStr, diretorioDestinoStr, anoStr;


            Console.WriteLine("Digite o ano dos arquivos q deseja selecionar: ");
            anoStr = Console.ReadLine();

            Console.WriteLine("Digite o caminho completo onde encontram-se os aqruivos: ");
            diretorioAtualStr = Console.ReadLine();

            Console.WriteLine("Digite o caminho completo onde serão colocados os arquivos: ");
            diretorioDestinoStr = Console.ReadLine();

            Console.Clear();

            int ano = Convert.ToInt32(anoStr);



            var diretorioAtual = new DirectoryInfo(@diretorioAtualStr);

            var arquivos = diretorioAtual.GetFiles()
                        .Where(arquivo => arquivo.LastWriteTime.Date.Year == ano);

            var diretorioDestino = new DirectoryInfo(@diretorioDestinoStr);

            Console.WriteLine("Arquivos saindo do caminho "+ diretorioAtual + " sendo colocados no caminho " + diretorioDestino);

            foreach (var arquivo in arquivos)
            {

                arquivo.CopyTo(diretorioDestino + @"\" + arquivo.Name, true);
            }

            Console.ReadLine();
            
        }
    }
}
