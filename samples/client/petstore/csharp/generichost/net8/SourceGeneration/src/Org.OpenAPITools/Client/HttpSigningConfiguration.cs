// <auto-generated>
/*
 * OpenAPI Petstore
 *
 * This spec is mainly for testing Petstore server and contains fake endpoints, models. Please do not use this for any other purpose. Special characters: \" \\
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Org.OpenAPITools.Client
{
    /// <summary>
    /// Class for HttpSigning auth related parameter and methods
    /// </summary>
    public class HttpSigningConfiguration
    {
        /// <summary>
        /// Create an instance
        /// </summary>
        public HttpSigningConfiguration(string keyId, string keyFilePath, SecureString? keyPassPhrase, List<string> httpSigningHeader, HashAlgorithmName hashAlgorithm, string signingAlgorithm, int signatureValidityPeriod)
        {
            KeyId = keyId;
            KeyFilePath = keyFilePath;
            KeyPassPhrase = keyPassPhrase;
            HttpSigningHeader = httpSigningHeader;
            HashAlgorithm = hashAlgorithm;
            SigningAlgorithm = signingAlgorithm;
            SignatureValidityPeriod = signatureValidityPeriod;
        }

        /// <summary>
        ///Gets the Api keyId
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        /// Gets the Key file path
        /// </summary>
        public string KeyFilePath { get; set; }

        /// <summary>
        /// Gets the key pass phrase for password protected key
        /// </summary>
        public SecureString? KeyPassPhrase { get; set; }

        /// <summary>
        /// Gets the HTTP signing header
        /// </summary>
        public List<string> HttpSigningHeader { get; set; }

        /// <summary>
        /// Gets the hash algorithm sha256 or sha512
        /// </summary>
        public HashAlgorithmName HashAlgorithm { get; set; } = HashAlgorithmName.SHA256;

        /// <summary>
        /// Gets the signing algorithm
        /// </summary>
        public string SigningAlgorithm { get; set; }

        /// <summary>
        /// Gets the Signature validaty period in seconds
        /// </summary>
        public int SignatureValidityPeriod { get; set; }

        private enum PrivateKeyType
        {
            None = 0,
            RSA = 1,
            ECDSA = 2,
        }

        /// <summary>
        /// Gets the Headers for HttpSigning
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestBody"></param>
        /// <param name="cancellationToken"></param>
        internal Dictionary<string, string> GetHttpSignedHeader(global::System.Net.Http.HttpRequestMessage request, string requestBody, System.Threading.CancellationToken cancellationToken = default)
        {
            if (request.RequestUri == null)
                throw new NullReferenceException("The request URI was null");

            const string HEADER_REQUEST_TARGET = "(request-target)";

            // The time when the HTTP signature expires. The API server should reject HTTP requests that have expired.
            const string HEADER_EXPIRES = "(expires)";

            //The 'Date' header.
            const string HEADER_DATE = "Date";

            //The 'Host' header.
            const string HEADER_HOST = "Host";
            
            //The time when the HTTP signature was generated.
            const string HEADER_CREATED = "(created)";
            
            //When the 'Digest' header is included in the HTTP signature, the client automatically
            //computes the digest of the HTTP request body, per RFC 3230.
            const string HEADER_DIGEST = "Digest";
            
            //The 'Authorization' header is automatically generated by the client. It includes
            //the list of signed headers and a base64-encoded signature.
            const string HEADER_AUTHORIZATION = "Authorization";

            //Hash table to store singed headers
            var HttpSignedRequestHeader = new Dictionary<string, string>();
            
            var httpSignatureHeader = new Dictionary<string, string?>();

            if (HttpSigningHeader.Count == 0)
                HttpSigningHeader.Add("(created)");

            var dateTime = DateTime.Now;
            string digest = String.Empty;

            if (HashAlgorithm == HashAlgorithmName.SHA256)
            {
                var bodyDigest = GetStringHash(HashAlgorithm, requestBody);
                digest = string.Format("SHA-256={0}", Convert.ToBase64String(bodyDigest));
            }
            else if (HashAlgorithm == HashAlgorithmName.SHA512)
            {
                var bodyDigest = GetStringHash(HashAlgorithm, requestBody);
                digest = string.Format("SHA-512={0}", Convert.ToBase64String(bodyDigest));
            }
            else
                throw new Exception(string.Format("{0} not supported", HashAlgorithm));

            foreach (var header in HttpSigningHeader)
                if (header.Equals(HEADER_REQUEST_TARGET))
                    httpSignatureHeader.Add(header.ToLower(), request.RequestUri.ToString());
                else if (header.Equals(HEADER_EXPIRES))
                {
                    var expireDateTime = dateTime.AddSeconds(SignatureValidityPeriod);
                    httpSignatureHeader.Add(header.ToLower(), GetUnixTime(expireDateTime).ToString());
                }
                else if (header.Equals(HEADER_DATE))
                {
                    var utcDateTime = dateTime.ToString("r").ToString();
                    httpSignatureHeader.Add(header.ToLower(), utcDateTime);
                    HttpSignedRequestHeader.Add(HEADER_DATE, utcDateTime);
                }
                else if (header.Equals(HEADER_HOST))
                {
                    httpSignatureHeader.Add(header.ToLower(), request.RequestUri.ToString());
                    HttpSignedRequestHeader.Add(HEADER_HOST, request.RequestUri.ToString());
                }
                else if (header.Equals(HEADER_CREATED))
                    httpSignatureHeader.Add(header.ToLower(), GetUnixTime(dateTime).ToString());
                else if (header.Equals(HEADER_DIGEST))
                {
                    HttpSignedRequestHeader.Add(HEADER_DIGEST, digest);
                    httpSignatureHeader.Add(header.ToLower(), digest);
                }
                else
                {
                    bool isHeaderFound = false;
                    foreach (var item in request.Headers)
                    {
                        if (string.Equals(item.Key, header, StringComparison.OrdinalIgnoreCase))
                        {
                            httpSignatureHeader.Add(header.ToLower(), item.Value.ToString());
                            isHeaderFound = true;
                            break;
                        }
                    }

                    if (!isHeaderFound)
                        throw new Exception(string.Format("Cannot sign HTTP request.Request does not contain the {0} header.",header));
                }

            var headersKeysString = String.Join(" ", httpSignatureHeader.Keys);
            var headerValuesList = new List<string>();

            foreach (var keyVal in httpSignatureHeader)
                headerValuesList.Add(string.Format("{0}: {1}", keyVal.Key, keyVal.Value));

            //Concatenate headers value separated by new line
            var headerValuesString = string.Join("\n", headerValuesList);
            var signatureStringHash = GetStringHash(HashAlgorithm, headerValuesString);
            string? headerSignatureStr = null;
            var keyType = GetKeyType(KeyFilePath);

            if (keyType == PrivateKeyType.RSA)
                headerSignatureStr = GetRSASignature(signatureStringHash);
            
            else if (keyType == PrivateKeyType.ECDSA)
                headerSignatureStr = GetECDSASignature(signatureStringHash);
            
            var cryptographicScheme = "hs2019";
            var authorizationHeaderValue = string.Format("Signature keyId=\"{0}\",algorithm=\"{1}\"",
                KeyId, cryptographicScheme);

            if (httpSignatureHeader.ContainsKey(HEADER_CREATED))
                authorizationHeaderValue += string.Format(",created={0}", httpSignatureHeader[HEADER_CREATED]);

            if (httpSignatureHeader.ContainsKey(HEADER_EXPIRES))
                authorizationHeaderValue += string.Format(",expires={0}", httpSignatureHeader[HEADER_EXPIRES]);

            authorizationHeaderValue += string.Format(",headers=\"{0}\",signature=\"{1}\"", headersKeysString, headerSignatureStr);

            HttpSignedRequestHeader.Add(HEADER_AUTHORIZATION, authorizationHeaderValue);

            return HttpSignedRequestHeader;
        }

        private byte[] GetStringHash(HashAlgorithmName hashAlgorithmName, string stringToBeHashed)
        {
            HashAlgorithm? hashAlgorithm = null;

            if (hashAlgorithmName == HashAlgorithmName.SHA1)
                hashAlgorithm = SHA1.Create();

            if (hashAlgorithmName == HashAlgorithmName.SHA256)
                hashAlgorithm = SHA256.Create();

            if (hashAlgorithmName == HashAlgorithmName.SHA512)
                hashAlgorithm = SHA512.Create();

            if (hashAlgorithmName == HashAlgorithmName.MD5)
                hashAlgorithm = MD5.Create();

            if (hashAlgorithm == null)
                throw new NullReferenceException($"{ nameof(hashAlgorithm) } was null.");

            byte[] bytes = Encoding.UTF8.GetBytes(stringToBeHashed);
            byte[] stringHash = hashAlgorithm.ComputeHash(bytes);
            return stringHash;
        }

        private int GetUnixTime(DateTime date2)
        {
            DateTime date1 = new DateTime(1970, 01, 01);
            TimeSpan timeSpan = date2 - date1;
            return (int)timeSpan.TotalSeconds;
        }

        private string GetRSASignature(byte[] stringToSign)
        {
            if (KeyPassPhrase == null)
                throw new NullReferenceException($"{ nameof(KeyPassPhrase) } was null.");

            RSA? rsa = GetRSAProviderFromPemFile(KeyFilePath, KeyPassPhrase);
            
            if (rsa == null)
                return string.Empty;
            else if (SigningAlgorithm == "RSASSA-PSS")
            {
                var signedbytes = rsa.SignHash(stringToSign, HashAlgorithm, RSASignaturePadding.Pss);
                return Convert.ToBase64String(signedbytes);
            }
            else if (SigningAlgorithm == "PKCS1-v15")
            {
                var signedbytes = rsa.SignHash(stringToSign, HashAlgorithm, RSASignaturePadding.Pkcs1);
                return Convert.ToBase64String(signedbytes);
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the ECDSA signature
        /// </summary>
        /// <param name="dataToSign"></param>
        /// <returns></returns>
        private string GetECDSASignature(byte[] dataToSign)
        {
            if (!File.Exists(KeyFilePath))
                throw new Exception("key file path does not exist.");

            var ecKeyHeader = "-----BEGIN EC PRIVATE KEY-----";
            var ecKeyFooter = "-----END EC PRIVATE KEY-----";
            var keyStr = File.ReadAllText(KeyFilePath);
            var ecKeyBase64String = keyStr.Replace(ecKeyHeader, "").Replace(ecKeyFooter, "").Trim();
            var keyBytes = System.Convert.FromBase64String(ecKeyBase64String);
            var ecdsa = ECDsa.Create();

            var byteCount = 0;
            if (KeyPassPhrase != null)
            {
                IntPtr unmanagedString = IntPtr.Zero;
                try
                {
                    // convert secure string to byte array
                    unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(KeyPassPhrase);

                    string ptrToStringUni = Marshal.PtrToStringUni(unmanagedString) ?? throw new NullReferenceException();

                    ecdsa.ImportEncryptedPkcs8PrivateKey(Encoding.UTF8.GetBytes(ptrToStringUni), keyBytes, out byteCount);
                }
                finally
                {
                    if (unmanagedString != IntPtr.Zero)
                        Marshal.ZeroFreeBSTR(unmanagedString);
                }
            }
            else
                ecdsa.ImportPkcs8PrivateKey(keyBytes, out byteCount);

            var signedBytes = ecdsa.SignHash(dataToSign);
            var derBytes = ConvertToECDSAANS1Format(signedBytes);
            var signedString = System.Convert.ToBase64String(derBytes);

            return signedString;
        }

        private  byte[] ConvertToECDSAANS1Format(byte[] signedBytes)
        {
            var derBytes = new List<byte>();
            byte derLength = 68; //default length for ECDSA code signing bit 0x44
            byte rbytesLength = 32; //R length 0x20
            byte sbytesLength = 32; //S length 0x20
            var rBytes = new List<byte>();
            var sBytes = new List<byte>();
            for (int i = 0; i < 32; i++)
                rBytes.Add(signedBytes[i]);
            
            for (int i = 32; i < 64; i++)
                sBytes.Add(signedBytes[i]);

            if (rBytes[0] > 0x7F)
            {
                derLength++;
                rbytesLength++;
                var tempBytes = new List<byte>();
                tempBytes.AddRange(rBytes);
                rBytes.Clear();
                rBytes.Add(0x00);
                rBytes.AddRange(tempBytes);
            }

            if (sBytes[0] > 0x7F)
            {
                derLength++;
                sbytesLength++;
                var tempBytes = new List<byte>();
                tempBytes.AddRange(sBytes);
                sBytes.Clear();
                sBytes.Add(0x00);
                sBytes.AddRange(tempBytes);

            }

            derBytes.Add(48);  //start of the sequence 0x30
            derBytes.Add(derLength);  //total length r length, type and r bytes

            derBytes.Add(2); //tag for integer
            derBytes.Add(rbytesLength); //length of r
            derBytes.AddRange(rBytes);

            derBytes.Add(2); //tag for integer
            derBytes.Add(sbytesLength); //length of s
            derBytes.AddRange(sBytes);
            return derBytes.ToArray();
        }

        private  RSACryptoServiceProvider? GetRSAProviderFromPemFile(String pemfile, SecureString? keyPassPhrase = null)
        {
            const String pempubheader = "-----BEGIN PUBLIC KEY-----";
            const String pempubfooter = "-----END PUBLIC KEY-----";
            bool isPrivateKeyFile = true;
            byte[]? pemkey = null;

            if (!File.Exists(pemfile))
                throw new Exception("private key file does not exist.");

            string pemstr = File.ReadAllText(pemfile).Trim();

            if (pemstr.StartsWith(pempubheader) && pemstr.EndsWith(pempubfooter))
                isPrivateKeyFile = false;

            if (isPrivateKeyFile)
            {
                pemkey = ConvertPrivateKeyToBytes(pemstr, keyPassPhrase);

                if (pemkey == null)
                    return null;

                return DecodeRSAPrivateKey(pemkey);
            }
            return null;
        }

        private byte[]? ConvertPrivateKeyToBytes(String instr, SecureString? keyPassPhrase = null)
        {
            const String pemprivheader = "-----BEGIN RSA PRIVATE KEY-----";
            const String pemprivfooter = "-----END RSA PRIVATE KEY-----";
            String pemstr = instr.Trim();
            byte[] binkey;

            if (!pemstr.StartsWith(pemprivheader) || !pemstr.EndsWith(pemprivfooter))
                return null;

            StringBuilder sb = new StringBuilder(pemstr);
            sb.Replace(pemprivheader, "");
            sb.Replace(pemprivfooter, "");
            String pvkstr = sb.ToString().Trim();

            try
            {   // if there are no PEM encryption info lines, this is an UNencrypted PEM private key
                binkey = Convert.FromBase64String(pvkstr);
                return binkey;
            }
            catch (global::System.FormatException)
            {
                StringReader str = new StringReader(pvkstr);

                //-------- read PEM encryption info. lines and extract salt -----
                if (!str.ReadLine()!.StartsWith("Proc-Type: 4,ENCRYPTED"))  // TODO: what do we do here if ReadLine is null?
                    return null;
                
                String saltline = str.ReadLine()!;  // TODO: what do we do here if ReadLine is null?
                if (!saltline.StartsWith("DEK-Info: DES-EDE3-CBC,"))
                    return null;
                
                String saltstr = saltline.Substring(saltline.IndexOf(",") + 1).Trim();
                byte[] salt = new byte[saltstr.Length / 2];
                for (int i = 0; i < salt.Length; i++)
                    salt[i] = Convert.ToByte(saltstr.Substring(i * 2, 2), 16);

                if (!(str.ReadLine() == ""))
                    return null;

                //------ remaining b64 data is encrypted RSA key ----
                String encryptedstr = str.ReadToEnd();

                try
                {   //should have b64 encrypted RSA key now
                    binkey = Convert.FromBase64String(encryptedstr);
                }
                catch (global::System.FormatException)
                {   //data is not in base64 format
                    return null;
                }

                // TODO: what do we do here if keyPassPhrase is null?
                byte[] deskey = GetEncryptedKey(salt, keyPassPhrase!, 1, 2);    // count=1 (for OpenSSL implementation); 2 iterations to get at least 24 bytes
                if (deskey == null)
                    return null;

                //------ Decrypt the encrypted 3des-encrypted RSA private key ------
                byte[]? rsakey = DecryptKey(binkey, deskey, salt); //OpenSSL uses salt value in PEM header also as 3DES IV

                return rsakey;
            }
        }

        private RSACryptoServiceProvider? DecodeRSAPrivateKey(byte[] privkey)
        {
            byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;

            // ---------  Set up stream to decode the asn.1 encoded RSA private key  ------
            MemoryStream mem = new MemoryStream(privkey);
            BinaryReader binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading
            byte bt = 0;
            ushort twobytes = 0;
            int elems = 0;
            try
            {
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                    binr.ReadByte();    //advance 1 byte
                else if (twobytes == 0x8230)
                    binr.ReadInt16();   //advance 2 bytes
                else
                    return null;

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102) //version number
                    return null;
                
                bt = binr.ReadByte();
                if (bt != 0x00)
                    return null;
                
                //------  all private key components are Integer sequences ----
                elems = GetIntegerSize(binr);
                MODULUS = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                E = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                D = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                P = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                Q = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                DP = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                DQ = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                IQ = binr.ReadBytes(elems);

                // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSAParameters RSAparams = new RSAParameters();
                RSAparams.Modulus = MODULUS;
                RSAparams.Exponent = E;
                RSAparams.D = D;
                RSAparams.P = P;
                RSAparams.Q = Q;
                RSAparams.DP = DP;
                RSAparams.DQ = DQ;
                RSAparams.InverseQ = IQ;
                RSA.ImportParameters(RSAparams);
                return RSA;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                binr.Close();
            }
        }

        private int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02) //expect integer
                return 0;
            
            bt = binr.ReadByte();

            if (bt == 0x81)
                count = binr.ReadByte();    // data size in next byte
            else if (bt == 0x82)
            {
                highbyte = binr.ReadByte(); // data size in next 2 bytes
                lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
                count = bt;     // we already have the data size
            
            while (binr.ReadByte() == 0x00)
                //remove high order zeros in data
                count -= 1;
            
            binr.BaseStream.Seek(-1, SeekOrigin.Current);

            //last ReadByte wasn't a removed zero, so back up a byte
            return count;
        }

        private byte[] GetEncryptedKey(byte[] salt, SecureString secpswd, int count, int miter)
        {
            IntPtr unmanagedPswd = IntPtr.Zero;
            int HASHLENGTH = 16;    //MD5 bytes
            byte[] keymaterial = new byte[HASHLENGTH * miter];     //to store concatenated Mi hashed results

            byte[] psbytes = new byte[secpswd.Length];
            unmanagedPswd = Marshal.SecureStringToGlobalAllocAnsi(secpswd);
            Marshal.Copy(unmanagedPswd, psbytes, 0, psbytes.Length);
            Marshal.ZeroFreeGlobalAllocAnsi(unmanagedPswd);

            // --- concatenate salt and pswd bytes into fixed data array ---
            byte[] data00 = new byte[psbytes.Length + salt.Length];
            Array.Copy(psbytes, data00, psbytes.Length);      //copy the pswd bytes
            Array.Copy(salt, 0, data00, psbytes.Length, salt.Length); //concatenate the salt bytes

            // ---- do multi-hashing and concatenate results  D1, D2 ...  into keymaterial bytes ----
            MD5 md5 = MD5.Create();
            byte[]? result = null;
            byte[] hashtarget = new byte[HASHLENGTH + data00.Length];   //fixed length initial hashtarget

            for (int j = 0; j < miter; j++)
            {
                // ----  Now hash consecutively for count times ------
                if (j == 0)
                    result = data00;    //initialize
                else
                {
                    Array.Copy(result!, hashtarget, result!.Length); // TODO: what do we do if result is null here?
                    Array.Copy(data00, 0, hashtarget, result.Length, data00.Length);
                    result = hashtarget;
                }

                for (int i = 0; i < count; i++)
                    result = md5.ComputeHash(result);

                Array.Copy(result, 0, keymaterial, j * HASHLENGTH, result.Length);  //concatenate to keymaterial
            }
            byte[] deskey = new byte[24];
            Array.Copy(keymaterial, deskey, deskey.Length);

            Array.Clear(psbytes, 0, psbytes.Length);
            Array.Clear(data00, 0, data00.Length);
            Array.Clear(result!, 0, result!.Length); // TODO: what do we do if result is null here?
            Array.Clear(hashtarget, 0, hashtarget.Length);
            Array.Clear(keymaterial, 0, keymaterial.Length);
            return deskey;
        }

        private byte[]? DecryptKey(byte[] cipherData, byte[] desKey, byte[] IV)
        {
            MemoryStream memst = new MemoryStream();
            TripleDES alg = TripleDES.Create();
            alg.Key = desKey;
            alg.IV = IV;
            try
            {
                CryptoStream cs = new CryptoStream(memst, alg.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(cipherData, 0, cipherData.Length);
                cs.Close();
            }
            catch (Exception)
            {
                return null;
            }
            byte[] decryptedData = memst.ToArray();
            return decryptedData;
        }

        /// <summary>
        /// Detect the key type from the pem file.
        /// </summary>
        /// <param name="keyFilePath">key file path in pem format</param>
        /// <returns></returns>
        private PrivateKeyType GetKeyType(string keyFilePath)
        {
            if (!File.Exists(keyFilePath))
                throw new Exception("Key file path does not exist.");

            var ecPrivateKeyHeader = "BEGIN EC PRIVATE KEY";
            var ecPrivateKeyFooter = "END EC PRIVATE KEY";
            var rsaPrivateKeyHeader = "BEGIN RSA PRIVATE KEY";
            var rsaPrivateFooter = "END RSA PRIVATE KEY";
            //var pkcs8Header = "BEGIN PRIVATE KEY";
            //var pkcs8Footer = "END PRIVATE KEY";
            var keyType = PrivateKeyType.None;
            var key = File.ReadAllLines(keyFilePath);

            if (key[0].ToString().Contains(rsaPrivateKeyHeader) && key[key.Length - 1].ToString().Contains(rsaPrivateFooter))
                keyType = PrivateKeyType.RSA;
            else if (key[0].ToString().Contains(ecPrivateKeyHeader) && key[key.Length - 1].ToString().Contains(ecPrivateKeyFooter))
                keyType = PrivateKeyType.ECDSA;

            else if (key[0].ToString().Contains(ecPrivateKeyHeader) && key[key.Length - 1].ToString().Contains(ecPrivateKeyFooter))
            {
                /* this type of key can hold many type different types of private key, but here due lack of pem header
                Considering this as EC key
                */
                //TODO :- update the key based on oid
                keyType = PrivateKeyType.ECDSA;
            }
            else
                throw new Exception("Either the key is invalid or key is not supported");
            
            return keyType;
        }
    }
}
