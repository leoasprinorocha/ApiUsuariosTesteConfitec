using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using ApiUsuariosTesteConfitec_Domain.Enums;
using System.Net.Mail;

namespace ApiUsuariosTesteConfitec_Domain.Models
{
    public class Usuario
    {
        public Usuario(string nome, string sobrenome, string email, DateTime dataNascimento, int escolaridade, int id = 0)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Email = ValidaEmail(email);
            this.DataNascimento = ValidaDataNascimento(dataNascimento);
            this.Escolaridade = (EscolaridadeEnum)escolaridade;
            if (id != 0)
                this.Id = id;
        }

        private Usuario()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public EscolaridadeEnum Escolaridade { get; set; }


        private string ValidaEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return emailaddress;

            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }

        private DateTime ValidaDataNascimento(DateTime data)
        {
            if (data > DateTime.Today)
                throw new Exception("Data informada maior que data atual");
            else
                return data;
        }
    }
}
