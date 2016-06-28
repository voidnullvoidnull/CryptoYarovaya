using System;
using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoUI
{
    public static class TextCrypter
    {
        static int blockLenght = 240;

        public static byte[] StringToBytes(string text, string pub)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportParameters(StringToKey(pub));
                byte[] data = Encoding.Unicode.GetBytes(text);
                return rsa.Encrypt(data, false);
            }
        }

        public static string BytesToString(byte[] data, string priv)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportParameters(StringToKey(priv));
                string text = Encoding.Unicode.GetString(rsa.Decrypt(data, false));
                return text;
            }
        }

        public static KeyValuePair<string, string> GetKeys()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                RSAParameters privateKey = rsa.ExportParameters(true);
                RSAParameters publicKey = rsa.ExportParameters(false);
                var keys = new KeyValuePair<string, string>(KeyToString(privateKey), KeyToString(publicKey));
                return keys;
            }
        }

        private static string KeyToString(RSAParameters key)
        {
            string text = "empty";
            using (MemoryStream fs = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(RSAParameters));
                serializer.Serialize(fs, key);
                text = Encoding.ASCII.GetString(fs.ToArray());
            }
            return text;
        }

        private static RSAParameters StringToKey(string text)
        {
            using (TextReader reader = new StringReader(text))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(RSAParameters));
                return (RSAParameters)serializer.Deserialize(reader);
            }   
        }

        private static List<byte[]> SeparateData(byte[] input)
        {
            int blockCount = 1 + (int)input.Length / blockLenght;
            List<byte[]> output = new List<byte[]>(blockCount);

            for (int i = 0; i < blockCount; i++)
            {
                byte[] block = new byte[blockLenght];
                for (int j = 0; j <blockLenght; j++)
                {
                    if (input.Length < i * j)
                        block[j] = input[i * j];
                    else
                        block[j] = 255;
                }
                output.Add(block);
            }
            return output;
        }

    }

}
