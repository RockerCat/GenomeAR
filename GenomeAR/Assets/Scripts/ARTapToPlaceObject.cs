using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

using UnityEngine.XR.ARSubsystems;
using System;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject placementIndicator;
    public GameObject objectToPlace;
    public GenomeManager genomeManager;
    
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;
    private bool hexagonsPlaced = false;
    private bool showPlacement = true;
    private string state = "Init";

    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        if (state == "Init")
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();

            if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !hexagonsPlaced)
            {
                Debug.Log("ARTapToPlaceObject - PlaceObject");
                PlaceObject();
            }
        }
        else if (state == "Genome")
        {
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.gameObject.tag == "Hexagon")
                    {
                        Hexagon hexagonCollide = hit.transform.gameObject.GetComponent<Hexagon>();
                        genomeManager.UpdateBio(hexagonCollide.itemType);
                    }
                }
            }
        }
    }

    private void PlaceObject()
    {
        Instantiate(objectToPlace, PlacementPose.position, PlacementPose.rotation);
        showPlacement = false;
        hexagonsPlaced = true;
        Debug.Log("genomeManager: " + genomeManager);
        genomeManager.SetGenome();
        state = "Genome";
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid && !hexagonsPlaced)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);
        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid && showPlacement)
        {
            PlacementPose = hits[0].pose;
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            PlacementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}