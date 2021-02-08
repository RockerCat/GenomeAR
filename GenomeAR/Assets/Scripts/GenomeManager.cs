using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenomeManager : MonoBehaviour
{
    public Communicator communicator;
    public UIManager uIManager;
    private HexagonsManager hexagonsManager;
    private string picture;
    private string userName;
    private string[] menuList = {"Current Skills", "Skills to develop", "Awards", "Jobs", "Projects", "Publications", "Education", "Opportunities", "Languages", "Personality" };

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

    public void SetGenome(string userName)
    {
        hexagonsManager = FindObjectOfType<HexagonsManager>();
        hexagonsManager.HexagonLoading.gameObject.SetActive(true);
        hexagonsManager.ClearAllHexagons();
        communicator.GetBio(userName);
    }

    public void OnGetBio(JSONObject dataJSON)
    {
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
        SetBio();   
    }

    public void SetBio()
    {
        hexagonsManager.SetMenuHexagons(menuList);
    }

    public void UpdateBio(string _key)
    {
        hexagonsManager.ClearHexagons();
        switch (_key)
        {
            case "Current Skills"       : hexagonsManager.SetHexagons(strengths); break;
            case "Skills to develop"    : hexagonsManager.SetHexagons(interests); break;
            case "Awards"               : hexagonsManager.SetHexagons(awards); break;
            case "Jobs"                 : hexagonsManager.SetHexagons(jobs); break;
            case "Projects"             : hexagonsManager.SetHexagons(projects); break;
            case "Publications"         : hexagonsManager.SetHexagons(publications); break;
            case "Education"            : hexagonsManager.SetHexagons(education); break;
            case "Opportunities"        : hexagonsManager.SetHexagons(opportunities, "interest"); break;
            case "Languages"            : hexagonsManager.SetHexagons(languages, "language"); break;
            case "Personality"          : hexagonsManager.SetPersonalityHexagons(personalityTraitsResults); break;
        }
        uIManager.SetGenomeDetail();
    }
}
