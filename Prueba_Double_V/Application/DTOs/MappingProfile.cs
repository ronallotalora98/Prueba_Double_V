using AutoMapper;
using Prueba_Double_V.Domain.Models;

namespace Prueba_Double_V.Application.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
        
            CreateMap<PersonaDTO, Persona>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.Nombres))
               .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.Apellidos))
               .ForMember(dest => dest.NumeroIdentificacion, opt => opt.MapFrom(src => src.NumeroIdentificacion))
               .ForMember(dest => dest.TipoIdentificacion, opt => opt.MapFrom(src => src.TipoIdentificacion))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.NombresApellidosConcatenado, opt => opt.MapFrom(src => src.Nombres + " " + src.Apellidos))
               .ForMember(dest => dest.NumeroIdentificacionConcatenado, opt => opt.MapFrom(src => src.TipoIdentificacion + " " + src.NumeroIdentificacion))
               .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.FechaCreacion))
                .ReverseMap();

            CreateMap<UsuarioDTO, Usuario>().ReverseMap();

            CreateMap<LoginRequest, Usuario>()
               .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Usuario))
               .ForMember(dest => dest.Pass, opt => opt.MapFrom(src => src.Pass))
                .ReverseMap();

            // CreateMap<List<PersonaDTO>, List<Persona>>().ReverseMap();



        }
    }
}
