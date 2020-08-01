using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectObject : MonoBehaviour
{ 
    [SerializeField] private Camera arCameera;
    [SerializeField] private ObjectSpawner objectSpawner;
    [SerializeField] private ColorSwitchManager colorManager;
    [SerializeField] private Material selectionMaterial;
    [SerializeField] private GameObject confirmDeltePanel;

    private Material selectedObjPrvMaterial;

    public bool isOverTaggedElement = false;
    private bool multiCallBlocker = true;

    private void Update()
    {
        if (Input.touchCount > 0)
        { 

            if (!IsPointerOverUIObject())
            {
                selctObject();
                if (Input.GetTouch(0).tapCount > 1)
                {
                    deleteSelectedObject();
                }
            }           
        }
    }

    private void selctObject()
    {
        if (Input.touchCount >0)
        {
            Touch touch = Input.GetTouch(0);
 
            Ray ray = arCameera.ScreenPointToRay(touch.position);
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    objectSpawner.LastCreatedObject = hitObject.transform.gameObject; ;
                    if (objectSpawner.LastCreatedObject != null)
                    {
                        selectedObjPrvMaterial = objectSpawner.LastCreatedObject.GetComponentInChildren<MeshRenderer>().material;
                        colorManager.switchToMaterial(selectionMaterial);
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (objectSpawner.LastCreatedObject != null)
                {
                    colorManager.switchToMaterial(selectedObjPrvMaterial);
                }
            }
            
        }
    }

    public void deleteSelectedObject()
    {
        if (objectSpawner.LastCreatedObject != null)
        {
            confirmDeltePanel.SetActive(true);
        }
    }

    
    // Function to check if WE Clicking On UI elemet 
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public void confirmDelete(bool decision)
    {
        if(decision)
        {
            Destroy(objectSpawner.LastCreatedObject);
        }
    }
}
