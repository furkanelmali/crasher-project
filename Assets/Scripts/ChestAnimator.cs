using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ChestAnimator : MonoBehaviour
{
    public Animation anim;

    UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        anim.Play();
        uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void stopAnimation()
    {
        anim.Stop();
    }

    public void closeChest()
    {
        anim.Play("Close");
    }

    public void Pause()
    {
        uiManager.Pause();
    }
}
