using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fake : MonoBehaviour
{
    public GenomeManager genomeManager;

    private void Start()
    {
        genomeManager.SetGenome();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
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
