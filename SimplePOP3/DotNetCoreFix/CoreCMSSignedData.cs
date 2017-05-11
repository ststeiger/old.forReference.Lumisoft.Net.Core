using System;
using System.Collections.Generic;
using System.Text;

using Org.BouncyCastle.Cms;



namespace System.Security.Cryptography.Pkcs
{

    public class CmsSigner
    {

        public CmsSigner(System.Security.Cryptography.X509Certificates.X509Certificate2 cert)
        {

        }

    }

    public class ContentInfo
    {
        public ContentInfo(byte[] bb)
        { }


        // Make Property ?
        public byte[] Content;

    }


    public class EnvelopedCms
    {

        public EnvelopedCms()
        { }


        public byte[] Encode()
        {
            return null;
        }


        public void Decode(byte[] data)
        {

        }


        public void Decrypt(System.Security.Cryptography.X509Certificates
            .X509Certificate2Collection certificates)
        {

        }



    }

    public class SignedCms
    {

        // Make property ?
        public ContentInfo ContentInfo;

        public SignedCms()
        { }

        // SignedCms(new ContentInfo(tmpDataEntityStream.ToArray()),true);
        public SignedCms(ContentInfo ci, bool b)
        {
        }



        // signedCms.ComputeSignature(new CmsSigner(m_pSignerCert));

        // byte[] pkcs7 = signedCms.Encode();
        public byte[] Encode()
        {
            return null;
        }


        public void Decode(byte[] data)
        {

        }

        public void CheckSignature(bool b)
        {

        }

        public void ComputeSignature(CmsSigner signer)
        { }


        public System.Security.Cryptography.X509Certificates.X509Certificate2Collection Certificates
        {
            get
            {
                return null;
            }
        }


    }


    class CoreCMSSignedData
    {

        public static void foo()
        {
            byte[] sigBlock = null;
            Org.BouncyCastle.Cms.CmsSignedData c = new Org.BouncyCastle.Cms.CmsSignedData(sigBlock);

        }

    }
}
