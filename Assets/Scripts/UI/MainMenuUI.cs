using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public bool playClicked;
    public void PlayButton()
    {
        playClicked = true;
        gameObject.SetActive(false);
        
    }
}
