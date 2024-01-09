using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCatalog.Persistence.DTO
{
    public class UserData
    {
        public byte[]? ProfilePicture { get; set; }

        public List<Gun> Guns { get; set; }

        public UserData()
        {
            Guns = new List<Gun>();
        }
    }
}
