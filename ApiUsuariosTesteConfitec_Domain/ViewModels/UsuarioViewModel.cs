using System;

namespace ApiUsuariosTesteConfitec_Domain.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id{ get; set; }
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public string DataNascimentoString{ get; set; }

        public int Escolaridade { get; set; }
    }
}
