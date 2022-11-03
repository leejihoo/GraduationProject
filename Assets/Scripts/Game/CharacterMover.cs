using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMover : MonoBehaviour
{
    public GameManager gameManager;

    /* 
        필요한 기능 :
        0. 코드에 따라 캐릭터 스킨 적용
        1. 캐릭터 이동
        2. 캐릭터 공격
        3. 캐릭터 체력 제어
     */

    void Update() {
        if (gameManager.IsPlayState()) {
            if (Input.GetKey(KeyCode.W)) transform.position += new Vector3(0.0f, 0.02f, 0.0f);
            if (Input.GetKey(KeyCode.S)) transform.position -= new Vector3(0.0f, 0.02f, 0.0f);
            if (Input.GetKey(KeyCode.A)) transform.position -= new Vector3(0.02f, 0.0f, 0.0f);
            if (Input.GetKey(KeyCode.D)) transform.position += new Vector3(0.02f, 0.0f, 0.0f);
            if (Input.GetKeyDown(KeyCode.Space)) Launch();
        }
    }

    private void Launch() {
        BulletPool.GetObject();
    }
}
