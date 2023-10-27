using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GenderController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllGenders")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genders = await _studentRepository.GetGendersAysnc();

            if(genders == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<GenderDto>>(genders));
        }
    }
}
