using System;
using System.Security;
using System.Security.Cryptography;

namespace dCaptcha.Core.Helpers
{
    public class SecureRandom : RandomNumberGenerator
    {
        private readonly RandomNumberGenerator _generator;

        public SecureRandom()
        {
            _generator = new RNGCryptoServiceProvider();
        }

        public int Next()
        {
            var data = new byte[sizeof(int)];
            _generator.GetBytes(data);
            return BitConverter.ToInt32(data, 0) & (int.MaxValue - 1);
        }

        public SecureString String(int len, string charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890")
        {
            var sb = new SecureString();
            var letter = "";
            while (sb.Length != len)
            {
                while (letter == "" || !charset.Contains(letter))
                {
                    if (sb.Length == len)
                    {
                        sb.MakeReadOnly();
                        return sb;
                    }
                    var oneByte = new byte[1];
                    _generator.GetBytes(oneByte);
                    var c = (char)oneByte[0];
                    if (char.IsDigit(c) || char.IsLetter(c))
                        letter = c.ToString();
                }
                sb.AppendChar(letter[0]);
                letter = "";
            }
            sb.MakeReadOnly();
            return sb;
        }

        public int Next(int maxValue)
        {
            return Next(0, maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)    
                throw new ArgumentOutOfRangeException();      

            return (int)Math.Floor((minValue + ((double)maxValue - minValue) * NextDouble()));
        }

        public double NextDouble()
        {
            var data = new byte[sizeof(uint)];
            _generator.GetBytes(data);
            var randUint = BitConverter.ToUInt32(data, 0);
            return randUint / (uint.MaxValue + 1.0);
        }

        public double NextDouble(double minimum, double maximum)
        {
            return NextDouble() * (maximum - minimum) + minimum;
        }

        public override void GetBytes(byte[] data)
        {
            _generator.GetBytes(data);
        }

        public override void GetNonZeroBytes(byte[] data)
        {
            _generator.GetNonZeroBytes(data);
        }
    }
}