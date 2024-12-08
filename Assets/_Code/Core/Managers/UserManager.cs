using System.Collections;
using Core.NetWork;
using Core.NetWork.ViewModel.Request;
using Core.NetWork.ViewModel.Response;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core.Concreates.Managers
{
    public class UserManager : MonoBehaviour
    {
        public static string UserName;
        public static string Password;
        public static string Country;
        public static int UserId = -1;

        public GameObject loading;

        public void SetUserName(string input)
        {
            UserName = input;
        }

        public void SetPass(string input)
        {
            Password = input;
        }

        public void SetCountry(string input)
        {
            Country = input;
        }

        private void Start()
        {
            checkedUser();
        }

        public void Quit()
        {
            Application.Quit();
        }

        private void checkedUser()
        {
            loading.SetActive(false);
            if (UserId != -1)
            {
                SceneManager.LoadScene(1);
            }
        }

        public void Login()
        {
            var request = new LoginModel();

            // var body = JsonUtility.ToJson(request);
            var body = "{\"username\":\"" + UserName + "\", \"password\":\"" + Password + "\"}";

            StartCoroutine(Post(NetworkConst.Login, body));
        }

        public void Register()
        {
            var request = new RegisterModel();

            // var body = JsonUtility.ToJson(request);
            var body =
                "{\"username\":\""
                + UserName
                + "\", \"password\":\""
                + Password
                + "\", \"country\":\""
                + Country
                + "\"}";

            StartCoroutine(Post(NetworkConst.Register, body));
        }

        public IEnumerator Post(string method, string body)
        {
            string result = null;
            var address = $"{NetworkConst.URL}/{method}";
            Debug.Log(address);
            Debug.Log(body);

            using (UnityWebRequest w = UnityWebRequest.Post(address, body, "application/json"))
            {
                loading.SetActive(true);

                yield return w.SendWebRequest();
                if (w.result == UnityWebRequest.Result.Success)
                {
                    result = w.downloadHandler.text;
                    Debug.Log(result);
                    UserId = int.Parse(result);

                    Debug.Log(UserId);
                    // checkedUser();
                    SceneManager.LoadScene(1);
                }
                else
                {
                    Debug.LogError(w.error);
                }
            }
        }
    }
}
