using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fake : MonoBehaviour
{
    public GenomeManager genomeManager;
    public UIManager uIManager;
    public string state = "Place";

    private void Start()
    {
        SetPlaceUI();
    }

    public void SetPlaceUI()
    {
        uIManager.SetPlaceUI();
    }

    public void SetFormUI()
    {
        uIManager.SetFormUI();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && state !="Navigation")
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Hexagon")
                {
                    Hexagon hexagonCollide = hit.transform.gameObject.GetComponent<Hexagon>();
                    genomeManager.UpdateBio(hexagonCollide.itemType);
                }
            }
        }
    }

}
