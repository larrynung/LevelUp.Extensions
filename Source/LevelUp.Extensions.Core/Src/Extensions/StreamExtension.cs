using System;
using System.IO;
using System.Text;
using System.ComponentModel;

public static class StreamExtension
{
    public static void Write(this Stream targetStream, byte[] buffer)
	{
        var bufferBatchSize = (buffer.Length > 1024) ? 1024 : buffer.Length;
        Write(targetStream, buffer, bufferBatchSize);
	}

    public static void Write(this Stream targetStream, byte[] buffer, int bufferBatchSize)
	{
        Write(targetStream,buffer,bufferBatchSize,null);
	}

	public static void Write(this Stream targetStream, byte[] buffer, int bufferBatchSize, Action<object, System.ComponentModel.ProgressChangedEventArgs> progressChangedCallBack)
	{
		if (buffer == null)
			throw new ArgumentNullException("buffer");

		if (!targetStream.CanWrite)
			throw new ArgumentException("Unwritable stream", "targetStream");

		if (bufferBatchSize < 1024)
			throw new ArgumentOutOfRangeException("bufferBatchSize", "Must bigger than 1024");

		if (buffer.Length == 0)
			return;

		int offset = 0;
		int remain = buffer.Length;

		while (remain > 0)
		{
			int readByteCount = remain > bufferBatchSize ? bufferBatchSize : remain;
			targetStream.Write(buffer, offset, readByteCount);

			offset += readByteCount;
			remain -= readByteCount;

			if (progressChangedCallBack != null)
			{
				var currentPercent = (int)(((double)offset) / buffer.Length * 100);

				int percent = currentPercent;
				progressChangedCallBack(targetStream, new ProgressChangedEventArgs(percent, readByteCount));
			}
		}
	}


	public static void Write(this Stream targetStream, string message, Encoding encoder)
	{
        Write(targetStream, encoder.GetBytes(message));
	}

    public static void Write(this Stream targetStream, string sourceFile)
	{
		Write(targetStream,sourceFile,1024);
	}

    public static void Write(this Stream targetStream, string sourceFile, int bufferSize)
	{
		Write(targetStream,sourceFile,bufferSize,null);
	}


	public static void Write(this Stream targetStream, string sourceFile, int bufferSize, Action<object, System.ComponentModel.ProgressChangedEventArgs> progressChangedCallBack)
	{
		using (var fs = File.Open(sourceFile, FileMode.Open))
		{
			targetStream.Write(fs, bufferSize, progressChangedCallBack);
		}
	}

    public static void Write(this Stream targetStream, Stream sourceStream)
	{
        Write(targetStream,sourceStream,1024);
	}

    public static void Write(this Stream targetStream, Stream sourceStream, int bufferSize)
	{
        Write(targetStream,sourceStream,bufferSize, null);
	}

	public static void Write(this Stream targetStream, Stream sourceStream, int bufferSize, Action<object, System.ComponentModel.ProgressChangedEventArgs> progressChangedCallBack)
	{
		if (sourceStream == null)
			throw new ArgumentNullException("sourceStream");

		if (!sourceStream.CanRead)
			throw new ArgumentException("Unreadable stream", "sourceStream");

		if (!targetStream.CanWrite)
			throw new ArgumentException("Unwritable stream", "targetStream");

		if (bufferSize < 1024)
			throw new ArgumentOutOfRangeException("bufferSize", "Must bigger than 1024");

		var buffer = new byte[bufferSize];

		int offset = 0;
		int readByteCount = 0;
		int percent = 0;

		long length = (sourceStream.CanSeek) ? sourceStream.Length : 0;

		while ((readByteCount = sourceStream.Read(buffer, 0, bufferSize)) > 0)
		{
			targetStream.Write(buffer, 0, readByteCount);

			if (progressChangedCallBack != null)
			{
				offset += readByteCount;

				if (length > 0)
				{
					var currentPercent = (int)(((double)offset) / length * 100);
					//if (currentPercent == percent)
					//    continue;
					percent = currentPercent;
				}				
				progressChangedCallBack(targetStream, new ProgressChangedEventArgs(percent, readByteCount));
			}
		}
	}

    public static void WriteTo(this Stream sourceStream, string targetFile)
	{
		WriteTo(sourceStream, targetFile, 1024);
	}


    public static void WriteTo(this Stream sourceStream, string targetFile, int bufferSize)
	{
		WriteTo(sourceStream, targetFile, bufferSize, null);
	}

	public static void WriteTo(this Stream sourceStream, string targetFile, int bufferSize, Action<object, System.ComponentModel.ProgressChangedEventArgs> progressChangedCallBack)
	{
		using (var fs = new FileStream(targetFile, FileMode.Create))
		{
			fs.Write(sourceStream, bufferSize, progressChangedCallBack);
		}
	}

    public static void WriteTo(this Stream sourceStream, Stream targetStream)
    {
        WriteTo(sourceStream, targetStream, 1024);
    }


    public static void WriteTo(this Stream sourceStream, Stream targetStream, int bufferSize)
	{
        WriteTo(sourceStream, targetStream, bufferSize, null);
	}

	public static void WriteTo(this Stream sourceStream, Stream targetStream, int bufferSize, Action<object, System.ComponentModel.ProgressChangedEventArgs> progressChangedCallBack)
	{
        WriteTo(sourceStream, targetStream, bufferSize, progressChangedCallBack);
	}
}