using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Roman.WebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Professores = new HashSet<Professor>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoNavigation { get; set; }
        public virtual ICollection<Professor> Professores { get; set; }
    }
}
