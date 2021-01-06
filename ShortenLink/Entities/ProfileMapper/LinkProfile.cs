using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ProfileMapper
{
    public class LinkProfile : Profile
    {
        public LinkProfile()
        {
            CreateMap<Model.LinkDataModel, DTO.LinkDataDTO>().ReverseMap();
            CreateMap<DTO.LinkCreatingDTO, Model.LinkDataModel>();
            CreateMap<DTO.LinkUpdateDTO, Model.LinkDataModel>();
            CreateMap<DTO.LinkForViewUpdate, Model.LinkDataModel>();
        }
    }
}
