using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLeveLAsync : MonoBehaviour
{
    [SerializeField] Image _progressBar;

    private void Start()
    {
        StartCoroutine(LoadSceneAsyc());
    }

    IEnumerator LoadSceneAsyc()
    {
        //The operation that will control the Async loading using the global LoadingData script
        AsyncOperation operation = SceneManager.LoadSceneAsync(LoadingData.sceneToLoad);
        //Stop next scene from loading
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            //here you can do whatever you want, from displaying tips to anything else
            _progressBar.fillAmount = operation.progress;

            if (operation.progress >= 0.9f)
            {
                //allow next scene to load
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
