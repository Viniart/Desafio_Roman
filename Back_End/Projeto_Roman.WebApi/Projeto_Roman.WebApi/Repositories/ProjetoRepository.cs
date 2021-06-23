using Microsoft.EntityFrameworkCore;
using Projeto_Roman.WebApi.Context;
using Projeto_Roman.WebApi.Domains;
using Projeto_Roman.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.WebApi.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        RomanContext ctx = new RomanContext();

        /// <summary>
        /// Atualiza um Projeto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projetoAtualizado"></param>
        public void Atualizar(int id, Projeto projetoAtualizado)
        {
            Projeto projetoBuscado = ctx.Projetos.Find(id);

            if (projetoAtualizado.Projeto1 != null)
            {
                projetoBuscado.Projeto1 = projetoAtualizado.Projeto1;
            }

            if (projetoAtualizado.IdProfessor != null)
            {
                projetoBuscado.IdProfessor = projetoAtualizado.IdProfessor;
            }

            ctx.Projetos.Update(projetoBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Projeto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Projeto BuscarPorId(int id)
        {
            return ctx.Projetos
                .Include(t => t.ProjetoTemas)
                .FirstOrDefault(c => c.IdProjeto == id);
        }

        /// <summary>
        /// Cadastra um novo Projeto
        /// </summary>
        /// <param name="novoProjeto"></param>
        public void Cadastrar(Projeto novoProjeto)
        {
            ctx.Projetos.Add(novoProjeto);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Projeto pelo id
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            ctx.Projetos.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Projetos
        /// </summary>
        /// <returns></returns>
        public List<Projeto> Listar()
        {
            return ctx.Projetos
                .Include(p => p.ProjetoTemas)
                .Include(p => p.IdProfessorNavigation)
                .Select(p => new Projeto ()
                {
                    IdProjeto = p.IdProjeto,
                    IdProfessor = p.IdProfessor,
                    Projeto1 = p.Projeto1,

                    IdProfessorNavigation = new Professor()
                    {
                        Nome = p.IdProfessorNavigation.Nome,

                        IdEquipeNavigation = new Equipe()
                        {
                            Equipe1 = p.IdProfessorNavigation.IdEquipeNavigation.Equipe1
                        }
                    }
                    

                })
                .ToList();
        }
    }
}
