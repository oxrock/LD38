using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargerLogic : MonoBehaviour {

    public BoxCollider myCollider;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "player") {
            collision.gameObject.GetComponent<playerController>().batteryCharging(true);
        }
        //Debug.Log("Happened");
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.GetComponent<playerController>().batteryCharging(false);
        }
    }





    // Update is called once per frame
    void Update () {
		
	}
}
