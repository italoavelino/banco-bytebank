using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dataFimPagamento = new DateTime(2022, 7, 17);
            DateTime dataCorrente = DateTime.Now;
            
            TimeSpan diferenca = dataCorrente - dataFimPagamento;

            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);

            Console.WriteLine(mensagem);

            Console.WriteLine("Tecle ENTER para encerrar o programa");
            Console.ReadLine();
        }
    }
}

