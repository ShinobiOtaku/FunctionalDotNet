S3 Example - Advanced usage

## Intro

This is a more advanced scenario where we're chaining functions together, creating new functions.

## Domain

We have a strongly typed domain, this prevents bugs where we have a defintion that takes two strings:

```csharp
public interface IS3
{
	Task<IResult> PutS3FileAsync(string obj, string s3Key);
}
```

but we get mixed up and call it the other way around:


```csharp
	var mySerializedObject = "{ Hello: "World" }"
	var myKey = "item1";

	_s3.PutS3FileAsync(myKey, mySerializedObject); //This compiles, but we have a bug.
```

we fix this using types:
```csharp
public interface IS3
{
	Task<IResult> PutS3FileAsync(S3File obj, S3Key s3Key);
}
```
and now we cannot get it wrong:

```csharp
	var mySerializedObject = new S3File("{ Hello: "World" }");
	var myKey = new S3Key("item1");

	_s3.PutS3ObjectAsync(myKey, mySerializedObject); //This doesn't compile, the compiler prevented the bug.
```

## S3 Wrapper

AWS already provides an SDK for talking to S3. However, it doesn't understand results and it throws exceptions, therefore we write a wrapper/adapter on our gateway layer to help us out.