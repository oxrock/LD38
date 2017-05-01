using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnLogic : MonoBehaviour {

    GameObject spawn;
    GameObject[] spawns;
    bool loaded = false;
    public float timeGoal = 10.0f;
    float timer = 0.0f;
    public GameObject bellFab;
	void Start () {
		spawns = GameObject.FindGameObjectsWithTag("Spawn");
        spawn = spawns[0];
    }

    public void load() {
        loaded = true;
    }

    void loadedFunction() {
        timer += Time.deltaTime;
        if (timer > timeGoal) {
            timer = 0.0f;
            loaded = false;
            GameObject bellClone = (GameObject)Instantiate(bellFab, spawn.transform.position, spawn.transform.rotation);
            bellClone.GetComponent<bellLogic>().setSL(gameObject.GetComponent<spawnLogic>(),gameObject.transform);
            bellClone.transform.SetParent(gameObject.transform);
        }
    }


	void Update () {
        if (loaded) {
            loadedFunction();
        }
		
	}
}
