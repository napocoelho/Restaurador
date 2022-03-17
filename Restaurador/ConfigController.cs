using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

using System.Security.Permissions;
using System.Security.Principal;

using System.Data;
using System.Data.SqlClient;


namespace Restaurador
{   

    public class ConfigController : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private Config config;

        private Config Config 
        { 
            get
            {
                return this.config;
            }
            set
            {
                if (this.config != value)
                {
                    OnPropertyChanging("Config");
                    this.config = value;
                    OnPropertyChanged("Config");
                }
            }
        }
        
        public string Host
        {
            get
            {
                return Config.Server.Host;
            }
            set
            {
                if (Config.Server.Host != value)
                {
                    OnPropertyChanging("Host");
                    Config.Server.Host = value;
                    OnPropertyChanged("Host");
                }
            }
        }

        public string User
        {
            get
            {
                return Config.Server.User;
            }
            set
            {
                if (Config.Server.User != value)
                {
                    OnPropertyChanging("User");
                    Config.Server.User = value;
                    OnPropertyChanged("User");
                }
            }
        }

        public string Password
        {
            get
            {
                return Config.Server.Password;
            }
            set
            {
                if (Config.Server.Password != value)
                {
                    OnPropertyChanging("Password");
                    Config.Server.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public bool IsInstalled 
        { 
            get
            {
                return Config.IsInstalled;
            }
            set
            {
                if (Config.IsInstalled != value)
                {
                    OnPropertyChanging("IsInstalled");
                    Config.IsInstalled = value;
                    OnPropertyChanged("IsInstalled");
                }
            }
        }

        public string InitialDirectory
        {
            get
            {
                return Config.InitialDirectory;
            }
            set
            {
                if (Config.InitialDirectory != value)
                {
                    OnPropertyChanging("InitialDirectory");
                    Config.InitialDirectory = value;
                    OnPropertyChanged("InitialDirectory");
                }
            }
        }

        public ConfigController()
        {
            this.Config = Helpers.RegistryHelper.Load();
            
            if(this.Config == null)
            {
                this.Config = new Config();
                this.Config.Server = new Server();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }


        public void TryConnection()
        {
            string connectionString = "Initial Catalog=master;Data Source=" + this.Host + ";User ID=" + this.User + ";Password=" + this.Password + ";Connect Timeout=0;Application Name='Restaurador'";

            using( SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT 'OK' OK", connection);
                String test = command.ExecuteScalar().ToString();
            }
        }

        public void Save()
        {
            Helpers.RegistryHelper.Save(this.Config);
        }

        public void Install()
        {
            Microsoft.Win32.RegistryKey key = null;

            ////// Cria registro base do Restaurador
            key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Classes", true);
            key = key.CreateSubKey("Restaurador");
            key.SetValue("", "Sql Server Backup Restorer");

            ////// Cria um diretório de instalação para Restaurador e copia pra lá
            string installPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonProgramFiles);
            installPath += "\\Restaurador";
            System.IO.DirectoryInfo installDir = System.IO.Directory.CreateDirectory(installPath);

            ////// Registra o caminho da instalação de Restaurador no Registry
            string exePath = System.IO.Directory.GetCurrentDirectory() + "\\Restaurador.exe";
            System.IO.File.Copy(exePath, installPath + "\\Restaurador.exe", true);
            key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Classes", true);
            key = key.CreateSubKey("Restaurador\\shell\\Open\\Command");
            key.SetValue("", "\"" + installPath + "\\Restaurador.exe\" \"%1\"");

            ////// Cria registro da extensão .bak e liga ao registro Restaurador:
            key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Classes", true);
            key = key.CreateSubKey(".bak");
            key.SetValue("", "Restaurador");

            this.IsInstalled = true;
            this.Save();
        }

        public void Uninstall()
        {
            Microsoft.Win32.RegistryKey key = null;

            string installPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonProgramFiles);
            installPath += "\\Restaurador";

            if(System.IO.Directory.Exists(installPath ))
            {
                System.IO.Directory.Delete(installPath, true);
            }

            key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Classes", true);

            if (Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Classes\Restaurador") != null)
            {
                key.DeleteSubKeyTree("Restaurador");
            }

            if (Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Classes\.bak") != null)
            {
                key.DeleteSubKeyTree(".bak");
            }

            this.IsInstalled = false;
            this.Save();
        }
    }
}