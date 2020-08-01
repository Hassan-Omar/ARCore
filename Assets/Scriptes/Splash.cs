using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("lazyLoad"); 
    }

    IEnumerator lazyLoad()
    {
        yield return new WaitForSeconds(1.5f); 
        SceneManager.LoadScene("Start"); 
    }
}
