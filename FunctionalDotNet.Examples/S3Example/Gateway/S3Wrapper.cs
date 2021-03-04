using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using FunctionalDotNet.Examples.S3Example.Domain;

namespace FunctionalDotNet.Examples.S3Example.Gateway
{
    public class S3Wrapper
    {
        private const string BucketName = "MyAmazingBucket";
        private readonly IAmazonS3 _s3Client;

        public S3Wrapper(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<IResult<S3File>> GetS3FileAsync(S3Key key)
        {
            try
            {
                using var response = await _s3Client.GetObjectAsync(BucketName, key.Value);
                await using var responseStream = response.ResponseStream;
                using var reader = new StreamReader(responseStream);

                var responseBody = await reader.ReadToEndAsync();
                var result = new S3File(responseBody);

                return Result.Success(result);
            }
            catch (AmazonS3Exception)
            {
                return Result.Failure<S3File>($"Specified key does not exist: {key.Value}");
            }
            catch (Exception e)
            {
                var error = $"Error encountered. Message:'{e.Message}' when reading object";
                return Result.Failure<S3File>(error);
            }
        }

        public async Task<IResult> PutS3FileAsync(S3File obj, S3Key s3Key)
        {
            try
            {
                var putRequest = new PutObjectRequest
                {
                    BucketName = BucketName,
                    Key = s3Key.Value,
                    ContentBody = obj.Content
                };

                await _s3Client.PutObjectAsync(putRequest);

                return Result.Success();
            }
            catch (Exception e)
            {
                var error = $"Error encountered. Message:'{e.Message}' when writing object";
                return Result.Failure(error);
            }
        }
    }
}
