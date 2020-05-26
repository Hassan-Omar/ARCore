using UnityEditor;
using UnityEngine;

public class LevelEditor : EditorWindow
{
    // to hold input field  
    private int numberOfJars, numberOfMixers, numberOfSpatulas, numberOfStars=3, numberOfSpoon, numberOfWSpoon, numberOfOvermittes, numberOfCookies;

    private GameObject levelManager = null;
    private GameObject levelHolder = null;
    private GameObject jarPrefab = null;
    private GameObject mixerPrefab = null;
    private GameObject spatulaPrefab = null;
    private GameObject starPrefab = null;
    private GameObject jellyPrefab = null, cakePrefab = null, cookies=null, spoon=null,overmitte=null,woodSpoon=null, plate = null;

     
    [MenuItem("Window/Level Editor")]
    public static void ShowWindow()
    {
        GetWindow<LevelEditor>("Level Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("This Window Created By H.Omar",EditorStyles.boldLabel);
      
        if (GUILayout.Button("Assign Values"))
        {
            
         }

        if (GUILayout.Button("Save Level"))
        { 
            levelManager.GetComponent<LevelManager>()._levels.Add(levelHolder);
            levelHolder.SetActive(false);
        }
    }

    // function to create instace array of a speciefic game object 
    private void initArray(int num , GameObject obj)
    {
        // loop to generate all objs 
        for (int i = 0; i < num; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(0.8f, -0.65f), 0.65f, Random.Range(0.35f, -0.4f));
            Instantiate(obj,randomPosition,Quaternion.identity,levelHolder.transform);
        }
    }

}
