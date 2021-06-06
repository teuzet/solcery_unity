using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grimmz
{

    public struct CardMetadata
    {
        public int Picture;
        public string Name;
        public string Description;

        public CardMetadata(bool ignored)
        {
            Picture = 1;
            Name = "Card";
            Description = "Description";
        }

        public CardMetadata(string joinedBuffer) {
            var splitted = joinedBuffer.Split('|');
            List<byte> bytesList = new List<byte>();
            foreach (string s in splitted) {
                bytesList.Add((byte)int.Parse(s));
            }
            var bytes = bytesList.ToArray();
            Picture = BitConverter.ToInt32(bytes, 0);
            int nameLength = BitConverter.ToInt32(bytes, 4);
            Name = System.Text.Encoding.UTF8.GetString(bytes, 8, nameLength);
            int descriptionLength = BitConverter.ToInt32(bytes, 8 + nameLength);
            Description = System.Text.Encoding.UTF8.GetString(bytes, nameLength + 12 , descriptionLength);
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
