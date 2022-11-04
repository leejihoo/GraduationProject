using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]private int hp = 100;
    Animator animator;
    public GameManager gameManager;

    /* 
        필요한 기능
        1. 보스 체력 관리
        2. 보스 타격 이벤트 처리
        3. 보스 공격
     */
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void GetDamaged(int damage) {
        hp -= damage;
        if(hp <= 0) {
            animator.SetBool("Dead",true);
            gameManager.EndGame();
        } else {
            animator.SetTrigger("Damaged");
        }
    }

}
