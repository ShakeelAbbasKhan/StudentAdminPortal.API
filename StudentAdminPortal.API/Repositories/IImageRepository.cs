namespace StudentAdminPortal.API.Repositories
{
    public interface IImageRepository
    {
        Task<string> UploadImg(IFormFile file, string fileName);
    }
}
