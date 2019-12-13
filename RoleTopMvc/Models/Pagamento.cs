namespace RoleTopMVC.Models
{
    public class Pagamento : Adicionais
    {
        public Pagamento(){

        }
        public Pagamento(string nome, double preco){
            this.Nome = nome;
            this.Preco = preco;
        }
    }
}