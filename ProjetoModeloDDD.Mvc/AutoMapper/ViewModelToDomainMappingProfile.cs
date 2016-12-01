using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Mvc.ViewModels;


namespace ProjetoModeloDDD.Mvc.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
  

        protected override void Configure()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ProdutoViewModel, Produto>();
        }

    }
}