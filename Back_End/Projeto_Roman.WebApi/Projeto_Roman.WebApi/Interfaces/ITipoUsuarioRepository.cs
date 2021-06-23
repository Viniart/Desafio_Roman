using Projeto_Roman.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Listar todos os tipos de usuario
        /// </summary>
        /// <returns></returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Buscar um tipo de usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TipoUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastrar um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsuario"></param>
        void Cadastrar(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Deletar um tipo de usuario por id
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
