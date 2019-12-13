using System;
using System.IO;
using RoleTopMvc.Models;

namespace RoleTopMvc.Repositories
{
    public class ClienteRepository : RepositorieBase
    {
        private const string PATH = "DataBase/Cliente.csv";

        public ClienteRepository(){
            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }
        public bool Inserir (Cliente cliente){
            var linha = new string[] {PrepararRegistroCsv(cliente)};
            File.AppendAllLines(PATH, linha);

            return true;
        }

        public Cliente obterPor(string email) 
        {
            var linhas = File.ReadAllLines(PATH);
            foreach(var linha in linhas)
            {
                if(ExtrairValorDoCampo("email", linha).Equals(email))
                {
                    Cliente c = new Cliente();
                    c.TipoUsuario = uint.Parse(ExtrairValorDoCampo("tipo_usuario", linha));
                    c.Nome = ExtrairValorDoCampo("nome", linha);
                    c.Email = ExtrairValorDoCampo("email", linha);
                    c.Senha = ExtrairValorDoCampo("senha", linha);
                    c.Documento = ExtrairValorDoCampo("documento", linha);
                    c.Endereco = ExtrairValorDoCampo("endereco", linha);
                    c.Telefone = ExtrairValorDoCampo ("telefone", linha);
                    c.Telefone = ExtrairValorDoCampo("data_nascimento", linha);
                    return c;
                }
            }
            return null;
        }
        private string PrepararRegistroCsv (Cliente cliente){
            return $"tipo_usuario={cliente.TipoUsuario};nome={cliente.Nome};email={cliente.Email};senha={cliente.Senha};documento={cliente.Documento};endereco={cliente.Endereco};telefone={cliente.Telefone};data_nascimento={cliente.DataNascimento}";
        }
    }
}