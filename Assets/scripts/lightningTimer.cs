using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningTimer : MonoBehaviour {
    public List<SpriteRenderer> mySprites;
    public List<float> spriteTimerTracker;
    public List<Color> colorChoices;
    public float timerCap;

    float timer = 0.0f;

    void updateTimers() {
        for (int i = 0; i < spriteTimerTracker.Count; i++) {
            spriteTimerTracker[i] += Time.deltaTime;
            if (spriteTimerTracker[i] > timerCap) {
                spriteTimerTracker[i] = 0.0f;
            }
        }
    }

    void lerpColors() {
        for (int i = 0; i < mySprites.Count; i++) {
            mySprites[i].color = Color.Lerp( Color.white,Color.black, Mathf.PingPong(spriteTimerTracker[i], 1));
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        updateTimers();
        lerpColors();

    }
}
