using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Restaurador
{
    [Serializable]
    public class Config
    {
        public Server Server { get; set; }
        //public ObservableCollection<Database> Databases { get; set; }
        public bool IsInstalled { get; set; }
        public string InitialDirectory { get; set; }
        public bool IsAdmin { get; set; }

        public Config()
        {
            this.Server = null;
        }
    }
}
