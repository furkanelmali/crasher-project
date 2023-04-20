using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioSource musicSource;

    public GameObject[] musicButtons;
    UIManager uiManager;
    int musicIndex;
    // Start is called before the first frame update
    void Start()
    {   
       
        audioSource = GetComponent<AudioSource>();
        uiManager = FindObjectOfType<UIManager>();
        musicIndex = uiManager.PlayerPrefsIntKey("MusicIndex",1);
        musicSound(musicIndex);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void crushSound()
    {
        audioSource.Play();
    }

    public void musicSound(int index)
    {
        Debug.Log("SoundCheck");
       if(index == 1)
        {
            musicIndex = index;
            PlayerPrefs.SetInt("MusicIndex",musicIndex);
            musicSource.Play();
            audioSource.mute = false;
            musicButtons[0].SetActive(true);
            musicButtons[1].SetActive(false);
            musicButtons[2].SetActive(true);
            musicButtons[3].SetActive(false);
        }
        else if(index == 0)
        {   
            musicIndex = index;
            PlayerPrefs.SetInt("MusicIndex",musicIndex);
            musicSource.Stop();
            audioSource.mute = true;
            musicButtons[0].SetActive(false);
            musicButtons[1].SetActive(true);
            musicButtons[2].SetActive(false);
            musicButtons[3].SetActive(true);
        }
    }

   
}
