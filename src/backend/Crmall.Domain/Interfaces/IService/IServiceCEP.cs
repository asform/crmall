using Crmall.Domain.DTOs;
using Crmall.Domain.Infrastructure;

namespace Crmall.Domain.Interfaces.IService
{
    public interface IServiceCEP
    {
        OperationResponse<EnderecoDTO> ConsultarCep(string cep);
    }
}
