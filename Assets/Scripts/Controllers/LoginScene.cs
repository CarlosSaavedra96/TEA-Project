using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;
using UnityEngine.UI;
using Entities.Models;
using UnityEngine.SceneManagement;
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

            SceneManager.sceneLoaded += OnLoadSceneCallback;

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
            var user_field = user.getUserByUserName(UserNameTextInput.text);
            if (user_field.Count == 0)
            {
                print("Not exists a user with this username.");
            } else
            {
                print("Start log in");
                print(user_field[0][1]);
            }
        }

        void NewUserButtonClicked()
        {
            SceneManager.LoadScene("UserRegisterScene", LoadSceneMode.Additive);
        }

        void ExportUserButtonClicked()
        {

        }

        private void OnLoadSceneCallback(Scene arg0, LoadSceneMode arg1)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(arg0.name));
        }
    }
}
