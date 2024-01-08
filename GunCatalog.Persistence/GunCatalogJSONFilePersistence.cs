using GunCatalog.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCatalog.Persistence
{
    public class GunCatalogJSONFilePersistence : IGunCatalogPersistence
    {

        private string _dataFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.json");
        private string _stateFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "state.dat");

        public async Task SaveCatalogStateAsync(GunCatalogState state)
        {
            try
            {
                string json = JsonConvert.SerializeObject(state);
                await File.WriteAllTextAsync(_stateFileName, json);
            }
            catch { }
        }

        public async Task<GunCatalogState?> LoadCatalogStateAsync()
        {
            try
            {
                GunCatalogState? state = null;
                if (File.Exists(_stateFileName))
                {
                    string json = await File.ReadAllTextAsync(_stateFileName);
                    state = JsonConvert.DeserializeObject<GunCatalogState>(json);
                }
                return state;
            }
            catch
            {
                return null;
            }
        }

        public async Task SaveData(List<GunData> guns)
        {
            try
            {
                string json = JsonConvert.SerializeObject(guns);
                await File.WriteAllTextAsync(_dataFileName, json);
            }
            catch { }
        }

        public async Task<List<GunData>> LoadData()
        {
            try
            {
                if (File.Exists(_dataFileName))
                {
                    string json = await File.ReadAllTextAsync(_dataFileName);
                    List<GunData> guns = JsonConvert.DeserializeObject<List<GunData>>(json);
                    return guns;
                }
                else
                {
                    return new List<GunData>();
                }
            }
            catch 
            { 
                return new List<GunData>(); 
            }
        }
    }
}
