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

<<<<<<< HEAD
            string teste = "Teste de conflitos no git";
=======
            string teste = "Testando Conflitos no Git";
>>>>>>> cdfb7fab7f5f104f0083b190f3bd22263f1a1481

            TimeSpan diferenca = dataCorrente - dataFimPagamento;

            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);

            Console.WriteLine(mensagem);

            Console.WriteLine("Tecle ENTER para encerrar o programa");
            Console.ReadLine();
        }
    }
}
 
 