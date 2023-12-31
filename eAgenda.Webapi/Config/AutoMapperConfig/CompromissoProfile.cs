﻿using AutoMapper;
using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Webapi.ViewModels.ModuloCompromisso;

namespace eAgenda.Webapi.Config.AutoMapperConfig
{
    public class CompromissoProfile : Profile
    {
        public CompromissoProfile()
        {            
            CreateMap<FormsCompromissoViewModel, Compromisso>()
                .ForMember(destino => destino.Id, opt => opt.Ignore())
                .ForMember(destino => destino.Data, opt => opt.MapFrom(origem => origem.Data.ToUniversalTime()))
                .ForMember(destino => destino.UsuarioId, opt => opt.MapFrom<UsuarioResolver>());

            CreateMap<Compromisso, ListarCompromissoViewModel>()
                .ForMember(d => d.Data, opt => opt.MapFrom(o => o.Data.ToShortDateString()))
                .ForMember(d => d.HoraInicio, opt => opt.MapFrom(o => o.HoraInicio.ToString(@"hh\:mm\:ss")))
                .ForMember(d => d.HoraTermino, opt => opt.MapFrom(o => o.HoraTermino.ToString(@"hh\:mm\:ss")))
                .ForMember(d => d.NomeContato, opt => opt.MapFrom(o => o.Contato.Nome));

            CreateMap<Compromisso, VisualizarCompromissoViewModel>();

            CreateMap<Compromisso, FormsCompromissoViewModel>();
        }
    }
}
