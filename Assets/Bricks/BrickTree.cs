using System.Text;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Grimmz
{
    public class BrickTree
    {

        public struct CardMetadata {
            int Picture;
            string Name;
            string Description;

            public CardMetadata(bool ignored) {
                Picture = 1;
                Name = "Card";
                Description = "Description"; 
            }

            public void SerializeToBytes(ref List<byte> buffer) {
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

        public BrickData Genesis { get; private set; }
        public CardMetadata MetaData;

        public void SetGenesis(BrickData data)
        {
            Genesis = data;
            MetaData = new CardMetadata(true);
        }

        public void SerializeToBytes(ref List<byte> buffer) {
            List<byte> tmpBuffer = new List<byte>();
            MetaData.SerializeToBytes(ref tmpBuffer);
            buffer.AddRange(BitConverter.GetBytes(tmpBuffer.Count).ToList<byte>());
            buffer.AddRange(tmpBuffer);
            Genesis.SerializeToBytes(ref buffer);
        }
    }
}
