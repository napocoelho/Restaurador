using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurador
{
    /// <summary>
    /// Sql server instance
    /// </summary>
    [Serializable]
    public class Server 
    {
        private string password;

        public string Host { get; set; }
        public string User { get; set; }

        public string Password 
        { 
            get
            {
                if (password == null)
                    return String.Empty;

                return Helpers.CryptographyHelper.Decode(password, "0secretPass0");
            }
            set
            {
                this.password = Helpers.CryptographyHelper.Code(value, "0secretPass0");
            }
        }


        public Server()
        {
            this.Password = string.Empty;
        }


    }
}
