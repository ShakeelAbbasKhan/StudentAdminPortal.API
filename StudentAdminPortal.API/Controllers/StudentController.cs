using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Models;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllStd")]
        public async Task<IActionResult> GetAllStudents() 
        {
            var std = await _studentRepository.GetStudentsAsync();

            // here we send data from student to studentDto and alot of code we have written 
            // but the values are same in student and studentDto so to match this
            // and avoid alot of code we use automapper

            //var stdDto = new List<StudentDto>();

            //foreach (var student in std)
            //{
            //    stdDto.Add(new StudentDto()
            //    {
            //        Id = student.Id,
            //        FirstName = student.FirstName,
            //        LastName = student.LastName,
            //        DateOfBirth = student.DateOfBirth,
            //        Email = student.Email,
            //        Mobile = student.Mobile,
            //        ProfileImageUrl = student.ProfileImageUrl,
            //        GenderId = student.GenderId,
            //        Address = new AddressDto() 
            //        {
            //            Id = student.Address.Id,
            //            PhysicalAddress = student.Address.PhysicalAddress,
            //            PostalAddress = student.Address.PostalAddress,
            //        },
            //        Gender = new GenderDto()
            //        {
            //            Id = student.Gender.Id,
            //            Description = student.Gender.Description,
            //        },
            //    }) ;
            //}

            // now use of automapper

            return Ok(_mapper.Map<List<StudentDto>>(std));
        }

        [HttpGet("GetStdById/{id}")]
        public async Task<IActionResult> GetStdById([FromRoute] Guid id)
        {
            var std = await _studentRepository.GetStudentAsync(id);
            if (std == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<StudentDto>(std));
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] StudentAddDto studentAddDto)
        {
            var std = await _studentRepository.AddStudentAsync(_mapper.Map<Student>(studentAddDto));
            return Ok(std);
        }

        [HttpPut("UpdateStudent/{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, [FromBody] StudentUpdateDto studentUpdateDto)
        {
            var updateStdExist = await _studentRepository.GetStudentAsync(id);
            if (updateStdExist != null)
            {
                // update method
                var orignalStd = _mapper.Map<Student>(studentUpdateDto);    // orignalStd b/c give to db so it is destination
                var updatedStudent = await _studentRepository.UpdateStudentAsync(id, orignalStd);

                if (updatedStudent != null)
                {
                    return Ok(_mapper.Map<StudentDto>(updatedStudent));     // here studentDto b/c return to user
                }
            }

            return NotFound();
        }

        [HttpDelete("DeleteStd/{id}")]
        public async Task<IActionResult> DeleteStd(Guid id)
        {
            var deletedStd = await _studentRepository.DeleteStdAsync(id);
            if(deletedStd == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<StudentDto>(deletedStd));
        }

       
    }
}
