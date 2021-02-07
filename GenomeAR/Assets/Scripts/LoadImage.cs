using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadImage : MonoBehaviour
{
    public GameObject imageBox;
    private Material BackgroundMaterial;
    private string url;

    public void loadImage(string _url)
    {
        imageBox.SetActive(true);
        url = _url;
        BackgroundMaterial = imageBox.gameObject.GetComponent<Renderer>().material;
        StartCoroutine(LoadImageGameObject());
    }

    IEnumerator LoadImageGameObject()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) { Debug.Log(www.error); }
        else
        {
            Texture2D loadedTexture = ((DownloadHandlerTexture)www.downloadHandler).texture as Texture2D;
            BackgroundMaterial.mainTexture = loadedTexture;
        }
    }
}
