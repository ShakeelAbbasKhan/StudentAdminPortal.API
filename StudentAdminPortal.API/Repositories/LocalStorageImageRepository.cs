namespace StudentAdminPortal.API.Repositories
{
    public class LocalStorageImageRepository : IImageRepository
    {
        public async Task<string> UploadImg(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),@"Resources\Images", fileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);

            await file.CopyToAsync(fileStream);

            return GetServerRelativeName(fileName);
        }

        private string GetServerRelativeName(string fileName)
        {
            return Path.Combine(@"Resources\Images", fileName);
        }
    }
}
