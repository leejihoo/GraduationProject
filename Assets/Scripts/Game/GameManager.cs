using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState{standBy, play, end};
    public GameObject endPanel;

    public GameState currentState = GameState.standBy;
    [SerializeField] private FunctionDataModel createGoldFunction;
    [SerializeField] private Text rewardCoin;
    
    public async void EndGame() {
        currentState = GameState.end;
        endPanel.SetActive(true);
        try
        {
            // Args엔 보상으로 생성되는 토큰의 양이 들어간다.
            string response = await Web3GL.SendContract(createGoldFunction.Method,createGoldFunction.Abi, createGoldFunction.ContractAddress,
                $"[\"{int.Parse(createGoldFunction.Args)}\"]", createGoldFunction.Value,"","");
            rewardCoin.text = createGoldFunction.Args;
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            rewardCoin.text = "Fail";
        }
        

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
