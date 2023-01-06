using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankOriginal
{
    public class Sistema
    {

        public int MostrarMenu()
        {
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Total armazenado no banco");
            Console.WriteLine("6 - Manipular conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.WriteLine();
            Console.WriteLine("=*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*=");
            Console.WriteLine();
            Console.Write("Digite a opção desejada: ");
            int op = int.Parse(Console.ReadLine());
            return op;
        }

        public int MostrarSubMenu()
        {
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Transferir");
            int op = int.Parse(Console.ReadLine());
            return op;
        }
        
        public string GetSenha()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine();
            return pass;
        }

    }
}
