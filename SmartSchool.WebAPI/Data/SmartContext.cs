using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;
namespace SmartSchool.WebAPI.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options)
        {
            
        }       
        public Dbset<Aluno> Alunos {get; set;}
        public Dbset<Professor> Professores {get; set;}
        public Dbset<Disciplina> Disciplinas {get; set;}
        public Dbset<AlunoDisciplina> AlunosDisciplinas {get; set;}

        protected overrride OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoDisciplina>()
                .HasKey(AD => new {AD.AlunoId, AD.DisciplinaId});
        }
    }
}