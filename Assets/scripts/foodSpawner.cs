using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSpawner : MonoBehaviour {

    public int foodCap = 500;
    public GameObject myParent;
    public GameObject foodFab;
    public float foodinterval = 30.0f;
    float timer = 0.0f;
	void Start () {
        for (int i = 0; i < foodCap; i++) {
            GameObject foodClone = (GameObject)Instantiate(foodFab, transform.position, transform.rotation);
            foodClone.transform.SetParent(myParent.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > foodinterval) {
            timer = 0.0f;
            GameObject foodClone = (GameObject)Instantiate(foodFab, transform.position, transform.rotation);
            foodClone.transform.SetParent(myParent.transform);
        }
        
    }
}
