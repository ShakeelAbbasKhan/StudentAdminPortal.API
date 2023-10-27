using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Student> DeleteStdAsync(Guid id)
        {
            var student = await _context.Students.Include(u => u.Gender).Include(u => u.Address).FirstOrDefaultAsync(u => u.Id == id);
            
            if (student != null)
            {
                _context.Remove(student);

                var address = await _context.Addresses.FirstOrDefaultAsync(u=>u.StudentId == id);
                if (address != null) 
                {
                    _context.Remove(address);
                }

               await _context.SaveChangesAsync();
                return student;
            }
            return null;
        }

        public async Task<List<Gender>> GetGendersAysnc()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task<Student> GetStudentAsync(Guid id)
        {
            var student = await _context.Students.Include(u => u.Gender).Include(u => u.Address).FirstOrDefaultAsync(u=> u.Id==id);
            return student;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            var students =await _context.Students.Include(u=>u.Gender).Include(u=>u.Address).ToListAsync();
            return students;
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            var addStd = await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudentAsync(Guid studentId, Student student)
        {
            var existingStd = await GetStudentAsync(studentId);
            if (existingStd != null)
            {
                existingStd.FirstName = student.FirstName;
                existingStd.LastName = student.LastName;
                existingStd.DateOfBirth = student.DateOfBirth;
                existingStd.Email = student.Email;
                existingStd.Mobile = student.Mobile;
                existingStd.GenderId = student.GenderId;
                existingStd.Address.PhysicalAddress = student.Address.PhysicalAddress;
                existingStd.Address.PostalAddress = student.Address.PostalAddress;

                await _context.SaveChangesAsync();
                return existingStd;
            }



            return null;
        }

        public async Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl)
        {
            var student = await GetStudentAsync(studentId);
            if(student != null)
            {
                student.ProfileImageUrl = profileImageUrl;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
