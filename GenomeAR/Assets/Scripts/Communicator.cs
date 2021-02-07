using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System.Globalization;

public class Communicator : MonoBehaviour
{
    public GenomeManager genomeManager;

    private bool isProcessing = false;

    ///----------------------------------------------------------------------------

    public void GetBio(string _username)
    {
        StartCoroutine(LoadGetBio(_username));
    }

    private IEnumerator LoadGetBio(string _username)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = "https://torre.bio/api/bios/" + _username;
            Debug.Log("Loading: " + url);
            WWWForm form = new WWWForm();
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                if (jsonString != null && jsonString.Length > 1)
                {
                    JSONObject dataJSON = new JSONObject(jsonString);
                    genomeManager.OnGetBio(dataJSON);
                }
                else
                {
                    //showError(www.error);
                }
            }
            else
            {
                //showError(www.error);
            }
        }
    }
}
