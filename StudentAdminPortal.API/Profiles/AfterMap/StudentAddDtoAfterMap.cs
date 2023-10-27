using AutoMapper;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Profiles.AfterMap
{
    public class StudentAddDtoAfterMap : IMappingAction<StudentAddDto, Student>
    {
        public void Process(StudentAddDto source, Student destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            
            destination.Address = new Address()
            {
                Id = Guid.NewGuid(),
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress,
            };
        }
    }
}
