using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_WEBGL
namespace Web3Unity.Scripts.Scenes
{
    public class WebLogin : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void Web3Connect();

        [DllImport("__Internal")]
        private static extern string ConnectAccount();

        [DllImport("__Internal")]
        private static extern void SetConnectAccount(string value);

        private string _account; 

        public void OnLogin()
        {
            Web3Connect();
            OnConnected();
        }

        private async void OnConnected()
        {
            _account = ConnectAccount();
            while (_account == "") {
                await new WaitForSeconds(1f);
                _account = ConnectAccount();
            };
            // save account for next scene
            PlayerPrefs.SetString("Account", _account);
            // reset login message
            SetConnectAccount("");
            // load next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
#endif
