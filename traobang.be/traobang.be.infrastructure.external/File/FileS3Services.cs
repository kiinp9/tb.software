using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using traobang.be.infrastructure.external.File.Dtos;

namespace traobang.be.infrastructure.external.File
{
    public class FileS3Services : IFileS3Services
    {
        private readonly ILogger _logger;
        private readonly IMinioClient _minioClient;
        private readonly FileS3Config _config;

        public FileS3Services(ILogger<FileS3Services> logger, IMinioClient minioClient, IOptions<FileS3Config> config)
        {
            _logger = logger;
            _minioClient = minioClient;
            _config = config.Value;
        }

        public async Task<string?> WriteStreamFileAsync(string? fileName, params Stream[] files)
        {
            _logger.LogInformation($"{nameof(WriteStreamFileAsync)}: fileName = {fileName}");

            if (files != null && files.Count() > 0)
            {
                foreach (var file in files)
                {
                    try
                    {
                        var bucketName = _config.BucketName;
                        var objectName = fileName;

                        try
                        {
                            // Make a bucket on the server, if not already present.
                            var beArgs = new BucketExistsArgs()
                                .WithBucket(bucketName);
                            bool found = await _minioClient.BucketExistsAsync(beArgs).ConfigureAwait(false);
                            if (!found)
                            {
                                var mbArgs = new MakeBucketArgs()
                                    .WithBucket(bucketName);
                                await _minioClient.MakeBucketAsync(mbArgs).ConfigureAwait(false);
                            }

                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                ms.Position = 0;

                                // Upload a file to bucket.
                                var putObjectArgs = new PutObjectArgs()
                                    .WithBucket(bucketName)
                                    .WithObject(objectName)
                                    .WithStreamData(ms)
                                    .WithObjectSize(ms.Length)
                                    .WithContentType("multipart/form-data");
                                await _minioClient.PutObjectAsync(putObjectArgs).ConfigureAwait(false);
                                Console.WriteLine("Successfully uploaded " + objectName);
                            }
                            var fileResult = $"{bucketName}/{objectName}";
                            return fileResult;
                        }
                        catch (MinioException ex)
                        {
                            throw;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return null;
        }
    }
}
