using System.Collections;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour {

    [SerializeField]
    GameObject blink;
    [SerializeField]
    GameObject RightPanel;

    public void TakeAShot()
	{
        RightPanel.SetActive(false);
        StartCoroutine ("CaptureIt");
	}

	IEnumerator CaptureIt()
	{
		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot" + timeStamp + ".png";
		string pathToSave = "AR_AL_FUR"+fileName;
		ScreenCapture.CaptureScreenshot(pathToSave);
		yield return new WaitForEndOfFrame();
        blink.SetActive(true);
        blink.GetComponent<DestroyBlink>().disableBlink();
        RightPanel.SetActive(true);

    }

}
