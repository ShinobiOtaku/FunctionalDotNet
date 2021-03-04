namespace FunctionalDotNet.Examples.S3Example.Domain
{
    public class S3File
    {
        public string Content { get; }
        public S3File(string content) => Content = content;
    }
}