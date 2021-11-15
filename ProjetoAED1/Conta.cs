using System;
using System.IO;

namespace ProjetoAED1
{
    class Conta
    {
    // Atributos
        private string numero;
        private int senha;
        private string nome;
        private double saldo;

        // GetSet
        public string Numero
        {
            get{return numero;}
            set{numero = value;}
        }
        public string Nome
        {
            get{return nome;}
            set{nome = value;}
        }
        public double Saldo
        {
            get{return saldo;}
            set{saldo = value;}
        }
        public int Senha
        {
            get{return senha;}
            set{senha = value;}
        }

        // Construtor
        public Conta()
        {
            
        }
        
        // Métodos

        public bool verificarSenha(int senha)
        {
            if (senha == this.senha)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Extrato()
        {
            FileStream historico = new FileStream((Convert.ToString(numero)+".txt"),FileMode.Open,FileAccess.Read);
            StreamReader sr2 = new StreamReader(historico);
            while (!sr2.EndOfStream)
            {
                Console.WriteLine(sr2.ReadLine());
            }
            Console.WriteLine("Saldo atual =" + saldo);
            sr2.Close();
            historico.Close();
        }
        public void Saque(double valor_saque)
        {
            saldo -= valor_saque;
            Movimentacao("-",valor_saque);
        }
        public void Deposito(double valor_deposito)
        {
            saldo += valor_deposito;
            Movimentacao("+",valor_deposito);
        }
        private void Movimentacao(string op, double valor)
        {
            FileStream historico = new FileStream((Convert.ToString(numero)+".txt"),FileMode.Append,FileAccess.Write);
            StreamWriter sw = new StreamWriter(historico);
            sw.WriteLine(op+Convert.ToString(valor));
            sw.Close();
            historico.Close();
        }
    }
}