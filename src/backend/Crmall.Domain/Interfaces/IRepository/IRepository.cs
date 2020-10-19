using Crmall.Domain.Entitities;
using System;
using System.Collections.Generic;

namespace Crmall.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(Guid id);
        IEnumerable<T> ListAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Commit();
    }
}
