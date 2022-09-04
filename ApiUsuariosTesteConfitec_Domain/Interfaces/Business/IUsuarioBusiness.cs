using ApiUsuariosTesteConfitec_Domain.ViewModels;
using System.Collections.Generic;


namespace ApiUsuariosTesteConfitec_Domain.Interfaces.Business
{
    public interface IUsuarioBusiness
    {
        void AdicionaUsuario(UsuarioViewModel novoUsuario);

        void AlteraUsuario(UsuarioViewModel novoUsuario);

        List<UsuarioViewModel> RetornaUsuarios();

        void RemoveUsuario(int idUsuario);

        List<EscolaridadeViewModel> Escolaridades();

        UsuarioViewModel RetornaUsuarioPorId(int idUsuario);


    }
}
