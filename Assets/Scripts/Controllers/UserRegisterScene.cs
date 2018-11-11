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
        private InputField UserNameTextInput, FirstNameTextInput, LastNameTextInput;
        private UserModel user;

        /*
        * Init components
        */
        void Awake()
        {
            user = new UserModel();

            DontDestroyOnLoad(this.gameObject);

            RegisterButton = GameObject.Find("RegisterButton").GetComponent<Button>();
            ReturnButton = GameObject.Find("ReturnButton").GetComponent<Button>();
            UserNameTextInput = GameObject.Find("UserNameTextInput").GetComponent<InputField>();
            FirstNameTextInput = GameObject.Find("FirstNameTextInput").GetComponent<InputField>();
            LastNameTextInput = GameObject.Find("LastNameTextInput").GetComponent<InputField>();
        }

        /*
        * onClick events assigned to buttons
        */
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

        /*
        * Manage click events
        */
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

        /*
         * method for registering users
         */ 
        void RegisterButtonClicked()
        {
            user.Insert(new string[] {
                "user_name",
                "first_name",
                "last_name",
                "image" }, 
                new string[] {
                UserNameTextInput.text,
                FirstNameTextInput.text,
                LastNameTextInput.text,
                ""});
        }

        /*
        * Este metodo no se ocupa, es para el debug nomas
        */
        void ReturnButtonClicked()
        {
            SceneManager.LoadScene("LoginScene");
        }
    }
}
