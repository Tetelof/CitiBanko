using System;
using System.IO;

namespace ProjetoAED1
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta user = new Conta();
            Notas notas = new Notas();
            notas.Abastecer();
            notas.Valor_caixa = notas.defineValorCaixa();
            Console.WriteLine("debug notas.Valor_caixa: "+notas.Valor_caixa);
            
            string conta = "null";
            while (conta != "sair")
            {
                Console.WriteLine("Digite numero da conta:");
                conta = Console.ReadLine();
                if (conta == "sair")
                {
                    continue;
                }
                else if (validarconta(conta))
                {
                    user = DefinirValores(conta);
                    Console.WriteLine("Digite sua senha:");
                    int tentativas = 0;
                    while (tentativas < 3)
                    {
                        if(user.verificarSenha(int.Parse(Console.ReadLine())))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Senha incorreta");
                            tentativas ++;
                        }
                    }
                    // Console.WriteLine(tentativas);
                    if (tentativas >= 3)
                    {
                        Console.WriteLine("Acesso negado");
                    }
                    else
                    {
                        Console.WriteLine("Olá "+user.Nome);

                        string escolha = "null";
                        while (escolha != "5")
                        {
                            Console.WriteLine("Digite sua opção:");
                            Console.WriteLine("1-Extrato  |   2-Depósito    |   3-Saque |   4-Alterar Senha |   5-Sair");
                            escolha = Console.ReadLine();

                            if (escolha == "1")
                            {
                                user.Extrato();
                            }
                            else if (escolha == "2")
                            {
                                Console.WriteLine("Digite valor do depósito:");
                                user.Deposito(double.Parse(Console.ReadLine()));
                            }
                            else if (escolha == "3")
                            {
                                Console.WriteLine("Saldo atual: R$"+user.Saldo);
                                Console.WriteLine("Digite valor saque:");
                                int[] montante_sacado = new int[6];
                                double montante = double.Parse(Console.ReadLine());
                                if(montante < user.Saldo)
                                {
                                    montante = notas.validarValor(montante);
                                    user.Saque(montante);
                                    montante_sacado = notas.distribuirNotas(Convert.ToInt32(montante));
                                    Console.WriteLine(montante_sacado[0]+" notas de cem");
                                    Console.WriteLine(montante_sacado[1]+" notas de cinquenta");
                                    Console.WriteLine(montante_sacado[2]+" notas de vinte");
                                    Console.WriteLine(montante_sacado[3]+" notas de dez");
                                    Console.WriteLine(montante_sacado[4]+" notas de cinco");
                                    Console.WriteLine(montante_sacado[5]+" notas de dois");
                                }
                                else
                                {
                                    Console.WriteLine("Saldo Insuficiente!");
                                }
                            }
                            else if (escolha == "4")
                            {
                                Console.WriteLine("Digite nova senha:");
                                user.Senha = int.Parse(Console.ReadLine());
                            }
                        }
                        Console.WriteLine("debug user.Numero: "+user.Numero);
                        atualizarTxt(Convert.ToString(user.Numero), user);
                    }
                }
            }
        }
        static bool validarconta(string numero_conta)
        {
            string[] contas = new string[] {"0001","0002","0003","0004"};
            foreach (string i in contas)
            {
                if (numero_conta == i)
                {
                    return true;
                }
            }
            return false;
        }
        static Conta DefinirValores(string numero_conta)
        {
            FileStream txt_contas = new FileStream("Contas.txt",FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(txt_contas);
            Conta user = new Conta();
            
            while(!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                if(str == numero_conta)
                {
                    //Console.WriteLine("cheguei");
                    user.Numero = str;
                    user.Nome = sr.ReadLine();
                    user.Saldo = double.Parse(sr.ReadLine());
                    user.Senha = int.Parse(sr.ReadLine());
                }
            }
            txt_contas.Close();
            sr.Close();
            return user;
        }
        static void atualizarTxt(string conta, Conta user)
        {
            FileStream txt_contas = new FileStream("Contas.txt",FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(txt_contas);
            int contador = 0;
            string str = sr.ReadLine();
            while (str != conta)
            {
                str = sr.ReadLine();
                contador ++;
            }
            sr.Close();
            txt_contas.Close();
            string[] arrLine = File.ReadAllLines("Contas.txt");
            arrLine[contador + 1] = user.Nome;
            arrLine[contador + 2] = Convert.ToString(user.Saldo);
            arrLine[contador + 3] = Convert.ToString(user.Senha);
            File.WriteAllLines("Contas.txt",arrLine);


        }
    }
}