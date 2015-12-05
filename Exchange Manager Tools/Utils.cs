using System;
using System.IO;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.ServiceProcess;

namespace Exchange_Manager
{
    public class Utils
    {
        private static readonly byte[] CryptKey = new byte[] { 0x26, 0xdc, 0xff, 0x00, 0xad, 0xed, 0x7a, 0xee, 0xc5, 0xfe, 0x07, 0xaf, 0x4d, 0x08, 0x22, 0x3c, 0x26, 0xdc, 0xff, 0x00, 0xad, 0xed, 0x7a, 0xee, 0xc5, 0xfe, 0x07, 0xaf, 0x4d, 0x08, 0x22, 0x3c };
        private static readonly byte[] CryptIV = new byte[] { 0x26, 0xdc, 0xff, 0x00, 0xad, 0xed, 0x7a, 0xee, 0xc5, 0xfe, 0x07, 0xaf, 0x4d, 0x08, 0x22, 0x3c };
        public static String EncryptPassword(String password)
        {
            byte[] encrypted ;
            AesManaged crypter = new AesManaged();
            crypter.Key = CryptKey;
            crypter.IV = CryptIV;
            ICryptoTransform encryptor = crypter.CreateEncryptor(crypter.Key, crypter.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(password);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
            return System.Convert.ToBase64String(encrypted);
        }
        public static String DecryptPassword(String password)
        {
            byte[] encpass = System.Convert.FromBase64String(password);
            String pass;
            AesManaged crypter = new AesManaged();
            crypter.Key = CryptKey;
            crypter.IV = CryptIV;
            ICryptoTransform decryptor = crypter.CreateDecryptor(crypter.Key, crypter.IV);
            using (MemoryStream msDecrypt = new MemoryStream(encpass))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        pass = srDecrypt.ReadToEnd();
                    }
                }
            }
            return pass;
        }
        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
        public static bool WriteReg(string KeyName, object Value)
        {
            try
            {
                RegistryKey rk = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                RegistryKey sk1 = rk.CreateSubKey("SOFTWARE\\Teske Virtual System\\Mail Backup", RegistryKeyPermissionCheck.ReadWriteSubTree);
                sk1.SetValue(KeyName.ToUpper(), Value);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static string ReadReg(string KeyName)
        {
            RegistryKey rk = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey sk1 = rk.OpenSubKey("SOFTWARE\\Teske Virtual System\\Mail Backup");
            if (sk1 == null)
            {
                return null;
            }
            else
            {
                try
                {
                    return (string)sk1.GetValue(KeyName.ToUpper());
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public static void StartService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            service.Start();
        }

        public static void StopService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            service.Stop();
        }

        public enum ServiceStatus
        {
            Stopped,
            Paused,
            Running,
            Starting,
            Pausing,
            Stopping
        }

        public static ServiceStatus GetServiceStatus(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            ServiceControllerStatus status = service.Status;
            switch (service.Status)
            {
                case ServiceControllerStatus.ContinuePending: return ServiceStatus.Starting; 
                case ServiceControllerStatus.Paused: return ServiceStatus.Paused; 
                case ServiceControllerStatus.PausePending: return ServiceStatus.Pausing; 
                case ServiceControllerStatus.Running: return ServiceStatus.Running; 
                case ServiceControllerStatus.StartPending: return ServiceStatus.Starting; 
                case ServiceControllerStatus.Stopped: return ServiceStatus.Stopped; 
                case ServiceControllerStatus.StopPending: return ServiceStatus.Stopping; 
                default: return ServiceStatus.Stopped;
            } 
        }
    }
}
