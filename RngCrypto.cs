using System;
using System.Security.Cryptography;

namespace Poker
{
    public class RngCrypto
    {
        private const int BufferSize = 1024;  // must be a multiple of 4
        private readonly byte[] _randomBuffer;
        private int _bufferOffset;
        private readonly RNGCryptoServiceProvider _rng;
        public RngCrypto()
        {
            _randomBuffer = new byte[BufferSize];
            _rng = new RNGCryptoServiceProvider();
            _bufferOffset = _randomBuffer.Length;
        }
        private void FillBuffer()
        {
            _rng.GetBytes(_randomBuffer);
            _bufferOffset = 0;
        }
        public int Next()
        {
            if (_bufferOffset >= _randomBuffer.Length)
            {
                FillBuffer();
            }
            int val = BitConverter.ToInt32(_randomBuffer, _bufferOffset) & 0x7fffffff;
            _bufferOffset += sizeof(int);
            return val;
        }
        public int Next(int maxValue)
        {
            return Next() % maxValue;
        }
        public int Next(int minValue, int maxValue)
        {
            if (maxValue < minValue)
            {
                throw new ArgumentOutOfRangeException(@"maxValue must be greater than or equal to minValue");
            }
            int range = maxValue - minValue;
            return minValue + Next(range);
        }
        public double NextDouble()
        {
            int val = Next();
            return (double)val / int.MaxValue;
        }
        public void GetBytes(byte[] buff)
        {
            _rng.GetBytes(buff);
        }
    }
}
