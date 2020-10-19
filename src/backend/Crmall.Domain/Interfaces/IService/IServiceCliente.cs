using Crmall.Domain.DTOs;
using Crmall.Domain.Entitities;
using Crmall.Domain.Infrastructure;
using System;
using System.Collections.Generic;

namespace Crmall.Domain.Interfaces.IService
{
    public interface IServiceCliente
    {
        OperationResponse<string> Salvar(ClienteDTO cliente);
        OperationResponse<Cliente> Editar(ClienteDTO cliente);
        OperationResponse<string> Remover(Guid Id);
        OperationResponse<List<ClienteDTO>> Listar();
        OperationResponse<ClienteDTO> GetById(Guid id);
    }
}
