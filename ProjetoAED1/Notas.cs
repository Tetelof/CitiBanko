using System;

namespace ProjetoAED1
{
    public class Notas
    {
        // Atributos
        private int notas_100;
        private int notas_50;
        private int notas_20;
        private int notas_10;
        private int notas_5;
        private int notas_2;
        private int valor_caixa;

        // GetSet
        public int Valor_caixa
        {
            get { return valor_caixa; }
            set { valor_caixa = value; }
        }
        
        // Construtor
        public Notas()
        {

        }
        public void Abastecer()
        {
            Console.WriteLine("Digite quantidade notas:");
            Console.Write("100: ");notas_100 = int.Parse(Console.ReadLine());
            Console.Write("50:  ");notas_50 = int.Parse(Console.ReadLine());
            Console.Write("20:  ");notas_20 = int.Parse(Console.ReadLine());
            Console.Write("10:  ");notas_10 = int.Parse(Console.ReadLine());
            Console.Write("5:   ");notas_5 = int.Parse(Console.ReadLine());
            Console.Write("2:   ");notas_2 = int.Parse(Console.ReadLine());
        }
        
        // Métodos
        public int defineValorCaixa()
        {
            int valor = notas_100 * 100 + notas_50 * 50 + notas_20 * 20 + notas_10 * 10 + notas_5 * 5 + notas_2 * 2;
            return valor;
        }
        public int validarValor(double valor)
        {
            Console.WriteLine("debug valor: "+valor);
            int novo_valor = 0;
            if(valor % 2 != 0)
            {
                novo_valor = Convert.ToInt32(valor);
                novo_valor = novo_valor/2;
                novo_valor = novo_valor*2;
            }
            else
            {
                novo_valor= Convert.ToInt32(valor);
            }
            Console.WriteLine("debug valor_caixa: "+valor_caixa);
            if (valor > valor_caixa)
            {
                novo_valor = valor_caixa;
                valor_caixa = 0;
            }
            if (novo_valor != valor)
            {
                Console.WriteLine("Devido a indisponibilidade de notas, o valor pedido foi alterado.");
                Console.WriteLine("O novo valor é: ",novo_valor);
            }
            Console.WriteLine("debug novo_valor: "+novo_valor);
            return novo_valor;
        }
        public int[] distribuirNotas(int valor)
        {
            int[] notas = new int[] {0,0,0,0,0,0};
            int falta = 0;
            
            
            notas[0] = (valor/100);
            valor = valor % 100;
            if (notas_100 < notas[0])
            {
                falta = notas[0] - notas_100;
                notas[0] = notas_100;
                notas_100 = 0;
                valor = valor + (falta*100);
            }
            else
            {
                notas_100 = notas_100 - notas[0];
            }
            notas[1] = (valor/50);
            valor = valor % 50;
            if (notas_50 < notas[1])
            {
                falta = notas[1] - notas_50;
                notas[1] = notas_50;
                notas_50 = 0;
                valor = valor + (falta*50);
            }
            else
            {
                notas_50 = notas_50 - notas[1];
            }
            notas[2] = (valor/20);
            valor = valor % 20;
            if (notas_20 < notas[2])
            {
                falta = notas[2] - notas_20;
                notas[2] = notas_20;
                notas_20 = 0;
                valor = valor + (falta*20);
            }
            else
            {
                notas_20 = notas_20 - notas[2];
            }
            notas[3] = (valor/10);
            valor = valor % 10;
            if (notas_10 < notas[3])
            {
                falta = notas[3] - notas_10;
                notas[3] = notas_10;
                notas_10 = 0;
                valor = valor + (falta*10);
            }
            else
            {
                notas_10 = notas_10 - notas[3];
            }
            notas[4] = (valor/5);
            valor = valor % 5;
            if (notas_5 < notas[4])
            {
                falta = notas[4] - notas_5;
                notas[4] = notas_5;
                notas_5 = 0;
                valor = valor + (falta*5);
            }
            else
            {
                notas_5 = notas_5 - notas[4];
            }
            notas[5] = (valor/2);
            valor = valor % 2;
            if (notas_2 < notas[5])
            {
                falta = notas[5] - notas_2;
                notas[5] = notas_2;
                notas_2 = 0;
                valor = valor + (falta*2);
            }
            else
            {
                notas_2 = notas_2 - notas[5];
            }
            return notas;
        }
    }
}