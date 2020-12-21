using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject preloader;
    public void ChangeScene(int lvl)
    {
        preloader.SetActive(true);
        StartCoroutine(LoadAsyncScene(lvl));
    }
    public void ChangeSceneWithParams(int lvl,int run_type,int game_mode)
    {
        GlobalParams.Initialize(run_type, game_mode);
        preloader.SetActive(true);
        StartCoroutine(LoadAsyncScene(lvl));
    }
    IEnumerator LoadAsyncScene(int lvl)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(lvl);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");

            // Loading completed
            if (asyncLoad.progress == 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;

        }

    }
}
