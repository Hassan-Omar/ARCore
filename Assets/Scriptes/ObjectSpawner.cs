using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    
    public GameObject[] objectsToSpawn;
    private PlacementIndicator placementIndicator;
    public GameObject LastCreatedObject; 
    private void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }
     
    /// <summary>
    /// Function to Creates Obj Based on Selected Id 
    /// </summary>
    /// <param name="id">The index of Object I wanna to spawn </param>
    public void spawnObjectById(int id)
    {
        LastCreatedObject = Instantiate(objectsToSpawn[id]);
        LastCreatedObject.transform.position = placementIndicator.transform.position;
    }
}
