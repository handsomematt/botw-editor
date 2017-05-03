using System;
using System.Collections.Generic;
using System.IO;

namespace BotWWorldViewer.Resource
{
    internal class FramedStream : Stream
    {
        private long framedOffset;
        private long framedSize;

        private Stream baseStream;

        public FramedStream(Stream baseStream, long startPosition, long size)
        {
            this.baseStream = baseStream;
            this.baseStream.Position = startPosition;

            this.framedOffset = startPosition;
            this.framedSize = size;
        }

        public override bool CanRead
        {
            get { return baseStream.CanRead && (baseStream.Position - framedOffset) < framedSize; }
        }

        public override bool CanSeek
        {
            get { return baseStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override long Length
        {
            get { return framedSize; }
        }

        public override long Position
        {
            get
            {
                return baseStream.Position - framedOffset;
            }
            set
            {
                baseStream.Position = value + framedOffset;
            }
        }

        public long GlobalPosition
        {
            get
            {
                return baseStream.Position;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return baseStream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    return baseStream.Seek(offset + framedOffset, SeekOrigin.Begin);
                case SeekOrigin.Current:
                    return baseStream.Seek(offset, SeekOrigin.Current);
                case SeekOrigin.End:
                    return baseStream.Seek(offset + framedOffset + framedSize, SeekOrigin.End);
            }

            return 0;
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}