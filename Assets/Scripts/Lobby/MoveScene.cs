using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveScene : MonoBehaviour
{
    public string SceneName;

    public void MoveSceneTo()
    {
        SceneManager.LoadScene(SceneName);
    }
}
