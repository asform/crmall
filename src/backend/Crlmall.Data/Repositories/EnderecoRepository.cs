using Crmall.Domain.Entitities;
using Crmall.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crlmall.Data.Repositories
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DbContext dbContext) : base(dbContext) { }
    }
}
