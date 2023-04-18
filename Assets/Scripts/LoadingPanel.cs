using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingPanel : MonoBehaviour
{
    public static LoadingPanel instance;
    public GameObject LoadingScreen;
    public Slider loadbar;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }
    // Start is called before the first frame update
    public async void loadscene(int sceneIndex)
    {
        var scene = SceneManager.LoadSceneAsync(sceneIndex);
        scene.allowSceneActivation = false;

        LoadingScreen.SetActive(true);

        do{
            await Task.Delay(100);
            loadbar.value = scene.progress;
        }
        while(scene.progress < 0.9f);
        
        scene.allowSceneActivation = true;
         
        await Task.Delay(10000);
        
        LoadingScreen.SetActive(false); 
        //StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    // Update is called once per frame
    /*IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            LoadingScreen.SetActive(true);
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadbar.value = progress;
            yield return null;
        }
    }*/
}
