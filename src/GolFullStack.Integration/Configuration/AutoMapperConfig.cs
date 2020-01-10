using System;
using AutoMapper;
using GolFullStack.Entity.Entities.Business;
using GolFullStack.Integration.ViewModels.Business;

namespace GolFullStack.Integration.Configuration
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            #region Tables

            #region Business

            CreateMap<Airplane, AirplaneViewModel>().ReverseMap();

            #endregion

            #endregion
        }
    }
}
