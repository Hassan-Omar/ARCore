using UnityEngine;

public class ColorSwitchManager : MonoBehaviour
{
    [SerializeField]private ObjectSpawner objectSpawner; 
    /// <summary>
    /// Function to Switch the Muterial on Current Selected Model
    /// </summary>
    /// <param name="id"> id of target material</param>
    public void switchToMaterial(Material targetMaterial)
    {
        objectSpawner.LastCreatedObject.GetComponent<MeshRenderer>().materials[0] = targetMaterial; 
    }
}
