using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GenomeManager genomeManager;
    public ARTapToPlaceObject aRTapToPlace;
    public Fake fake;
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
        try
        {
            if (fake.state == "Genome")
            {
                usernameBtn.SetActive(true);
                backBtn.SetActive(false);
                placeBtn.SetActive(false);
            }
            else if (fake.state == "Form")
            {
                usernameBtn.SetActive(false);
                backBtn.SetActive(false);
                placeBtn.SetActive(false);
            }
            else if (fake.state == "Place")
            {
                usernameBtn.SetActive(false);
                backBtn.SetActive(false);
                placeBtn.SetActive(false);
            }
            else if (fake.state == "Navigation")
            {
                usernameBtn.SetActive(false);
                backBtn.SetActive(true);
                placeBtn.SetActive(false);
            }
        }
        catch { }

        try
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
        catch { }


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
        try
        {
            aRTapToPlace.state = "Form";
        }
        catch { }
        try
        {
            fake.state = "Form";
        }
        catch { }

        
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
        Debug.Log("userName_input.text: " + userName_input.text);
        try
        {
            aRTapToPlace.state = "Genome";
        }
        catch { }
        try
        {
            fake.state = "Genome";
        }
        catch { }
        if (userName_input.text !="") genomeManager.SetGenome(userName_input.text);
        DownPanel();
    }

    public void SetGenomeDetail()
    {
        try
        {
            aRTapToPlace.state = "Navigation";
        }
        catch { }
        try
        {
            fake.state = "Navigation";
        }
        catch { }
    }

    public void GoBack()
    {
        try
        {
            aRTapToPlace.state = "Genome";
        }
        catch { }
        try
        {
            fake.state = "Genome";
        }
        catch { }
        genomeManager.SetBio();
    }
}
