using AutoMapper;
using Crmall.Domain.DTOs;
using Crmall.Domain.Entitities;

namespace Crmall.Data.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClienteDTO, Cliente>()
                .ReverseMap();

            CreateMap<ViaCepDTO, EnderecoDTO>()
                .ForMember(a => a.Cidade, opt => opt.MapFrom(b => b.Localidade))
                .ForMember(a => a.Estado, opt => opt.MapFrom(b => b.Uf))
                .ReverseMap();

            CreateMap<EnderecoDTO, Endereco>()
                .ReverseMap();
        }
    }
}
