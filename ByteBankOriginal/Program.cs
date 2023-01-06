using ByteBankOriginal;
Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.Black;
Sistema sistema = new();
Cliente cliente = new Cliente();
while (true)
{
    Console.Clear();
    int op = sistema.MostrarMenu();

    if (op == 1)
    {
        cliente.Inserir();

    }

    else if (op == 2)
    {
        cliente.Deletar();
    }

    else if (op == 3)
    {
        cliente.Listar();
    }

    else if (op == 4)
    {
        cliente.ListarUm();
    }

    else if (op == 5)
    {
        cliente.MostrarTot();

    }

    else if (op == 6)
    {
        int opcao = sistema.MostrarSubMenu();

        if (opcao == 1)
        {
            cliente.Depositar();
        }
        else if (opcao == 2)
        {
            cliente.Sacar();
        }
        else if (opcao == 3)
        {
            cliente.Transferir();
        }
        else
            Console.WriteLine("Opção inválida");
    }

    else if (op == 0)
    {
        Console.WriteLine("Obrigado por utilizar nosso sistema !");
        Console.WriteLine("Desligando...");
        break;
    }

    else
        Console.WriteLine("Opção inválida");
   
    Console.ReadLine();



}
