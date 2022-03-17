using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Restaurador
{
    public class BackupFileInfo
    {
        public String Name { get; set; }
        public String FilePath { get; set; }
        public BackupFilePart Data { get; set; }
        public BackupFilePart Log { get; set; }


    }

    public class BackupFilePart
    {
        public string UniqueId { get; set; }
        public string LogicalName { get; set; }
        public string PhysicalName { get; set; }
        public string Type { get; set; }
        public Int64 Size { get; set; }
        public Int64 MaxSize { get; set; }
        public Int64 BackupSizeInBytes { get; set; }

        public override int GetHashCode()
        {
            return this.UniqueId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            BackupFileInfo other = obj as BackupFileInfo;

            if (other == null)
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            if (this.UniqueId.Equals(other))
                return true;

            return false;
        }
    }
}