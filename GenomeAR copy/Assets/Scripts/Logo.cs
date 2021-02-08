using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    public void GoMain()
    {
        StartCoroutine(LoadScene("Main"));
    }

    IEnumerator LoadScene(string _sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneName);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
