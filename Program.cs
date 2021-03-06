﻿using System;
using System.Collections.Generic;

namespace Aula27_28_29_30
{
    class Program
    {
        static void Main(string[] args)
        {
            //instanciando um novo produto que será armazenado na database/produto.csv
            Produto p = new Produto();
            p.Codigo = 2;
            p.Nome = "11 Cidades - Axel Torres";
            p.Preco = 49.98f;

            //Inserindo produto 
            p.Inserir(p);

            Produto pAlterado = new Produto();
            pAlterado.Codigo = 8;
            pAlterado.Nome = "Diário de um banana";
            pAlterado.Preco = 14.98f;
            p.Alterar(pAlterado);

            //Remover todos os produtos com esse nome
            //p.Remover("11 Cidades - Axel Torres");

            //Filtrar produto com o termo
            //p.Filtrar("Pirâmide Invertida");

            //Instanciando a lista de produto
            List<Produto> lista1 = new List<Produto>();
            lista1 = p.Ler();

            foreach(Produto item in lista1){
                Console.WriteLine($"Produto: {item.Nome} custa R$ {item.Preco}");
            }

            
        }
    
    
    }
}
