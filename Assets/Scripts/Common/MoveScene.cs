using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveScene : MonoBehaviour
{
    public string sceneName;

    public void MoveSceneTo()
    {
        // 이렇게 안하고 MoveSceneTo에서 바로 string받아도 됨.
        // SceneName을 문자형으로 받는 것은 실수 발생할 수 있으니 Scene번호를 사용하는 것도 괜찮음.
        SceneManager.LoadScene(sceneName);
    }
}
