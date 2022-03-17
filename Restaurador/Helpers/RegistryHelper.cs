using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurador.Helpers
{
    public static class RegistryHelper
    {
        public static void Save(Config config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            byte[] binData = SerializerHelper.SerializeBytes<Config>(config);

            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\GData\Restaurador\");
            key.SetValue("Config", binData, Microsoft.Win32.RegistryValueKind.Binary);
        }

        public static Config Load()
        {
            Config config = null;
            Microsoft.Win32.RegistryKey key = null;


            /********************************************************************************************************************************************/
            // Exclui registro antigo:
            Microsoft.Win32.RegistryKey oldKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\GData\DbLoader\");

            if (oldKey != null)
            {
                try
                {
                    Microsoft.Win32.Registry.LocalMachine.DeleteSubKeyTree(@"SOFTWARE\GData\DbLoader");
                }
                catch(Exception ex)
                {
                    string teste = ex.Message; // não é pra exibir o erro;;;
                }
            }
            /********************************************************************************************************************************************/


            key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\GData\Restaurador\");

            if (key != null)
            {
                byte[] binData = (byte[])key.GetValue("Config");
                config = SerializerHelper.DeserializeBytes<Config>(binData);
            }

            return config;
        }

        public static Boolean IsAdmin
        {
            get
            {
                try
                {
                    Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\GData\Restaurador\");

                    if (key != null)
                    {
                        return (key.GetValue("IsAdmin").ToString() == "true");
                    }
                }
                catch(Exception ex)
                { }

                return false;
            }
            set
            {
                try
                {
                    Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\GData\Restaurador\");
                    if (key != null)
                    {
                        key.SetValue("IsAdmin", (value ? "true" : "false"), Microsoft.Win32.RegistryValueKind.String);
                    }
                }
                catch(Exception ex)
                { }
            }
        }
    }
}
