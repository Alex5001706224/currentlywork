namespace OnlineShoppingWeb.Service
{
    public interface iFileUpload
    {
        Task<bool> UploadFile(IFormFile filePath);
        string FileName { get; set; }
    }

    public class FileUpload : iFileUpload
    {
        public string? FileName { get; set; }
        public async Task<bool> UploadFile(IFormFile filePath)
        {
            string path = "";
            try
            {
                if (filePath.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot/image"));
                    using(var fileStream = new FileStream(Path.Combine(path, filePath.FileName), FileMode.Create))
                    {
                        await filePath.CopyToAsync(fileStream);
                        this.FileName = fileStream.Name;
                    }
                    return true;
                }
                else
                {
                    return false;
                }    
            }
            catch(Exception ex)
            {
                throw new Exception("File copy failed", ex);
            }
        }
    }
}
