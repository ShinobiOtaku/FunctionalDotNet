using System.Linq;
using System.Threading.Tasks;
using FunctionalDotNet.Examples.S3Example.Domain;
using FunctionalDotNet.Examples.S3Example.Gateway;

namespace FunctionalDotNet.Examples.S3Example
{
    public class Program
    {
        private readonly S3Wrapper _s3;

        public Program(S3Wrapper s3) => _s3 = s3;

        public async Task<IResult> DoSomething()
        {
            // Define the tasks to be done:
            // Get an object from S3, lowercase the contents, upload with a new key
            // Take two inputs, the old key and the new key
            var pipeline = Result
                .LiftAsync<S3Key, S3File>(_s3.GetS3FileAsync)
                .MapAsync(oldFile => new S3File(oldFile.Content.ToLower()))
                .BindAsync((S3File newFile, S3Key newKey) => _s3.PutS3FileAsync(newFile, newKey));

            // Define the old and new keys
            var keyPairs = new[] { "key1", "key2" }
                .Select(k => new { OldKey = new S3Key(k), NewKey = new S3Key(k + "_lower") });

            // Invoke for each pair of keys and then sequence the results
            var results = await keyPairs
                .Select(x => pipeline.ApplyAsync(x.OldKey).ApplyAsync(x.NewKey))
                .SequenceAsync();

            return results;
        }
    }
}
