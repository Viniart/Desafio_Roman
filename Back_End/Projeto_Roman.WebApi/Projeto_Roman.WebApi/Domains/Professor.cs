using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Roman.WebApi.Domains
{
    public partial class Professor
    {
        public Professor()
        {
            Projetos = new HashSet<Projeto>();
        }

        public int IdProfessor { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEquipe { get; set; }
        public string Nome { get; set; }

        public virtual Equipe IdEquipeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
