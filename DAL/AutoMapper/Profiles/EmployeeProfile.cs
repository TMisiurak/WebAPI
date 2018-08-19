using System;
using AutoMapper;
using ProjectCore;
using ProjectCore.Models;

namespace DAL.AutoMapper.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
        }
    }
}
