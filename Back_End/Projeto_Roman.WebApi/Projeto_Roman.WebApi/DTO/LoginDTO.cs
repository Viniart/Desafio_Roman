﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.WebApi.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O campo Email deve ser informado")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha deve ser informado")]
        public string Senha { get; set; }
    }
}
