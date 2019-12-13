using System.Collections.Generic;
using System.IO;
using RoleTopMVC.Models;

namespace RoleTopMvc.Repositories
{
    public class ServicosRepository : RepositorieBase
    {
        private const string PATH = "Database/Servicos.csv";

        public double obterPrecoDe(string nomeServicos)
        {
            var lista = ObterTodos();
            var preco = 0.0;
            foreach(var item in lista)
            {
                if(item.Nome.Equals(nomeServicos))
                {
                    preco = item.Preco;
                }
            }
            return preco;
        }
        public List<Servicos> ObterTodos(){
            List<Servicos> servicos = new List<Servicos>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach(var linha in linhas)
            {
                Servicos s = new Servicos();
                string[] dados = linha.Split(";");
                s.Nome = dados[0];
                s.Preco = double.Parse(dados[1]);
                servicos.Add(s);
            }
            return servicos;
        }
    }
}