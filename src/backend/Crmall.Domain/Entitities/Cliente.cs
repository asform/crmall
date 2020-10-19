using System;

namespace Crmall.Domain.Entitities
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }

        public Guid? EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
