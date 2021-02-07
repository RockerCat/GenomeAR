using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hexagon : MonoBehaviour
{
    public string itemType;
    public TextMeshPro userText;
    public TextMeshPro titleText;
    public LoadImage loadImageBackground;


    public void SetHexagon(string _title, string _url = "") 
    {
        if (_url != "")
        {
            userText.gameObject.SetActive(true);
            titleText.gameObject.SetActive(false);
            userText.text = _title;
            loadImageBackground.loadImage(_url);
        }
        else
        {
            userText.gameObject.SetActive(false);
            titleText.gameObject.SetActive(true);
            titleText.text = _title;
        }        
    }
}
