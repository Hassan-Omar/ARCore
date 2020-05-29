using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DragDropManager : MonoBehaviour
{
    private Vector2 touchPosition;
    private ARRaycastManager arRaycatManager;
    [SerializeField] private ObjectSpawner objectSpawner;
    [SerializeField] private Camera arCamera; 

    private bool onTouchHold = false; 
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Start()
    {
        // Get rayManager
        arRaycatManager = FindObjectOfType<ARRaycastManager>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;
            if (touch.phase == TouchPhase.Began)
            {

                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if(Physics.Raycast(ray,out hitObject) )
                {
                    if(hitObject.transform.name.Contains("M"))
                    {
                        onTouchHold = true; 
                    }
                }

                
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                onTouchHold = false;
            }

        }

        if(onTouchHold)
        {
            if(arRaycatManager.Raycast(touchPosition,hits,TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose; 
                if(objectSpawner.LastCreatedObject !=null)
                {
                    objectSpawner.LastCreatedObject.transform.position = hitPose.position; 
                }
            } 
        }
    }
}
