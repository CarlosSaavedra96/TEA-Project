using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Entities.Storage
{
    public class StorageEntity
    {
        private List<UnitField> preferences_list;
        private static StorageEntity instance = null;
        private StorageEntity ()
        {
            this.preferences_list = new List<UnitField>();
        }

        public static StorageEntity NewInstance ()
        {
            if (instance == null)
            {
                instance = new StorageEntity();
            }
            return instance;
        }

        public void AddPlayerPreferences ()
        {

        }

        public void UpdatePlayerPreferences()
        {

        }

        public void RemovePlayerPreferences ()
        {

        }

        public void SavePlayerPreferences ()
        {

        }

        public void SaveProgress ()
        {

        }

        public void LoadPlayerPreferences ()
        {

        }

        public void LoadPlayerPreferencesByIndex()
        {

        }

        public void LoadProgress ()
        {

        }

        public void ResetProgress ()
        {

        }

        public void ResetAll ()
        {

        }
    }
}