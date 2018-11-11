using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entities.Models;
using Entities.Utils.Storage;

namespace Entities.Controllers
{
    public class LoginScene : MonoBehaviour
    {
        private Button SignInButton, NewUserButton, ExportUserButton;
        private InputField UserNameTextInput;
        private UserModel user;
        
        void Awake()
        {
            user = new UserModel();

            SignInButton = GameObject.Find("SignInButton").GetComponent<Button>();
            NewUserButton = GameObject.Find("NewUserButton").GetComponent<Button>();
            ExportUserButton = GameObject.Find("ExportUserButton").GetComponent<Button>();
            UserNameTextInput = GameObject.Find("UserNameTextInput").GetComponent<InputField>();
        }

        void OnEnable()
        {
            SignInButton.onClick.AddListener(() => { OnClicked(GameObject.Find("SignInButton")); });
            NewUserButton.onClick.AddListener(() => { OnClicked(GameObject.Find("NewUserButton")); });
            ExportUserButton.onClick.AddListener(() => { OnClicked(GameObject.Find("ExportUserButton")); });
        }

        // Use this for initialization
        void Start()
        {
            print("Start Login Scene");
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnClicked (GameObject objectSender)
        {
            switch (objectSender.name)
            {
                case "SignInButton":
                    SignInButtonClicked();
                    break;
                case "NewUserButton":
                    NewUserButtonClicked();
                    break;
                case "ExportUserButton":
                    ExportUserButtonClicked();
                    break;
            }
        }

        void SignInButtonClicked()
        {
            
        }

        void NewUserButtonClicked()
        {

        }

        void ExportUserButtonClicked()
        {

        }
    }
}
