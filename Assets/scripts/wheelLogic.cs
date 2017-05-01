using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelLogic : MonoBehaviour {

    public bool steeringWheel = false;
    public bool powered = false;
    //float steeringRot = 0.0f;
    //float rotCap = 30.0f;
    Quaternion rotation;
    public WheelCollider myCollider;



    // let's have 30 degrees rotation be max for front wheels and sets up some sort of rotation sync for the mesh and the collider.
    

    public void changeRotation(float steeringRot, float _rotCap) {

        rotation = gameObject.transform.localRotation;
        gameObject.transform.rotation = rotation;
        rotation.y = steeringRot;
        if (rotation.y > _rotCap)
        {
            rotation.y = _rotCap;
        }
        else if (rotation.y < -_rotCap) {
            rotation.y = -_rotCap;
        }
        //gameObject.transform.localRotation = rotation;
        transform.localEulerAngles = new Vector3(rotation.x, rotation.y, rotation.z);
        myCollider.steerAngle = steeringRot;
    }

    public void changeSpeed(float currentTorque, float maxTorque) {
        myCollider.motorTorque = currentTorque;

    }
    public void brakeCheck(float currentTorque, float maxTorque)
    {
        if (currentTorque < 0)
        {
            if (myCollider.rpm > 0)
            {
                myCollider.brakeTorque = currentTorque;
            }
            else {
                myCollider.brakeTorque = 0;
            }
        }
        if (currentTorque > 0)
        {
            if (myCollider.rpm < 0)
            {
                myCollider.brakeTorque = currentTorque;
            }
            else
            {
                myCollider.brakeTorque = 0;
            }
        }
        else {
            if (myCollider.brakeTorque != 0) {
                myCollider.brakeTorque = 0;
            }
        }
        

    }



}
