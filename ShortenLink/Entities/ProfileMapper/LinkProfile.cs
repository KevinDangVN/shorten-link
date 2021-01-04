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
        }
    }
}
