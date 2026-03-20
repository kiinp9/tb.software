namespace traobang.be.infrastructure.external.File
{
    public interface IFileS3Services
    {
        public Task<string?> WriteStreamFileAsync(string? fileName, params Stream[] files);
    }
}
