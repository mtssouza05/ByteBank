using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankOriginal
{
    public class Cliente
    {
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Senha { get; set; }
        public double Saldo { get; set; }

        List<Cliente> clientes = new List<Cliente>();
        double tot = 0;
        public void Inserir()
        {
            Cliente cliente = new();
            Sistema sistema = new();
            Console.WriteLine("Digite o nome do usuário: ");
            cliente.Nome = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Digite a senha desse usuário: ");
                string senha = sistema.GetSenha();
                Console.WriteLine("Confirme a senha: ");
                string senha2 = sistema.GetSenha();

                if(senha == senha2)
                {
                    cliente.Senha = senha;
                    break;
                }
                else
                    Console.WriteLine("Senhas não conferem, tente novamente !");
            }
 
            Console.WriteLine("Digite o CPF desse usuário: ");
            cliente.Cpf = Console.ReadLine();
            clientes.Add(cliente);
            Console.WriteLine("Cliente inserido no sistema .");
        }

        public void Deletar()
        {
            Console.WriteLine("Digite o Cpf do usuário a deletar: ");
            string cpf = Console.ReadLine();
            var clienteDelete = clientes.Find(x => x.Cpf==cpf);
            clientes.Remove(clienteDelete);
        }

        public void Listar()
        {
            if (clientes.Count > 0)
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"Nome: {cliente.Nome} | Cpf: {cliente.Cpf} | Saldo: {cliente.Saldo} ");

                }
                
            }
            else
                Console.WriteLine("Não encontrado cadastros .");
        }

        public void ListarUm()
        {
            Console.WriteLine("Digite Cpf do cliente a ser exibido: ");
            string cpf = Console.ReadLine();
            var clienteListar = clientes.Find(x => x.Cpf == cpf);
            if(clienteListar != null)
            {
                Console.WriteLine($"Nome: {clienteListar.Nome} | Cpf: {clienteListar.Cpf} | Saldo: {clienteListar.Saldo}");
            }
            else
                Console.WriteLine("Usuário não encontrado");
            
        }

        public void Depositar()
        {
            Sistema sistema = new();
            Console.WriteLine("Digite o Cpf: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("Digite a senha: ");
            string senha = sistema.GetSenha();
            var cliente = clientes.Find(x => x.Cpf == cpf);
            Console.WriteLine("=*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*=");
            Console.WriteLine();

            if (cliente != null)
            {
                if (cliente.Senha == senha)
                {
                    Console.WriteLine("Qual valor gostaria de depositar: ");
                    double valor = double.Parse(Console.ReadLine());
                    cliente.Saldo += valor;
                    tot += valor;
                    Console.WriteLine("Deposito realizado com sucesso !");
                }
                else
                    Console.WriteLine("Senha incorreta, tente novamente !");
            }
            else
                Console.WriteLine("Cpf não encontrado, tente novamente !");

        }

        public void Sacar()
        {
            Sistema sistema = new();
            Console.WriteLine("Digite o Cpf: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("Digite a senha: ");
            string senha = sistema.GetSenha();
            var cliente = clientes.Find(x => x.Cpf == cpf);
            Console.WriteLine("=*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*=");
            Console.WriteLine();

            if (cliente != null)
            {
                if (cliente.Senha == senha)
                {
                    Console.WriteLine("Qual valor gostaria de sacar: ");
                    double valor = double.Parse(Console.ReadLine());
                    if (cliente.Saldo >= valor)
                    {
                        cliente.Saldo -= valor;
                        Console.WriteLine("Saque realizado com sucesso!");
                        tot -= valor;
                    }
                    else
                        Console.WriteLine("Saldo insuficiente :(");
                    
                }
                else
                    Console.WriteLine("Senha incorreta, tente novamente !");
            }
            else
                Console.WriteLine("Cpf não encontrado, tente novamente !");

        }

        public void Transferir()
        {
            Sistema sistema = new();
            Console.WriteLine("Digite o Cpf: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("Digite a senha: ");
            string senha = sistema.GetSenha();
            var cliente = clientes.Find(x => x.Cpf == cpf);

            if (cliente != null)
            {
                if (cliente.Senha == senha)
                {
                    Console.WriteLine("Qual valor gostaria de transferir: ");
                    double valor = double.Parse(Console.ReadLine());
                    if (cliente.Saldo >= valor)
                    {
                        Console.WriteLine("Digite o Cpf do usuário para qual deseja transferir");
                        string cpfTransferir = Console.ReadLine();
                        var cliente2 = clientes.Find(x => x.Cpf == cpfTransferir);
                        Console.WriteLine("=*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*=");
                        Console.WriteLine();
                        if (cliente2!= null)
                        {
                            cliente2.Saldo += valor;
                            cliente.Saldo -=valor;
                            Console.WriteLine("Transferência realizada com sucesso !");
                        }
                        else
                            Console.WriteLine("Conta inexsistente !");
                    }
                    else
                        Console.WriteLine("Saldo insuficiente :(");

                }
                else
                    Console.WriteLine("Senha incorreta, tente novamente !");
            }
            else
                Console.WriteLine("Cpf não encontrado, tente novamente !");

        }

        public void MostrarTot()
        {
            if(tot > 0)
            {
                Console.WriteLine($"Total no banco: {tot:F2}");

            }
            else
                Console.WriteLine("Nada armazenado ainda");
        }
    }
}
