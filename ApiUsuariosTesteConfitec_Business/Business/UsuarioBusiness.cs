using ApiUsuariosTesteConfitec_Domain.Enums;
using ApiUsuariosTesteConfitec_Domain.Interfaces.Business;
using ApiUsuariosTesteConfitec_Domain.Interfaces.Data;
using ApiUsuariosTesteConfitec_Domain.Models;
using ApiUsuariosTesteConfitec_Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiUsuariosTesteConfitec_Business.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioBusiness(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public void AdicionaUsuario(UsuarioViewModel novoUsuario)
        {
            Usuario usuario = new Usuario(
            novoUsuario.Nome,
            novoUsuario.Sobrenome,
            novoUsuario.Email,
            novoUsuario.DataNascimento,
            novoUsuario.Escolaridade);

            _usuarioRepository.AdicionaUsuario(usuario);
        }

        public void AlteraUsuario(UsuarioViewModel novoUsuario)
        {
            Usuario usuarioAlterado = new Usuario(
            novoUsuario.Nome,
            novoUsuario.Sobrenome,
            novoUsuario.Email,
            novoUsuario.DataNascimento,
            novoUsuario.Escolaridade,
            novoUsuario.Id);

            _usuarioRepository.AlteraUsuario(usuarioAlterado);
        }

        public List<EscolaridadeViewModel> Escolaridades()
        {
            List<EscolaridadeViewModel> listaEscolaridades = new List<EscolaridadeViewModel>();

            var dicionario = Enum.GetValues(typeof(EscolaridadeEnum))
               .Cast<EscolaridadeEnum>()
               .ToDictionary(t => (int)t, t => t.ToString());

            foreach (var item in dicionario)
            {
                EscolaridadeViewModel escolaridade = new EscolaridadeViewModel()
                {
                    IdEscolaridade = item.Key,
                    NomeEscolaridade = item.Value
                };
                listaEscolaridades.Add(escolaridade);
            }

            return listaEscolaridades;

        }


        public void RemoveUsuario(int idUsuario) =>
            _usuarioRepository.RemoveUsuario(idUsuario);

        public UsuarioViewModel RetornaUsuarioPorId(int idUsuario)
        {
            var usuario = _usuarioRepository.RetornaUsuarioPorId(idUsuario);
            usuario.DataNascimentoString = usuario.DataNascimento.ToString("dd/MM/yyyy");
            return usuario;

        }

        public List<UsuarioViewModel> RetornaUsuarios()
        {
            var usuarios = _usuarioRepository.RetornaUsuarios();
            usuarios.ForEach(c => c.DataNascimentoString = c.DataNascimento.ToString("dd/MM/yyyy"));
            return usuarios;

        }








    }
}
