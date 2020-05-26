using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// This Script To View A Mark On The Serface 
/// </summary>
public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject visual;

    private void Start()
    {
        // Get rayManager, visusl
        rayManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;
        // deactivate visual as it will apears only when toching screen 
        visual.SetActive(false);
    }


    private void Update()
    {
        // shoot raycast from middle of screen 
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
         // check if we hit 
         if(hits.Count>0)
         {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
            
            if(!visual.activeInHierarchy)
            {
                visual.SetActive(true);
            }
         }
    }
}
