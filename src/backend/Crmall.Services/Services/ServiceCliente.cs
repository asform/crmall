using AutoMapper;
using Crmall.Domain.DTOs;
using Crmall.Domain.Entitities;
using Crmall.Domain.Enum;
using Crmall.Domain.Infrastructure;
using Crmall.Domain.Interfaces;
using Crmall.Domain.Interfaces.IService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crmall.Services.Services
{
    public class ServiceCliente : IServiceCliente
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ServiceCliente> _logger;

        public ServiceCliente(IClienteRepository clienteRepository, 
            IEnderecoRepository enderecoRepository,
            IMapper mapper, 
            ILogger<ServiceCliente> logger)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public OperationResponse<string> Salvar(ClienteDTO cliente)
        {
            var response = new OperationResponse<string>();

            try
            {
                var entity = _mapper.Map<Cliente>(cliente);

                entity.Id = Guid.NewGuid();
                
                if (cliente.Endereco != null)
                {
                    entity.EnderecoId = Guid.NewGuid();
                    SalvarEndereco(entity);
                }

                _clienteRepository.Add(entity);
                _clienteRepository.Commit();

                response.AddMessage(new OperationMessage
                {
                    Description = "Cliente salvo com sucesso!",
                    DescriptionType = OperationMessageTypes.Success.ToString(),
                    Type = OperationMessageTypes.Success
                });
            }
            catch (Exception ex)
            {
                response.AddMessage(new OperationMessage
                {
                    Description = "Erro ao salvar cliente!",
                    DescriptionType = OperationMessageTypes.Error.ToString(),
                    Type = OperationMessageTypes.Error
                });

                _logger.LogError(string.Format("ServiceCliente | Salvar | Ex:{0}", ex.Message));
            }

            return response;
        }

        public OperationResponse<Cliente> Editar(ClienteDTO cliente)
        {
            var response = new OperationResponse<Cliente>();

            try
            {
                var entity = _mapper.Map<Cliente>(cliente);
                _clienteRepository.Update(entity);

                if (cliente.Endereco != null)
                {
                    EditarEndereco(entity);
                }

                _clienteRepository.Commit();

                response.AddMessage(new OperationMessage
                {
                    Description = "Cliente atualizado com sucesso!",
                    DescriptionType = OperationMessageTypes.Success.ToString(),
                    Type = OperationMessageTypes.Success
                });
            }
            catch (Exception ex)
            {
                response.AddMessage(new OperationMessage
                {
                    Description = "Erro ao editar cliente!",
                    DescriptionType = OperationMessageTypes.Error.ToString(),
                    Type = OperationMessageTypes.Error
                });

                _logger.LogError(string.Format("ServiceCliente | Editar | Ex:{0}", ex.Message));
            }

            return response;
        }

        public OperationResponse<string> Remover(Guid Id)
        {
            var response = new OperationResponse<string>();
            
            try
            {
                var entity = _clienteRepository.GetById(Id);

                if (entity.Endereco != null)
                {
                    RemoverEndereco(entity);
                }

                _clienteRepository.Delete(entity);

                _clienteRepository.Commit();

                response.AddMessage(new OperationMessage
                {
                    Description = "Cliente removido com sucesso!",
                    DescriptionType = OperationMessageTypes.Success.ToString(),
                    Type = OperationMessageTypes.Success
                });
            }
            catch (Exception ex)
            {
                response.AddMessage(new OperationMessage
                {
                    Description = "Erro ao remover cliente!",
                    DescriptionType = OperationMessageTypes.Error.ToString(),
                    Type = OperationMessageTypes.Error
                });

                _logger.LogError(string.Format("ServiceCliente | Remover | Ex:{0}", ex.Message));
            }

            return response;
        }

        public OperationResponse<List<ClienteDTO>> Listar()
        {
            var response = new OperationResponse<List<ClienteDTO>>();

            try
            {
                var clientes = _clienteRepository.ListAll().ToList();
                response.Data = _mapper.Map<List<ClienteDTO>>(clientes);
            }
            catch (Exception ex)
            {
                response.AddMessage(new OperationMessage
                {
                    Description = "Erro ao listar clientes!",
                    DescriptionType = OperationMessageTypes.Error.ToString(),
                    Type = OperationMessageTypes.Error
                });

                _logger.LogError(string.Format("ServiceCliente | Listar | Ex:{0}", ex.Message));
            }

            return response;
        }

        public OperationResponse<ClienteDTO> GetById(Guid id)
        {
            var response = new OperationResponse<ClienteDTO>();

            try
            {
                response.Data = _mapper.Map<ClienteDTO>(_clienteRepository.GetById(id));
            }
            catch (Exception ex)
            {
                response.AddMessage(new OperationMessage
                {
                    Description = "Erro ao buscar cliente!",
                    DescriptionType = OperationMessageTypes.Error.ToString(),
                    Type = OperationMessageTypes.Error
                });

                _logger.LogError(string.Format("ServiceCliente | GetById | Ex:{0}", ex.Message));
            }

            return response;
        }

        private void SalvarEndereco(Cliente cliente)
        {
            cliente.Endereco.Id = cliente.EnderecoId.Value;
            cliente.Endereco.ClienteId = cliente.Id;

            _enderecoRepository.Add(cliente.Endereco);
            _enderecoRepository.Commit();
        }

        private void EditarEndereco(Cliente cliente)
        {
            var enderecoDTO = _mapper.Map<EnderecoDTO>(cliente.Endereco);

            var endereco = _enderecoRepository.GetById(cliente.Endereco.Id);

            if (endereco != null)
            {
                endereco.Bairro = enderecoDTO.Bairro;
                endereco.Cep = enderecoDTO.Cep;
                endereco.Cidade = enderecoDTO.Cidade;
                endereco.Complemento = enderecoDTO.Complemento;
                endereco.Estado = enderecoDTO.Estado;
                endereco.Logradouro = enderecoDTO.Logradouro;
                endereco.Numero = enderecoDTO.Numero;

                _enderecoRepository.Update(endereco);
            }
            else
            {
                SalvarEndereco(cliente);
            }
            _enderecoRepository.Commit();
        }

        private void RemoverEndereco(Cliente cliente)
        {
            var endereco = _enderecoRepository.GetById(cliente.Endereco.Id);

            if (endereco != null)
            {
                _enderecoRepository.Delete(endereco);
            }
            else
            {
                SalvarEndereco(cliente);
            }
            _enderecoRepository.Commit();
        }
    }
}
