using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entities.Models;
using Entities.Utils.Storage;

namespace Entities.Controllers
{
    public class MainScene : MonoBehaviour
    {
        private Button GetDataButton, SaveDataButton, DeleteDataButton, UpdateDataButton, LoadCSVData, SaveCSVData, SaveNewRowCSVData, ResetCSVData;
        private UserModel user;
        
        void Awake()
        {
            user = new UserModel();

            GetDataButton = GameObject.Find("GetDataButton").GetComponent<Button>();
            SaveDataButton = GameObject.Find("SaveDataButton").GetComponent<Button>();
            DeleteDataButton = GameObject.Find("DeleteDataButton").GetComponent<Button>();
            UpdateDataButton = GameObject.Find("UpdateDataButton").GetComponent<Button>();
            LoadCSVData = GameObject.Find("LoadCSVData").GetComponent<Button>();
            SaveCSVData = GameObject.Find("SaveCSVData").GetComponent<Button>();
            SaveNewRowCSVData = GameObject.Find("SaveNewRowCSVData").GetComponent<Button>();
            ResetCSVData = GameObject.Find("ResetCSVData").GetComponent<Button>();
        }

        void OnEnable()
        {
            GetDataButton.onClick.AddListener(() => { OnClicked(GameObject.Find("GetDataButton")); });
            SaveDataButton.onClick.AddListener(() => { OnClicked(GameObject.Find("SaveDataButton")); });
            DeleteDataButton.onClick.AddListener(() => { OnClicked(GameObject.Find("DeleteDataButton")); });
            UpdateDataButton.onClick.AddListener(() => { OnClicked(GameObject.Find("UpdateDataButton")); });
            LoadCSVData.onClick.AddListener(() => { OnClicked(GameObject.Find("LoadCSVData")); });
            SaveCSVData.onClick.AddListener(() => { OnClicked(GameObject.Find("SaveCSVData")); });
            SaveNewRowCSVData.onClick.AddListener(() => { OnClicked(GameObject.Find("SaveNewRowCSVData")); });
            ResetCSVData.onClick.AddListener(() => { OnClicked(GameObject.Find("ResetCSVData")); });
        }

        // Use this for initialization
        void Start()
        {
            print("Start Main Scene");
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnClicked (GameObject objectSender)
        {
            switch (objectSender.name)
            {
                case "GetDataButton":
                    GetDataClicked();
                    break;
                case "SaveDataButton":
                    SaveDataClicked();
                    break;
                case "DeleteDataButton":
                    DeleteDataClicked();
                    break;
                case "UpdateDataButton":
                    UpdateDataClicked();
                    break;
                case "LoadCSVData":
                    LoadCSVDataClicked();
                    break;
                case "SaveCSVData":
                    SaveCSVDataClicked();
                    break;
                case "SaveNewRowCSVData":
                    SaveNewRowCSVDataClicked();
                    break;
                case "ResetCSVData":
                    ResetCSVDataClicked();
                    break;
            }
        }

        void GetDataClicked ()
        {
            List<string[]> users = user.GetAll();
            foreach (var user in users)
            {
                print("UserId = " + user[0] + ", FirstName = " + user[1] + ", LastName = " + user[2]);
            }
        }

        void SaveDataClicked()
        {
            user.Insert(new string[] { "FirstName", "LastName", "ProfileImage"}, new string[] {"'User FirstName'", "'User LastName'", "'2'"});
        }

        void DeleteDataClicked()
        {
            user.Delete();
        }

        void UpdateDataClicked()
        {
            user.Update("FirstName = 'Gos', LastName = 'Raider'");
        }

        void LoadCSVDataClicked()
        {
            List<string[]> data = StorageCSV.Load("Base1");
            if (data.Count > 0)
            {
                foreach (var row in data)
                {
                    print("Id = " + row[0] + ", Level = " + row[1] + ", Question = " + row[2]);
                }
            } else
            {
                print("The CSVFile is empty.");
            }
        }

        void SaveCSVDataClicked()
        {
            List<string[]> data = StorageCSV.Load("Base1");
            foreach (var row in data)
            {
                row[2] = "Question 1";
                print("Id = " + row[0] + ", Level = " + row[1] + ", Question = " + row[2]);
            }
            data.Insert(0, new string[]{ "Id", "Level", "Question", "wasCorrected", "Time" });
            StorageCSV.Save("Base1.csv", data);
        }

        void SaveNewRowCSVDataClicked()
        {
            StorageCSV.SaveNewRow("Base1.csv", new string[] { "100", "10", "9", "1", "20:00" });
        }

        void ResetCSVDataClicked()
        {
            StorageCSV.ResetCSV("Base1.csv", new string[] { "Id", "Level", "Question", "wasCorrected", "Time" });
        }
    }
}
