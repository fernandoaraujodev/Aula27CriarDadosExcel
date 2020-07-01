using System;
using System.Collections.Generic;

namespace Aula27_28_29_30
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p = new Produto();
            p.Codigo = 4;
            p.Nome = "11 Cidades - Axel Torres";
            p.Preco = 33.98f;

            p.Inserir(p);

            List<Produto> lista1 = new List<Produto>();
            lista1 = p.Ler();

            foreach(Produto item in lista1){
                Console.WriteLine($"Produto: {item.Nome} custa R$ {item.Preco}");
            }



        }
    }
}
