using System.Collections.Generic;
namespace SmartSchool.WebAPI.Models
{
    public class Aluno
    {
        public Aluno() { }
        public Aluno(int id, string nome, string telefone)
        {
            this.Id = id;
            this.Nome = nome;
            this.Telefone = telefone;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
         public IEnumerable<AlunoDisciplina> AlunoDisciplinas { get; set; }
    }
}