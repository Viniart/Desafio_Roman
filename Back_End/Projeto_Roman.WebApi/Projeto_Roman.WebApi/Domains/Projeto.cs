using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Roman.WebApi.Domains
{
    public partial class Projeto
    {
        public Projeto()
        {
            ProjetoTemas = new HashSet<ProjetoTema>();
        }

        public int IdProjeto { get; set; }
        public int? IdProfessor { get; set; }
        public string Projeto1 { get; set; }

        public virtual Professor IdProfessorNavigation { get; set; }
        public virtual ICollection<ProjetoTema> ProjetoTemas { get; set; }
    }
}
