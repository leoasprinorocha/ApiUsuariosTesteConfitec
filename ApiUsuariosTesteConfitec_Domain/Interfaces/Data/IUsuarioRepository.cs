using ApiUsuariosTesteConfitec_Domain.Models;
using ApiUsuariosTesteConfitec_Domain.ViewModels;
using System.Collections.Generic;

namespace ApiUsuariosTesteConfitec_Domain.Interfaces.Data
{
    public interface IUsuarioRepository
    {
        void AdicionaUsuario(Usuario novoUsuario);
        void AlteraUsuario(Usuario usuarioAlterado);
        List<UsuarioViewModel> RetornaUsuarios();

        UsuarioViewModel RetornaUsuarioPorId(int idUsuario);
        void RemoveUsuario(int idUsuario);
    }
}
