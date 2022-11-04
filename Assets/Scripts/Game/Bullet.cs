using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private int damage = 17;

    private void Update() {
        transform.Translate(0.1f, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("boss")) {
            other.GetComponent<Boss>().GetDamaged(damage);
        }
        BulletPool.ReturnObject(this);
    }
}
