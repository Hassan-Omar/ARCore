using UnityEngine;
using System.Collections;

public class DestroyBlink : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("disable");
	}

    IEnumerator disable()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
