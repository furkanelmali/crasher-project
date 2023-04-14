using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingPanel : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider loadbar;
    // Start is called before the first frame update
    public void loadscene(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    // Update is called once per frame
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            LoadingScreen.SetActive(true);
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadbar.value = progress;
            yield return null;
        }
    }
}
