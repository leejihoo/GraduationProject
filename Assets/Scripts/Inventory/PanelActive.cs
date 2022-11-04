using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActive : MonoBehaviour
{
    public GameObject PresentPanel;
    
    public void ClickPresentActiveButton()
    {
        if(!PresentPanel.activeSelf)
            PresentPanel.SetActive(true);
        else
            PresentPanel.SetActive(false);
    }
}
