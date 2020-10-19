using Crmall.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Crmall.Domain.DTOs
{
    public class ClienteDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(250)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário informar a data de nascimento.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "É necessário informar o sexo.")]
        public string Sexo { get; set; }

        public EnderecoDTO Endereco { get; set; }
    }
}
