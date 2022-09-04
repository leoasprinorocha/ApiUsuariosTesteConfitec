using ApiUsuariosTesteConfitec_Domain.Interfaces.Business;
using ApiUsuariosTesteConfitec_Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiUsuariosTesteConfitec.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public UsuariosController(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }


        [HttpPost]
        [Route("AdicionaUsuario")]
        public IActionResult AdicionaUsuario(UsuarioViewModel usuario)
        {
            try
            {
                _usuarioBusiness.AdicionaUsuario(usuario);
                return Ok(new {message = "Usuário adionado com sucesso!", statusCode = Response.StatusCode });
            }
            catch (Exception ex)
            {
                return Ok(new {message = ex.Message, statusCode = Response.StatusCode });

            }
        }

        [HttpPut]
        [Route("AlteraUsuario")]
        public IActionResult AlteraUsuario(UsuarioViewModel usuario)
        {
            try
            {
                _usuarioBusiness.AlteraUsuario(usuario);
                return Ok(new {message = "Usuário alterado com sucesso!", statusCode = Response.StatusCode });
            }
            catch (Exception ex)
            {
                return Ok(new {message = ex.Message, statusCode = Response.StatusCode });

            }
        }

        [HttpGet]
        [Route("RetornaUsuarios")]
        public IActionResult RetornaUsuarios()
        {
            try
            {
                return Ok(_usuarioBusiness.RetornaUsuarios());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetornaUsuarioPorId/{idUsuario}")]
        public async Task<IActionResult> RetornaUsuarioPorId(int idUsuario)
        {
            try
            {
                return Ok(_usuarioBusiness.RetornaUsuarioPorId(idUsuario));
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeletaUsuario/{id}")]
        public IActionResult DeletaUsuario(int id)
        {
            try
            {
                
                _usuarioBusiness.RemoveUsuario(id);
                return Ok(new {message = "Usuário removido com sucesso!", statusCode = Response.StatusCode });
            }
            catch (Exception ex)
            {
                return Ok(new {message = ex.Message, statusCode = Response.StatusCode });
            }
        }


        [HttpGet]
        [Route("RetornaEscolaridades")]
        public async Task<IActionResult> RetornaEscolaridades() =>
            Ok(_usuarioBusiness.Escolaridades());

    }
}
