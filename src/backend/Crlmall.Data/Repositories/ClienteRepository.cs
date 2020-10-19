using Crmall.Domain.Entitities;
using Crmall.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crlmall.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(DbContext dbContext) : base(dbContext) { }
    }
}
