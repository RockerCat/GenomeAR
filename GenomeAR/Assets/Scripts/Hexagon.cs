using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hexagon : MonoBehaviour
{
    public GameObject hexagonFront;

    public string itemType;
    public TextMeshPro userText;
    public TextMeshPro titleText;
    public LoadImage loadImageBackground;
    private string url;
    private string title;

    public void SetHexagon(string _title, string _url = "") 
    {
        this.GetComponent<Animator>().SetBool("enter", true);
        url = _url;
        title = _title;
        userText.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
    }

    public void SetInfo()
    {
        hexagonFront.SetActive(true);
        if (url != "")
        {
            userText.gameObject.SetActive(true);
            titleText.gameObject.SetActive(false);
            userText.text = title;
            loadImageBackground.loadImage(url);
        }
        else
        {
            userText.gameObject.SetActive(false);
            titleText.gameObject.SetActive(true);
            titleText.text = title;
        }
    }
}
