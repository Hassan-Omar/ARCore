using UnityEngine;

public class ColorSwitchManager : MonoBehaviour
{
    public GameObject lastGeneratedObject; 
    /// <summary>
    /// Function to Switch the Muterial on Current Selected Model
    /// </summary>
    /// <param name="id"> id of target material</param>
    public void switchToMaterial(Material targetMaterial)
    {
        lastGeneratedObject.GetComponent<MeshRenderer>().materials[0] = targetMaterial; 
    }
}
