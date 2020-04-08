using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UTILITARIO
{
    public class FUNCIONES
    {
        public static string EncryptTripleDES(string sIn, string key)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();

            DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(key));
            DES.Mode = CipherMode.ECB;
            ICryptoTransform DESEncrypt = DES.CreateEncryptor();

            Byte[] Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(sIn);
            return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        public static string DecryptTripleDES(string sOut, string key)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();

            DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(key));
            DES.Mode = CipherMode.ECB;
            ICryptoTransform DESDecrypt = DES.CreateDecryptor();

            Byte[] Buffer = Convert.FromBase64String(sOut);
            return System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        public static List<KeyValuePair<string, string>> listarAnios()
        {
            List<KeyValuePair<string, string>> lstAnios = new List<KeyValuePair<string, string>>();
            int intAnioActual = Convert.ToInt32(DateTime.Today.Year);
            for (int i = intAnioActual; i >= 2016; i--)
            {
                string strAnio = Convert.ToString(i);
                lstAnios.Add(new KeyValuePair<string, string>(strAnio, strAnio));
            }
            return lstAnios;
        }

        public static string obtenerMes(int nuMes)
        {
            string resultado = "";
            switch (nuMes)
            {
                case 1: resultado = "Enero"; break;
                case 2: resultado = "Febrero"; break;
                case 3: resultado = "Marzo"; break;
                case 4: resultado = "Abril"; break;
                case 5: resultado = "Mayo"; break;
                case 6: resultado = "Junio"; break;
                case 7: resultado = "Julio"; break;
                case 8: resultado = "Agosto"; break;
                case 9: resultado = "Septiembre"; break;
                case 10: resultado = "Octubre"; break;
                case 11: resultado = "Noviembre"; break;
                case 12: resultado = "Diciembre"; break;
            }
            return resultado;
        }

        public static List<KeyValuePair<string, string>> listarMeses()
        {
            List<KeyValuePair<string, string>> lstMeses = new List<KeyValuePair<string, string>>();
            lstMeses.Add(new KeyValuePair<string, string>("ENERO", "1"));
            lstMeses.Add(new KeyValuePair<string, string>("FEBRERO", "2"));
            lstMeses.Add(new KeyValuePair<string, string>("MARZO", "3"));
            lstMeses.Add(new KeyValuePair<string, string>("ABRIL", "4"));
            lstMeses.Add(new KeyValuePair<string, string>("MAYO", "5"));
            lstMeses.Add(new KeyValuePair<string, string>("JUNIO", "6"));
            lstMeses.Add(new KeyValuePair<string, string>("JULIO", "7"));
            lstMeses.Add(new KeyValuePair<string, string>("AGOSTO", "8"));
            lstMeses.Add(new KeyValuePair<string, string>("SEPTIEMBRE", "9"));
            lstMeses.Add(new KeyValuePair<string, string>("OCTUBRE", "10"));
            lstMeses.Add(new KeyValuePair<string, string>("NOVIEMBRE", "11"));
            lstMeses.Add(new KeyValuePair<string, string>("DICIEMBRE", "12"));
            return lstMeses;
        }

        public static decimal obtenerPorcentaje(int Numero, int Total)
        {
            decimal resultado = 0;

            if (Numero > 0 && Total > 0)
            {
                resultado = Convert.ToDecimal(Numero) * 100 / Convert.ToDecimal(Total);
            }

            return Math.Round(resultado, 2);
        }

        public static string FirstCharToUpper(string s)
        {
            // Check for empty string.  
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.  
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string GetStringMiles2Decimal(decimal number)
        {
            return number.ToString("###,###,###0.00", CultureInfo.InvariantCulture);
        }
    }
}
