using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Mvc.ViewModels;

namespace ProjetoModeloDDD.Mvc.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        //protected DomainToViewModelMappingProfile(string profileName) : base(profileName)
        //{
            
        //}

        protected override void Configure()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Produto, ProdutoViewModel>();

            base.Configure();
        }

    }
}