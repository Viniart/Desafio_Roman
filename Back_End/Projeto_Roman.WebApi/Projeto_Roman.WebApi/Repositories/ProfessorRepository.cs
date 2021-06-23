using Projeto_Roman.WebApi.Context;
using Projeto_Roman.WebApi.Domains;
using Projeto_Roman.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.WebApi.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        RomanContext ctx = new RomanContext();

        /// <summary>
        /// Atualiza um Professor pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="professorAtualizado"></param>
        public void Atualizar(int id, Professor professorAtualizado)
        {
            Professor professorBuscado = ctx.Professors.Find(id);

            if (professorAtualizado.Nome != null)
            {
                professorBuscado.Nome = professorAtualizado.Nome;
            }

            if (professorAtualizado.IdEquipe != null)
            {
                professorBuscado.IdEquipe = professorAtualizado.IdEquipe;
            }

            ctx.Professors.Update(professorBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Professor pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Professor BuscarPorId(int id)
        {
            return ctx.Professors
                .FirstOrDefault(c => c.IdProfessor == id);
        }

        /// <summary>
        /// Cadastra um novo Professor
        /// </summary>
        /// <param name="novoProfessor"></param>
        public void Cadastrar(Professor novoProfessor)
        {
            ctx.Professors.Add(novoProfessor);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Professor pelo id
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            ctx.Professors.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Professors
        /// </summary>
        /// <returns></returns>
        public List<Professor> Listar()
        {
            return ctx.Professors
                .ToList();
        }
    }
}
