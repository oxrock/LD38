using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioLogic : MonoBehaviour {

    public AudioSource mySource;
    public List<AudioClip> mySongs;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!mySource.isPlaying) {
            mySource.clip = mySongs[Random.Range(0, mySongs.Count)];
            mySource.Play();
        }
		
	}
}
