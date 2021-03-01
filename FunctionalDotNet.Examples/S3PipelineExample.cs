using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;

namespace FunctionalDotNet.Examples
{
    /// ------
    /// Domain
    /// ------
    public class S3Key
    {
        public string Value { get; }
        public S3Key(string value) => Value = value;
    }

    public class S3Object
    {
        public string Content { get; }
        public S3Object(string content) => Content = content;
    }

    /// ------
    /// S3 Wrapper dependency
    /// ------
    public class S3Wrapper
    {
        private const string BucketName = "MyAmazingBucket";
        private readonly IAmazonS3 _s3Client;

        public S3Wrapper(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<IResult<S3Object>> GetS3ObjectAsync(S3Key key)
        {
            try
            {
                using var response = await _s3Client.GetObjectAsync(BucketName, key.Value);
                await using var responseStream = response.ResponseStream;
                using var reader = new StreamReader(responseStream);

                var responseBody = await reader.ReadToEndAsync();
                var result = new S3Object(responseBody);

                return Result.Success(result);
            }
            catch (AmazonS3Exception)
            {
                return Result.Failure<S3Object>($"Specified key does not exist: {key.Value}");
            }
            catch (Exception e)
            {
                var error = $"Error encountered. Message:'{e.Message}' when reading object";
                return Result.Failure<S3Object>(error);
            }
        }

        public async Task<IResult> PutS3ObjectAsync(S3Object obj, S3Key s3Key)
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

    /// ------
    /// Example of creating a pipeline
    /// ------
    public class BusinessLogic
    {
        private readonly S3Wrapper _s3;

        public BusinessLogic(S3Wrapper s3) => _s3 = s3;

        public async Task<IResult> DoSomething()
        {
            // Define the tasks to be done:
            // Get an object from S3, lowercase the contents, upload with a new key
            // Take two inputs, the old key and the new key
            var pipeline = Result
                .LiftAsync<S3Key, S3Object>(_s3.GetS3ObjectAsync)
                .MapAsync(oldFile => new S3Object(oldFile.Content.ToLower()))
                .BindAsync((S3Object newFile, S3Key newKey) => _s3.PutS3ObjectAsync(newFile, newKey));
            
            // Define the old and new keys
            var keyPairs = new[] {"key1", "key2"}
                .Select(k => new { OldKey = new S3Key(k), NewKey = new S3Key(k + "_lower")});

            // Invoke for each pair of keys and then sequence the results
            var results = await keyPairs
                .Select(x => pipeline.ApplyAsync(x.OldKey).ApplyAsync(x.NewKey))
                .SequenceAsync();

            return results;
        }
    }
}
