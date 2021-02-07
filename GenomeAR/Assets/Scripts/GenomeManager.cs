using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenomeManager : MonoBehaviour
{
    public Communicator communicator;
    private HexagonsManager hexagonsManager;
    private string picture;
    private string userName;
    private string[] menuList = {"Current Skills", "Skills to develop", "Awards", "jobs", "Projects", "Publications", "Education", "Opportunities", "Languages", "Personality" };
    private JSONObject strengths;
    private JSONObject interests;
    private JSONObject experiences;
    private JSONObject awards;
    private JSONObject jobs;
    private JSONObject projects;
    private JSONObject publications;
    private JSONObject education;
    private JSONObject opportunities;
    private JSONObject languages;
    private JSONObject personalityTraitsResults;
    private JSONObject professionalCultureGenomeResults;

    public void Start()
    {
        
    }

    public void SetGenome()
    {
        hexagonsManager = FindObjectOfType<HexagonsManager>();
        communicator.GetBio("torrenegra");
    }

    public void OnGetBio(JSONObject dataJSON)
    {
        Debug.Log("OnGetBio: " + dataJSON);
        JSONObject result = dataJSON["person"];
        picture = result.GetField("picture").str;
        userName = result.GetField("name").str;
        strengths = dataJSON["strengths"];
        interests = dataJSON["interests"];
        experiences = dataJSON["experiences"];
        awards = dataJSON["awards"];
        jobs = dataJSON["jobs"];
        projects = dataJSON["projects"];
        publications = dataJSON["publications"];
        education = dataJSON["education"];
        opportunities = dataJSON["opportunities"];
        languages = dataJSON["languages"];
        personalityTraitsResults = dataJSON["personalityTraitsResults"];
        professionalCultureGenomeResults = dataJSON["professionalCultureGenomeResults"];

        hexagonsManager.SetUserHexagon(userName, picture);
        hexagonsManager.SetMenuHexagons(menuList);
        //hexagonsManager.SetHexagons(strengths);
    }

    public void UpdateBio(string _key)
    {
        hexagonsManager.ClearHexagons();
        switch (_key)
        {
            case "Current Skills": hexagonsManager.SetHexagons(strengths); break;
        }
    }
}
