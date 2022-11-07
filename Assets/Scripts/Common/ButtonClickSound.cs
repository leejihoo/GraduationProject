using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public void Click()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
