using AutoMapper;
using Crmall.Domain.DTOs;
using Crmall.Domain.Enum;
using Crmall.Domain.Infrastructure;
using Crmall.Domain.Interfaces.IService;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;

namespace Crmall.Services.Services
{
    public class ServiceCEP : IServiceCEP
    {
        private readonly ILogger<ServiceCEP> _logger;
        private readonly IMapper _mapper;

        public ServiceCEP(ILogger<ServiceCEP> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public OperationResponse<EnderecoDTO> ConsultarCep(string cep)
        {
            var response = new OperationResponse<EnderecoDTO>();

            try
            {
                using (var webClient = new WebClient())
                {
                    var url = string.Format("https://viacep.com.br/ws/{0}/json/", cep);
                    var responseViaCepAPI = JsonConvert.DeserializeObject<ViaCepDTO>(webClient.DownloadString(url));

                    response.Data = _mapper.Map<EnderecoDTO>(responseViaCepAPI);
                }
            }
            catch (Exception ex)
            {
                response.AddMessage(new OperationMessage
                {
                    Description = "Erro ao buscar CEP!",
                    DescriptionType = OperationMessageTypes.Error.ToString(),
                    Type = OperationMessageTypes.Error
                });

                _logger.LogError(string.Format("ServiceCEP | ConsultarCep | Ex:{0}", ex.Message));
            }

            return response;
        }
    }
}
