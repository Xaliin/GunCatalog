using GunCatalog.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCatalog.Model
{
    public class GunCatalogModel
    {

        private GunCatalogJSONFilePersistence? _persistence;

        public GunCatalogModel(GunCatalogJSONFilePersistence? persistence) 
        { 
            _persistence = persistence;


        }
    }
}
