using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Roman.WebApi.Domains
{
    public partial class Equipe
    {
        public Equipe()
        {
            Professors = new HashSet<Professor>();
        }

        public int IdEquipe { get; set; }
        public string Equipe1 { get; set; }

        public virtual ICollection<Professor> Professors { get; set; }
    }
}
