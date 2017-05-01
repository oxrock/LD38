using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bellLogic : MonoBehaviour {
    bool loaded = true;
    public Transform spawnLocation;
    public GameObject foodFab;
    bool soundStarted = false;
    public AudioSource AS;
    public spawnLogic SL;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player") {
            if (loaded) {
                GameObject fabClone = (GameObject)Instantiate(foodFab, spawnLocation.position, spawnLocation.rotation);
                loaded = false;
            }
        }
        //Debug.Log("Bell Triggered by:" +other.gameObject.name);
    }
    void Start () {
		
	}

    public void setSL(spawnLogic SLogic, Transform _SL) {
        SL = SLogic;
        spawnLocation = _SL;
    }
	
	// Update is called once per frame
	void Update () {
        if (!loaded) {
            if (!soundStarted)
            {
                AS.Play();
                soundStarted = true;
                return;
            }
            else {
                if (!AS.isPlaying) {
                    SL.load();
                    Destroy(gameObject);
                }
            }
        }
	}
}
