using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ProfileMapper
{
    class EmpProfile : Profile
    {
        public EmpProfile()
        {
            CreateMap<Model.EmployeeModel, DTO.EmployeeDTO>().ReverseMap();
            CreateMap<DTO.EmployeeCreatingDTO, Model.EmployeeModel>();
        }
    }
}
