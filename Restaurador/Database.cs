using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurador
{
    public class Database
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
                return true;

            Database other = obj as Database;

            if (other == null)
                return false;

            return (this.Id == other.Id);
        }
    }
}
