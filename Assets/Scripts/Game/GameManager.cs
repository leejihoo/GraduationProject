using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState{standBy, play, end};
    public GameObject endPanel;

    public GameState currentState = GameState.standBy;

    public void EndGame() {
        currentState = GameState.end;
        endPanel.SetActive(true);
    }

    public void MoveToMainSceneButton() {
        SceneManager.LoadScene("LobbyScene");
    }

    public bool IsPlayState() {
        return currentState == GameState.play;
    }

    public void StartGame() {
        currentState = GameState.play;
    }
}
