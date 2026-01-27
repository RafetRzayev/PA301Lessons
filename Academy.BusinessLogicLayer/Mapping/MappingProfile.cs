using Academy.BusinessLogicLayer.Dtos;
using Academy.DataAccessLayer.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.BusinessLogicLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(x => x.GroupName, opt => opt.MapFrom(src => src.Group.Name))
                .ReverseMap();
            CreateMap<CreateStudentDto, Student>().ReverseMap();
            CreateMap<UpdateStudentDto, Student>().ReverseMap();

            CreateMap<Group, GroupDto>()
                .ForMember(x => x.StudentNames, opt => opt.MapFrom(src => src.Students.Select(x => x.FirstName))).ReverseMap();
            CreateMap<CreateGroupDto, Group>().ReverseMap();
            CreateMap<UpdateGroupDto, Group>().ReverseMap();
        }
    }
}
