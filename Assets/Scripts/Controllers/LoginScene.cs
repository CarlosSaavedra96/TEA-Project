using System.Collections.Generic;
using UnityEngine;
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

        public GameObject Alert;
        public Text Alert_txt;
        public Button Alert_close;
        
        void Awake()
        {
            user = new UserModel();

            SceneManager.sceneLoaded += OnLoadSceneCallback;

            SignInButton = GameObject.Find("SignInButton").GetComponent<Button>();
            NewUserButton = GameObject.Find("NewUserButton").GetComponent<Button>();
            ExportUserButton = GameObject.Find("ExportUserButton").GetComponent<Button>();
            UserNameTextInput = GameObject.Find("UserNameTextInput").GetComponent<InputField>();
            Alert.SetActive(false);
        }

        void OnEnable()
        {
            SignInButton.onClick.AddListener(() => { OnClicked(GameObject.Find("SignInButton")); });
            NewUserButton.onClick.AddListener(() => { OnClicked(GameObject.Find("NewUserButton")); });
            ExportUserButton.onClick.AddListener(() => { OnClicked(GameObject.Find("ExportUserButton")); });
        }

        // Use this for initialization
        public void Start()
        {
            // deshabilita VR
            UnityEngine.XR.XRSettings.enabled = false;
            print("Start Login Scene");
            //  PlayerPrefs.DeleteKey("user");
            if (PlayerPrefs.GetString("user") != "")
            {
                SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
            }
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
                Alert_txt.text = "No existe el usuario " + UserNameTextInput.text;
                Alert.SetActive(true);

            } else
            {
                print("Start log in");
                print(user_field[0][1]);
                PlayerPrefs.SetString("user", user_field[0][1]);
                SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
            }
        }

        public void closeAlert() {
            Alert.SetActive(false);
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
