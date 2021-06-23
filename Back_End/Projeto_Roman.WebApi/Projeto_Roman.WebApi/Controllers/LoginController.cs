﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Projeto_Roman.WebApi.Domains;
using Projeto_Roman.WebApi.DTO;
using Projeto_Roman.WebApi.Interfaces;
using Projeto_Roman.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projeto_Roman.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("E-mail ou senha inválidos!");
                }

                var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipo.ToString()),

                new Claim("role", usuarioBuscado.IdTipo.ToString())
            };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("c6301348-6898-4548-be7c-060d61d6307e"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "SpMedGroup.webApi",
                    audience: "SpMedGroup.webApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    mensagem = "",
                    ex
                });
            }
        }
    }
}
