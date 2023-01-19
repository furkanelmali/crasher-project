using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject MainMenu,GameMenu;
        
    


    void Update()
    {
        timeScaler();
    }

    public void timeScaler()
    {
        if (MainMenu.gameObject.activeSelf)
        {
            Pause();
        }
        else if(GameMenu.gameObject.activeSelf)
        {
            Resume();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void PlayBtn()
    {
        GameMenu.SetActive(true);
        MainMenu.SetActive(false);
        Resume();
    }

    public void GameOver()
    {
        GameMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    
    
    
    
}
