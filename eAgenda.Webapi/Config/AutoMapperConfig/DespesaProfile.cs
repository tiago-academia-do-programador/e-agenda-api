﻿using AutoMapper;
using eAgenda.Dominio.Compartilhado;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Webapi.ViewModels.ModuloDespesa;
using System.Linq;

namespace eAgenda.Webapi.Config.AutoMapperConfig
{
    public class DespesaProfile : Profile
    {
        public DespesaProfile()
        {
            CreateMap<FormsDespesaViewModel, Despesa>()
                .ForMember(destino => destino.Id, opt => opt.Ignore())
                .ForMember(destino => destino.Categorias, opt => opt.Ignore())
                .ForMember(destino => destino.Data, opt => opt.MapFrom(origem => origem.Data.ToUniversalTime()))
                .ForMember(destino => destino.UsuarioId, opt => opt.MapFrom<UsuarioResolver>())
                .AfterMap<ConfigurarCategoriasInsertMappingAction>();

            CreateMap<Despesa, ListarDespesaViewModel>()
                .ForMember(destino => destino.FormaPagamento, opt => opt.MapFrom(origem => origem.FormaPagamento.GetDescription()));

            CreateMap<Despesa, VisualizarDespesaViewModel>()
                .ForMember(destino => destino.FormaPagamento, opt => opt.MapFrom(origem => origem.FormaPagamento.GetDescription()))
                .ForMember(destino => destino.Categorias, opt =>
                    opt.MapFrom(origem => origem.Categorias.Select(x => x.Titulo)));

            CreateMap<Despesa, FormsDespesaViewModel>()
                .ForMember(destino => destino.CategoriasSelecionadas, opt => opt.Ignore())
                .AfterMap<ConfigurarCategoriasEditMappingAction>();
        }
    }
}