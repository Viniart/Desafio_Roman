using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Roman.WebApi.Domains
{
    public partial class ProjetoTema
    {
        public int IdProjetoTema { get; set; }
        public int? IdProjeto { get; set; }
        public int? IdTema { get; set; }

        public virtual Projeto IdProjetoNavigation { get; set; }
        public virtual Tema IdTemaNavigation { get; set; }
    }
}
