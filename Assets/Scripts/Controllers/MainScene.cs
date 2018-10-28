using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using Entities.Models;
using Entities.Storage;

namespace Entities.Controllers
{
    public class MainScene : MonoBehaviour
    {
        private Button GetDataButton, SaveDataButton, DeleteDataButton, UpdateDataButton;
        private UserModel user;
        
        void Awake()
        {
            user = new UserModel();

            GetDataButton = GameObject.Find("GetDataButton").GetComponent<Button>();
            SaveDataButton = GameObject.Find("SaveDataButton").GetComponent<Button>();
            DeleteDataButton = GameObject.Find("DeleteDataButton").GetComponent<Button>();
            UpdateDataButton = GameObject.Find("UpdateDataButton").GetComponent<Button>();
        }

        void OnEnable()
        {
            GetDataButton.onClick.AddListener(() => { OnClicked(GameObject.Find("GetDataButton")); });
            SaveDataButton.onClick.AddListener(() => { OnClicked(GameObject.Find("SaveDataButton")); });
            DeleteDataButton.onClick.AddListener(() => { OnClicked(GameObject.Find("DeleteDataButton")); });
            UpdateDataButton.onClick.AddListener(() => { OnClicked(GameObject.Find("UpdateDataButton")); });
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
    }
}
