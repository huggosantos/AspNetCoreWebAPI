using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Disciplina
    {
        public Disciplina(int id, string nome, int professorId)
        {
            this.Id = id;
            this.Nome = nome;
            this.ProfessorId = professorId;
        }
        public Disciplina(int id, string nome, int professorId, Professor professor) 
        {
            this.Id = id;
                this.Nome = nome;
                this.ProfessorId = professorId;
                this.Professor = professor;
               
        }
                public int Id { get; set; }
        public string Nome { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public IEnumerable<AlunoDisciplina> AlunoDisciplinas { get; set; }

    }
}