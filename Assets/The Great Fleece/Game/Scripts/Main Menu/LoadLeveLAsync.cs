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
        AsyncOperation operation = SceneManager.LoadSceneAsync(2);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            
            _progressBar.fillAmount = operation.progress;

            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
