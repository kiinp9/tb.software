namespace traobang.be.infrastructure.external.File.Dtos
{
    public class FileS3Config
    {
        public string Endpoint { get; set; } = string.Empty;
        public string AccessKey { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
        public string BucketName { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = string.Empty;
    }
}
