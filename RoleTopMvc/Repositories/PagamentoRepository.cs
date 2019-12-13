using System.Collections.Generic;
using System.IO;
using RoleTopMVC.Models;

namespace RoleTopMvc.Repositories
{
    public class PagamentoRepository
    {
        private const string PATH = "Database/Pagamento.csv";
        
        public double obterPrecoDe(string nomePagamento)
        {
            var lista = ObterTodos();
            var preco = 0.0;
            foreach (var item in lista)
            {
                if(item.Nome.Equals(nomePagamento))
                {
                    preco = item.Preco;
                    break;
                }
            }
            return preco;
        }
        public List<Pagamento> ObterTodos()
        {
            List<Pagamento> pagamento = new List<Pagamento>();
            string[] linhas = File.ReadAllLines(PATH); 
            foreach(var linha in linhas)
            {
                Pagamento p = new Pagamento();
                string [] dados = linha.Split(";");
                p.Nome = dados[0];
                p.Preco = double.Parse(dados[1]);
                pagamento.Add(p);
            }
            return pagamento;
        }
    }
}