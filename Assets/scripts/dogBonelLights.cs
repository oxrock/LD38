using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogBonelLights : MonoBehaviour {


    public Material boneMat;
    float timer = 0.0f;
    public float timerCap = 1.0f;
    //bool lightStatus = false;
    public List<Color32> colorList;
    Color32 tempcolor;
    int index = 0;
	void Start () {
		
	}
    void indexLogic() {
        //Debug.Log(colorList[0]);
        if (index+1 >= colorList.Count-1)
        {
            tempcolor = Color.Lerp(colorList[index], colorList[0], Mathf.PingPong(timer, 1));
        }
        else {
            tempcolor = Color.Lerp(colorList[index], colorList[index+1], Mathf.PingPong(timer, 1));
        }
        boneMat.color = tempcolor;
    }
	
	// Update is called once per frame
	void Update () {
        if (timer < timerCap)
        {
            timer += Time.deltaTime;
        }
        else {
            timer = 0.0f;
            index++;
            if (index >= colorList.Count-1) {
                index = 0;
            }
        }
        indexLogic();

	}
}
