using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GenomeManager genomeManager;
    public ARTapToPlaceObject aRTapToPlace;
    public InputField userName_input;
    public GameObject placeBox;
    public GameObject userNameBox;
    public GameObject buttons;
    public GameObject usernameBtn;
    public GameObject backBtn;
    public GameObject placeBtn;

    private void Start()
    {
        buttons.gameObject.GetComponent<Animator>().SetBool("enter", false);
    }

    private void Update()
    {
        if (aRTapToPlace.state == "Genome")
        {
            usernameBtn.SetActive(true);
            backBtn.SetActive(false);
            placeBtn.SetActive(false);
        }
        else if (aRTapToPlace.state == "Form")
        {
            usernameBtn.SetActive(false);
            backBtn.SetActive(false);
            placeBtn.SetActive(false);
        }
        else if (aRTapToPlace.state == "Place")
        {
            usernameBtn.SetActive(false);
            backBtn.SetActive(false);
            placeBtn.SetActive(false);
        }
        else if (aRTapToPlace.state == "Navigation")
        {
            usernameBtn.SetActive(false);
            backBtn.SetActive(true);
            placeBtn.SetActive(false);
        }   
    }

    public void SetPlaceUI()
    {
        Debug.Log("SetPlaceUI");
        buttons.gameObject.GetComponent<Animator>().SetBool("enter", false);
        placeBox.gameObject.GetComponent<Animator>().SetBool("enter", true);

        userNameBox.gameObject.GetComponent<Animator>().SetBool("enter", false);
    }

    public void SetFormUI()
    {
        aRTapToPlace.state = "Form";
        buttons.gameObject.GetComponent<Animator>().SetBool("enter", false);
        placeBox.gameObject.GetComponent<Animator>().SetBool("enter", false);
        userNameBox.gameObject.GetComponent<Animator>().SetBool("enter", true);
    }

    public void DownPanel()
    {
        placeBox.gameObject.GetComponent<Animator>().SetBool("enter", false);
        userNameBox.gameObject.GetComponent<Animator>().SetBool("enter", false);
        buttons.gameObject.GetComponent<Animator>().SetBool("enter", true);
    }

    public void SetGenomeBio()
    {
        aRTapToPlace.state = "Genome";
        if (userName_input.text !="") genomeManager.SetGenome(userName_input.text);
        DownPanel();
    }

    public void SetGenomeDetail()
    {
        aRTapToPlace.state = "Navigation";
    }

    public void GoBack()
    {
        aRTapToPlace.state = "Genome";
        genomeManager.SetBio();
    }
}
