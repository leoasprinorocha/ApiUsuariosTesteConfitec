using ApiUsuariosTesteConfitec_Data.Context;
using ApiUsuariosTesteConfitec_Data.DbSessionManagerConfig;
using ApiUsuariosTesteConfitec_Domain.Interfaces.Data;
using ApiUsuariosTesteConfitec_Domain.Models;
using ApiUsuariosTesteConfitec_Domain.ViewModels;
using Dapper;
using System.Collections.Generic;
using System.Linq;


namespace ApiUsuariosTesteConfitec_Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuariosContext _context;
        private readonly DbSession _session;
        public UsuarioRepository(UsuariosContext context, DbSession session)
        {
            _context = context;
            _session = session;
        }
        public void AdicionaUsuario(Usuario novoUsuario)
        {
            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();
        }

        public void AlteraUsuario(Usuario usuarioAlterado)
        {
            var usuarioASerAlterado = _context.Usuarios.FirstOrDefault(c => c.Id == usuarioAlterado.Id);
            usuarioASerAlterado.Nome = usuarioAlterado.Nome;
            usuarioASerAlterado.Sobrenome = usuarioAlterado.Sobrenome;
            usuarioASerAlterado.Email = usuarioAlterado.Email;
            usuarioASerAlterado.DataNascimento = usuarioAlterado.DataNascimento;
            usuarioASerAlterado.Escolaridade = usuarioAlterado.Escolaridade;

            _context.Usuarios.Update(usuarioASerAlterado);
            _context.SaveChanges();


        }

        public void RemoveUsuario(int idUsuario)
        {
            var usuarioASerRemovido = _context.Usuarios.FirstOrDefault(c => c.Id == idUsuario);
            _context.Usuarios.Remove(usuarioASerRemovido);
            _context.SaveChanges();
        }

        public UsuarioViewModel RetornaUsuarioPorId(int idUsuario)
        {
            string query = "SELECT * FROM Usuarios where Id = @pidUsuario";
            return SqlMapper.Query<UsuarioViewModel>(_session.Connection, query, new { pIdUsuario = idUsuario }).FirstOrDefault();
        }

        public List<UsuarioViewModel> RetornaUsuarios()
        {
            string query = "SELECT * FROM Usuarios";
            return SqlMapper.Query<UsuarioViewModel>(_session.Connection, query).ToList();
        }


    }
}
