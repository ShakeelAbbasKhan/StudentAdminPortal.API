using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid id);
        Task<List<Gender>> GetGendersAysnc();

        Task<Student> UpdateStudentAsync(Guid studentId, Student student);
        Task<Student> AddStudentAsync(Student student);

        Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl);


        Task<Student> DeleteStdAsync(Guid id);
    }
}
