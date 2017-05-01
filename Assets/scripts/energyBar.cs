using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyBar : MonoBehaviour {

    public Image healthbar;
    public float maxHeight = 94.2f;
    public Color green;
    public Color red;
    public float currentEnergy = 0.0f;
    float energyPercent = 100.0f;
    //float fillHeight = 94.2f;
    float fillAmount = 1.0f;
    //public List<Color> myColors;

    float findenergyPercent() {
        return (currentEnergy / 100.0f) * 100;
    }

    float numberClamp(float value, float inclusiveMinimum, float inlusiveMaximum)
    {
        if (value >= inclusiveMinimum)
        {
            if (value <= inlusiveMaximum)
            {
                return value;
            }

            return inlusiveMaximum;
        }

        return inclusiveMinimum;
    }


    void percentConversion(float percent) {
        fillAmount = findenergyPercent();
        if (fillAmount == 0.0f)
        {
            fillAmount = 0.001f;
        }
        else {
            fillAmount = fillAmount/100.0f;
        }
        //Debug.Log(fillAmount);
        healthbar.fillAmount = fillAmount;
        colorLerp();
    }

    void colorLerp() {
        healthbar.color = Color.Lerp(green, red, 1.0f-numberClamp(fillAmount, 0.0f,1.0f));
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        percentConversion(findenergyPercent());

    }
}
