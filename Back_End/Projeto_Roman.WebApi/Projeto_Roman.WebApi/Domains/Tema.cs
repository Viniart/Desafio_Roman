using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Roman.WebApi.Domains
{
    public partial class Tema
    {
        public Tema()
        {
            ProjetoTemas = new HashSet<ProjetoTema>();
        }

        public int IdTema { get; set; }
        public string Tema1 { get; set; }

        public virtual ICollection<ProjetoTema> ProjetoTemas { get; set; }
    }
}
