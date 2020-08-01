using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneHandler : MonoBehaviour
{
    private int firstTimeToPlay; 
    private void Start()
    {
        firstTimeToPlay = PlayerPrefs.GetInt("firstTimeToPlay"); 
        if(firstTimeToPlay == 0)
        {
            PlayerPrefs.SetInt("firstTimeToPlay", 1); 
        }
    }

    public void openStartScen()
    {
        if(firstTimeToPlay==0)
        {
            SceneManager.LoadSceneAsync("Tutorial");
        }
        else
        {
            SceneManager.LoadSceneAsync("ARScene");
        }
    }

    public void OpenUrl(string url)
    {
        Application.OpenURL("https://" + url);
    }
    public void openTutorial()
    {
        SceneManager.LoadSceneAsync("Tutorial");
    }
    public void openMeaser()
    {
        SceneManager.LoadSceneAsync("Measurement");
    }

    public void shareMessage()
    {
        var Txt = "ياصديقى\r\n Check this App \r\n تفدر من خلاله تصمم مطبخك \r\n  https://play.google.com/store/apps/details?id=com.abdelkarim.arkitchen";
        new NativeShare().SetText(Txt).Share(); 
    }
}
