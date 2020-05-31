using UnityEngine;
using System.Collections;

public class DestroyBlink : MonoBehaviour {

	// Use this for initialization
	public void disableBlink() {
        StartCoroutine("disable");
	}

    IEnumerator disable()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
