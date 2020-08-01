using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeScreenshot : MonoBehaviour {
    
    [SerializeField] GameObject blink;
    [SerializeField] GameObject RightPanel;
    [SerializeField] GameObject PlacementIndicator;
    [SerializeField] GameObject InformationsPanel;
    [SerializeField] ObjectSpawner objectSpawner;
    [SerializeField] ColorSwitchManager colorSwitchManager;
    private Material material; 
    private void Start()
    {
        if (!File.Exists(GetAndroidExternalStoragePath() + "/AbdElKarim_ARKitchen"))
        {
            Directory.CreateDirectory(GetAndroidExternalStoragePath() + "/AbdElKarim_ARKitchen");
        }

    }
    public void CaptureScreenshot()
    {
        //material = objectSpawner.LastCreatedObject.GetComponentInChildren<MeshRenderer>().materials[0]; 
        objectSpawner.LastCreatedObject = null;
        StartCoroutine("TakeAndSaveScreenshot");
    }

    private IEnumerator TakeAndSaveScreenshot()
    {
      
        RightPanel.SetActive(false);
        PlacementIndicator.SetActive(false);
        InformationsPanel.SetActive(true);
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        yield return new WaitForEndOfFrame();
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();
        string filePath = Path.Combine(GetAndroidExternalStoragePath() + "/AbdElKarim_ARKitchen", timeStamp + ".png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());
        refersh(filePath);
        Destroy(ss);
        blink.SetActive(true);
        RightPanel.SetActive(true);
        PlacementIndicator.SetActive(true);
        InformationsPanel.SetActive(false);
        blink.GetComponent<DestroyBlink>().disableBlink();
        //colorSwitchManager.switchToMaterial(material);
    }


    private string GetAndroidExternalStoragePath()
    {
        if (Application.platform != RuntimePlatform.Android)
            return Application.persistentDataPath;

        var jc = new AndroidJavaClass("android.os.Environment");
        var path = jc.CallStatic<AndroidJavaObject>("getExternalStoragePublicDirectory",
            jc.GetStatic<string>("DIRECTORY_DCIM"))
            .Call<string>("getAbsolutePath");
        return path;
    }


    private void refersh(string path)
    {
        using (AndroidJavaClass jcUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        using (AndroidJavaObject joActivity = jcUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
        using (AndroidJavaObject joContext = joActivity.Call<AndroidJavaObject>("getApplicationContext"))
        using (AndroidJavaClass jcMediaScannerConnection = new AndroidJavaClass("android.media.MediaScannerConnection"))
        using (AndroidJavaClass jcEnvironment = new AndroidJavaClass("android.os.Environment"))
        using (AndroidJavaObject joExDir = jcEnvironment.CallStatic<AndroidJavaObject>("getExternalStorageDirectory"))
        {
            jcMediaScannerConnection.CallStatic("scanFile", joContext, new string[] { path }, null, null);
        }
    }

    public void exit()
    {
        Application.Quit();
    }
    public void back()
    {
        SceneManager.LoadSceneAsync("Start");
    }
}
