using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.Mvc.AutoMapper
{
    public class AutomapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(x => 
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
        
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}