﻿using GunCatalog.Persistence.DTO;
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

        public async Task SaveData(UserData userData)
        {
            try
            {
                string json = JsonConvert.SerializeObject(userData);
                await File.WriteAllTextAsync(_dataFileName, json);
            }
            catch { }
        }

        public async Task<UserData> LoadData()
        {
            try
            {
                if (File.Exists(_dataFileName))
                {
                    string json = await File.ReadAllTextAsync(_dataFileName);
                    UserData userData = JsonConvert.DeserializeObject<UserData>(json);
                    return userData;
                }
                else
                {
                    return new UserData();
                }
            }
            catch 
            { 
                return new UserData(); 
            }
        }
    }
}
