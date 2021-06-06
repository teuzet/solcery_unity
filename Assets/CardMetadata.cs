using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grimmz
{
    public struct CardMetadata
    {
        int Picture;
        string Name;
        string Description;

        public CardMetadata(bool ignored)
        {
            Picture = 1;
            Name = "Card";
            Description = "Description";
        }

        public void SerializeToBytes(ref List<byte> buffer)
        {
            var nameLength = Name.Length;
            var descriptionLength = Description.Length;
            List<byte> tmpBuffer = new List<byte>();
            tmpBuffer.AddRange(BitConverter.GetBytes(Picture).ToList<byte>());
            tmpBuffer.AddRange(BitConverter.GetBytes(nameLength).ToList<byte>());
            tmpBuffer.AddRange(Encoding.UTF8.GetBytes(Name).ToList<byte>());
            tmpBuffer.AddRange(BitConverter.GetBytes(descriptionLength).ToList<byte>());
            tmpBuffer.AddRange(Encoding.UTF8.GetBytes(Description).ToList<byte>());
            buffer.AddRange(tmpBuffer);
        }
    }
}
