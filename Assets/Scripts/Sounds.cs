using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioSource musicSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
       if(index == 1)
        {
            musicSource.Play();
        }
        else if(index == 0)
        {
            musicSource.Stop();
        }
    }
}
