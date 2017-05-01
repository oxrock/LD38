using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowlHandler : MonoBehaviour {
    public dogLogic doggyBrain;
    GameObject[] Dog;
    float cap = 60.0f;
    float timer = 0.0f;

    // Use this for initialization
    void Start()
    {
        Dog = GameObject.FindGameObjectsWithTag("Dog");
        if (Dog[0] != null)
        {
            doggyBrain = Dog[0].GetComponent<dogLogic>();
            doggyBrain.setTarget(gameObject);
        }
        else
        {
            Debug.Log("Brain was null!!");
        }
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > cap) {
            Destroy(gameObject);
        }
	}
}
