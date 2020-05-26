using UnityEngine;

public class ColorSwitchManager : MonoBehaviour
{
    [SerializeField]private GameObject selectModel; 
    [SerializeField]private ObjectSpawner objectSpawner; 
    /// <summary>
    /// Function to Switch the Muterial on Current Selected Model
    /// </summary>
    /// <param name="id"> id of target material</param>
    public void switchToMaterial(Material targetMaterial)
    {
        if (objectSpawner.LastCreatedObject != null)
        {
            Material[] mats = objectSpawner.LastCreatedObject.GetComponentInChildren<MeshRenderer>().materials;
            mats[0] = targetMaterial;
            objectSpawner.LastCreatedObject.GetComponentInChildren<MeshRenderer>().materials= mats;
            Debug.Log(objectSpawner.LastCreatedObject.GetComponentInChildren<MeshRenderer>().materials[0].name + "________"+targetMaterial.name+"_______" + objectSpawner.LastCreatedObject.name);
            selectModel.SetActive(false);
         }
        else
        {
            selectModel.SetActive(true);
            selectModel.GetComponent<DestroyBlink>().disableBlink();
        }
        
    }
}
