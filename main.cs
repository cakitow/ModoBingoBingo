using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        List<int> numsort = new List<int>();
        Random aleat = new Random();
        for (int i = 1; i <= 75; i++)
        {
            numsort.Add(i);
        }

        for (int i = 0; i < numsort.Count; i++)
        {
            int j = aleat.Next(i, numsort.Count);
            int temp = numsort[i];
            numsort[i] = numsort[j];
            numsort[j] = temp;
        }

        Console.WriteLine("Números sorteados:");
        foreach (int numero in numsort)
        {
            Console.Write(numero + " ");
        }
        Console.WriteLine();

        int[,] cartela = new int[5, 5];
        HashSet<int> numerosUsados = new HashSet<int>();

        for (int coluna = 0; coluna < 5; coluna++)
        {
            int min = coluna * 15 + 1;
            int max = min + 14;

            for (int linha = 0; linha < 5; linha++)
            {
                if (coluna == 2 && linha == 2) // Espaço central é "free"
                {
                    cartela[linha, coluna] = 0;
                    continue;
                }

                int numero;
                do
                {
                    numero = aleat.Next(min, max + 1);
                } while (numerosUsados.Contains(numero));

                numerosUsados.Add(numero);
                cartela[linha, coluna] = numero;
            }
        }


        Console.WriteLine("Sua cartela:");
        for (int linha = 0; linha < 5; linha++)
        {
            for (int coluna = 0; coluna < 5; coluna++)
            {
                if (coluna == 2 && linha == 2)
                    Console.Write("XX".PadLeft(3));
                else
                    Console.Write(cartela[linha, coluna].ToString().PadLeft(3));
                Console.Write(" ");
            }
            Console.WriteLine();
        }


        Console.WriteLine("Pressione qualquer tecla para iniciar.");
        Console.ReadKey();

        HashSet<int> numerosCartela = new HashSet<int>();
        for (int linha = 0; linha < 5; linha++)
        {
            for (int coluna = 0; coluna < 5; coluna++)
            {
                if (coluna != 2 || linha != 2)
                {
                    numerosCartela.Add(cartela[linha, coluna]);
                }
            }
        }

        Console.WriteLine("Números sorteados durante a jogada:");
        foreach (int numero in numsort)
        {
            Console.WriteLine("Número sorteado: " + numero);
            if (numerosCartela.Contains(numero))
            {
                Console.WriteLine("Número na cartela!");
                numerosCartela.Remove(numero);
            }

            if (numerosCartela.Count == 0)
            {
                Console.WriteLine("Você completou a cartela!");
                break;
            }
        }
    }
}