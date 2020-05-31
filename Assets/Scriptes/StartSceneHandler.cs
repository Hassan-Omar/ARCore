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
}
