using System;

namespace RoleTopMvc.Models
{
    public class Cliente
    {
        public string Nome {get; set;}
        public string Email {get; set;}
        public string Documento {get; set;}
        public string Telefone {get; set;}
        public DateTime DataNascimento {get; set;}
        public string Endereco {get; set;}
        public string Senha {get; set;}
        public uint TipoUsuario {get; set;}
        
        public Cliente(){
            
        }
        public Cliente (string Nome, string Email, string Documento, string Telefone, DateTime DataNascimento, string Endereco, string Senha){
            this.Nome = Nome;
            this.Email = Email;
            this.Documento = Documento;
            this.Telefone = Telefone;
            this.DataNascimento = DataNascimento;
            this.Endereco = Endereco;
            this.Senha = Senha;
        }
    }
}