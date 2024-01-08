using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCatalog.Persistence
{
    public interface IGunCatalogPersistence
    {
        Task SaveData(List<GunData> guns);
        Task<List<GunData>> LoadData();

        Task SaveCatalogStateAsync(GunCatalogState state);
        Task<GunCatalogState?> LoadCatalogStateAsync();
    }
}
