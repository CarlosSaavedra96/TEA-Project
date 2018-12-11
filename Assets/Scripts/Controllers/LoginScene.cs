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
            UserNameTextInput.text = PlayerPrefs.GetString("user");
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

                UnityEngine.XR.XRSettings.enabled = true;
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
            var user_field = user.getUserByUserName(UserNameTextInput.text);

            if (user_field.Count == 0)
            {
                print("Not exists a user with this username.");
                Alert_txt.text = "No existe el usuario " + UserNameTextInput.text;
                Alert.SetActive(true);

            }
            else
            {
                print("User data exported");
                user_field.Insert(0, new string[] { "user_id", "user_name", "first_name", "last_name", "image" });
                StorageCSV.Save("user_data_" + UserNameTextInput.text + ".csv", user_field);
                Alert_txt.text = "Se exporta la información del usuario " + UserNameTextInput.text + " correctamente";
                Alert.SetActive(true);
            }
        }

        private void OnLoadSceneCallback(Scene arg0, LoadSceneMode arg1)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(arg0.name));
        }
    }
}
