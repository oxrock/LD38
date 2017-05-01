using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dogLogic : MonoBehaviour {

    public GameObject player;
    public NavMeshAgent agent;
    GameObject target;
    public AudioSource MySource;
    public List<AudioClip> myClips;
    public AudioClip eating;


    public void setTarget(GameObject victim) {
        target = victim;
    }
    public GameObject getTarget() {
        return target;
    }

    void Start() {
        setTarget(player);
    }

    bool foodOutlierCheck() {
        if (target != player) {
            if (Vector3.Distance(gameObject.transform.position,target.transform.position) < 8) {
                return true;
            }
        }

        return false;
    }

    void noiseManager(){
        if (!MySource.isPlaying) {
            if (foodOutlierCheck())
            {
                MySource.clip = eating;
                MySource.Play();
            }
            else {
                MySource.clip = myClips[Random.Range(0, myClips.Count)];
                MySource.Play();
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            agent.SetDestination(target.transform.position);
        }
        else {
            if (player != null)
            {
                setTarget(player);
            }
            else {
                Debug.Log("CRITICAL NULL TARGET DOGGY SITUATION!!!!");
            }
        }
        noiseManager();
	}
}
