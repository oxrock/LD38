using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    public float rotMultiplyer = 21.5f;
    float steeringRot = 0.0f;
    float rotCap = 30.0f;
    public List<GameObject> Wheels;
    float currentTorque = 0.0f;
    public float torqueMulti = 50.0f;
    public float maxTorque = 100.0f;
    wheelLogic dummy;
    float torqueIncrement;
    bool spdInput = false;
    public Transform centerOfMass;
    //private Rigidbody myRB;
    private float energyCap = 100;
    private float energy = 100;
    bool chargingStatus = false;
    public float chargeMult = 10;
    int secondsAlive = 0;
    int minutesAlive = 0;
    float timeAlive = 0.0f;
    public Text clockText;
    bool updateclock = false;
    public energyBar EB;
    bool recentlyDamaged = false;
    float damagedTimer = 0.0f;
    float damagedWindow = 2.0f;
    public float damageAmount;
    public AudioSource myAS;
    public managerScript gm;
    public AudioSource myotherAS;


    // implement currentTorque fade

    void energyDrain() {
        energy -= Time.deltaTime;
    }

    void damagedRefresher() {
        damagedTimer += Time.deltaTime;
        if (damagedTimer > damagedWindow) {
            damagedTimer = 0.0f;
            recentlyDamaged = false;
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Dog") {
            if (!recentlyDamaged) {
                energy -= damageAmount;
                myAS.Play();
                recentlyDamaged = true;
            }
        }
        else if (other.gameObject.tag == "battery") {
            energy = energyCap;
            myotherAS.Play();
            Destroy(other.transform.parent.gameObject);
        }
        //Debug.Log(other.gameObject.name);
    }


    void updateTime() {
        updateclock = false;
        timeAlive += Time.deltaTime;
        if (timeAlive > 1) {
            secondsAlive++;
            timeAlive--;
            updateclock = true;
        }
        if (secondsAlive > 59) {
            secondsAlive = 0;
            minutesAlive++;
            updateclock = true;
        }
        if (updateclock) {
            clockText.text = minutesAlive.ToString("00") + ":" + secondsAlive.ToString("00");
        }
    }

    public void batteryCharging(bool value) {
        chargingStatus = value;
        if (chargingStatus) {
            Debug.Log("Charging up!");
        }
    }

    public float energyStatus() {
        return energy;
    }

    void Start () {
        //myRB = gameObject.GetComponent<Rigidbody>();
        //myRB.centerOfMass = centerOfMass.position;  ***Doing this send my car soaring, no idea why
	}
    void torqueDegrade() {
        currentTorque = 0.0f;
    }
    void accelerate() {
        currentTorque += Time.deltaTime * torqueMulti;
        if (currentTorque > maxTorque)
        {
            currentTorque = maxTorque;
        }
    }
    void brake() {
        currentTorque -= Time.deltaTime * torqueMulti;
        if (currentTorque < -maxTorque)
        {
            currentTorque = -maxTorque;
        }
    }

    void steerRight() {
        steeringRot += Time.deltaTime * rotMultiplyer;
        if (steeringRot > rotCap)
        {
            steeringRot = rotCap;
        }
    }

    void steerLeft() {
        steeringRot -= Time.deltaTime * rotMultiplyer;
        if (steeringRot < -rotCap)
        {
            steeringRot = -rotCap;
        }
    }

    void steeringNaturalise(){
        if (steeringRot > 0)
        {
            steeringRot -= Time.deltaTime * (rotMultiplyer / 2);
            if (steeringRot < 0)
            {
                steeringRot = 0.0f;
            }
        }

        else
        {
            steeringRot += Time.deltaTime * (rotMultiplyer / 2);
            if (steeringRot > 0)
            {
                steeringRot = 0.0f;
            }
        }


    }


    void Update()
    {
        spdInput = false;
        if (Input.GetButton("brake"))
        {
            spdInput = true;
            brake();
            if (currentTorque > 0) {
                //currentTorque = 0.0f;
            }
        }
        else if (Input.GetButton("accelerate"))
        {
            spdInput = true;
            accelerate();
            if (currentTorque < 0) {
                //currentTorque = 0.0f;
            }
        }
        
        if (Input.GetButton("steer right"))
            {
            steerRight();
            }
        else if (Input.GetButton("steer left"))
            {
            steerLeft();
            }

        else
            {
            steeringNaturalise();
            }
        if (!spdInput) {
            torqueDegrade();
        }
        if (!chargingStatus)
        {
            energyDrain();
            if (energy <= 0)
            {
                //implement me  ** game over
                gm.GameOver();
            }
        }
        else if (chargingStatus) {
            energy += Time.deltaTime * chargeMult;
            if (energy > energyCap) {
                energy = energyCap;
            }
        }
        updateTime();
        EB.currentEnergy = energy;
        if (recentlyDamaged) {
            damagedRefresher();
        }
        

    }
    void FixedUpdate()
    {
        foreach (GameObject w in Wheels)
        {
            dummy = w.GetComponent<wheelLogic>();
            if (dummy.steeringWheel) {
                dummy.changeRotation(steeringRot, rotCap);
            }
            
            if (dummy.powered)
                {
                if (spdInput)
                {
                   dummy.changeSpeed(currentTorque, maxTorque);
                }
                else {
                   dummy.changeSpeed(0.0f, maxTorque);
                   dummy.brakeCheck(currentTorque, maxTorque);
                }
                    
            }
            else {
                 dummy.brakeCheck(currentTorque, maxTorque);
            }
        }


    }
}
