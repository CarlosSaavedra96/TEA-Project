using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entities.Models;
using UnityEngine.SceneManagement;
using Entities.Utils.Storage;

namespace Entities.Controllers
{
    public class UserRegisterScene : MonoBehaviour
    {
        private Button RegisterButton, ReturnButton;
        private InputField UserNameRTextInput, FirstNameTextInput, LastNameTextInput;
        private UserModel user;
        
        void Awake()
        {
            user = new UserModel();

            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;

            RegisterButton = GameObject.Find("RegisterButton").GetComponent<Button>();
            ReturnButton = GameObject.Find("ReturnButton").GetComponent<Button>();
            UserNameRTextInput = GameObject.Find("UserNameRTextInput").GetComponent<InputField>();
            FirstNameTextInput = GameObject.Find("FirstNameTextInput").GetComponent<InputField>();
            LastNameTextInput = GameObject.Find("LastNameTextInput").GetComponent<InputField>();
        }

        void OnEnable()
        {
            RegisterButton.onClick.AddListener(() => { OnClicked(GameObject.Find("RegisterButton")); });
            ReturnButton.onClick.AddListener(() => { OnClicked(GameObject.Find("ReturnButton")); });
        }

        // Use this for initialization
        void Start()
        {
            print("Start User Register Scene");
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnClicked (GameObject objectSender)
        {
            switch (objectSender.name)
            {
                case "RegisterButton":
                    RegisterButtonClicked();
                    break;
                case "ReturnButton":
                    ReturnButtonClicked();
                    break;
            }
        }

        void RegisterButtonClicked()
        {
            user.Insert(new string[] {
                "user_name",
                "first_name",
                "last_name",
                "image" }, 
                new string[] {
                "'" + UserNameRTextInput.text + "'",
                "'" + FirstNameTextInput.text + "'",
                "'" + LastNameTextInput.text + "'",
                "''"});
            SceneManager.LoadScene("LoginScene", LoadSceneMode.Single);
        }

        void ReturnButtonClicked()
        {
            SceneManager.LoadScene("LoginScene", LoadSceneMode.Single);
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(arg0.name));
        }
    }
}
