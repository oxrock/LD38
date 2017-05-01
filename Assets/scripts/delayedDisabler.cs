using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayedDisabler: MonoBehaviour {

    public float delayTarget = 1.0f;
    float timer = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > delayTarget) {
            gameObject.SetActive(false);
            Debug.Log("disabled "+ gameObject.name);
        }
		
	}
}
