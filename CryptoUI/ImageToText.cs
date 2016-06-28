using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUI
{
    public static class Crypter
    {

        public static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);

        static RSAParameters priv = new RSAParameters();
        static RSAParameters pub = new RSAParameters();

        public static string privString;
        public static string pubString;


        public static void Init()
        {
            priv = rsa.ExportParameters(true);
            pub = rsa.ExportParameters(false);

            privString = MemorySerialize(priv);
            pubString = MemorySerialize(pub);
        }

        public static string Crypt()
        {
            
            return null;
        }

        public static string Encrypt()
        {

            return null;
        }


        private static string MemorySerialize( object key )
        {
            byte[] data;

            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, key);
                data = ms.ToArray();
            }

            return Encoding.Unicode.GetString(data);
        }

    }
}
