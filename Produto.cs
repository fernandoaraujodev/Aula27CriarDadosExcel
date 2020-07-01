using System.Collections.Generic;
using System.IO;
using System;

namespace Aula27_28_29_30
{
    public class Produto
    {
        
        public int Codigo {get;set;}
        public string Nome {get;set;}
        public float Preco {get;set;}

        private const string PATH = "Database/Produto.csv";

        public Produto()
        {

            //DESAFIO
            string pasta = PATH.Split('/')[0]; //Criando array com o arquivo Database

            if(!Directory.Exists(pasta))//Se o diretório não existe, crie o diretório
            {
                Directory.CreateDirectory(pasta);
            }


            if(!File.Exists(PATH))//criando pasta Database manualmente
            {
                File.Create(PATH).Close();
            }
        
        }

        /// <summary>
        /// Adicionando novos produtos
        /// </summary>
        /// <param name="p"></param>
        public void Inserir(Produto p){
            var linha = new string [] {p.PrepararLinhaCSV(p)};
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// Organizar os dados para ficarem em linhas (codigo=x; nome=a; preco=0)
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        private string PrepararLinhaCSV(Produto produto){

            return $"Cod= {produto.Codigo}; Nome = {produto.Nome}; Preco = {produto.Preco}";
        }

        //-------------------------------------------------------
        //Aula28 - Ler Dados Excel

        public List<Produto> Ler(){

            //Criamos uma lista de produtos
            List<Produto> produtos = new List<Produto>();

            //Transformamos as linhas encontradas em uma array de strings
            string [] lista = File.ReadAllLines(PATH);

            //Varremos este array de strings
            foreach(var linha in lista){

                //Quebramos cada linha da lista em partes
                string[] dados = linha.Split(';'); //dividindo a string em cada ;

                //Tratamento dos dados e adicionar um novo produto
                Produto prod = new Produto();
                prod.Codigo = Int32.Parse (SepararDados(dados[0]));
                prod.Nome   = SepararDados(dados[1]);
                prod.Preco  = float.Parse (SepararDados(dados[2]));

                //Adicionar o produto tratado na lista                
                produtos.Add(prod);

            }

            return produtos;

        }


        /// <summary>
        /// Tratamento da array lista para obter somente nome, preço e código
        /// </summary>
        /// <param name="_coluna"></param>
        /// <returns></returns>
        private string SepararDados(string _coluna){
            
            //cada informação esta assim
            //0       1
            //Preco = The Last Of Us II
            return _coluna.Split("=")[1];

        }

        
    }
}