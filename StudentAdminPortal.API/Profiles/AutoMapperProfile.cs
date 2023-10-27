using AutoMapper;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Models;
using StudentAdminPortal.API.Profiles.AfterMap;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student,StudentDto>().ReverseMap();
            CreateMap<Address, AddressDto >().ReverseMap();
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<StudentUpdateDto, Student>().
                AfterMap<StudentUpdateDtoAfterMap>();
            CreateMap<StudentAddDto, Student>().
                AfterMap<StudentAddDtoAfterMap>();
        }
    }
}
