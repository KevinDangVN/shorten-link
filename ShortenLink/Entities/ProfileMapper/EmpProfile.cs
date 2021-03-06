﻿using AutoMapper;
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
            CreateMap<Model.EmployeeModel, DTO.EmployeeForUpdate>();
            CreateMap<DTO.EmployeeForUpdate, Model.EmployeeModel>();
            CreateMap<DTO.EmployeeWithRoleNameDTO, Model.EmployeeModel>();
        }
    }
}
