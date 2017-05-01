using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class carChase : MonoBehaviour {

    public Transform target;
    public float smoothRate = 2.5f;
    Quaternion tQuat;
    Vector3 tPos;
    public float maxVec = 0.0f;
    public float maxQuat = 0.0f;

	// Use this for initialization
	void Start () {
        gameObject.transform.position = target.position;
        gameObject.transform.rotation = target.transform.rotation;
	}
    float smoothHelper(float first, float second) {
        return Math.Abs(first) - Math.Abs(second);
    }
    float fixTargetQuat(float first, float second)
    {
        float Second = 0.0f;
        if (first > 0)
        {
            if (second < 0)
            {
                return second;
            }
        }
        if (first < 0)
        {
            if (second > 0)
            {
                return second;
            }
        }
        if (first > 0 && second > 0)
        {
            if (first > second)
            {
                Second = first - maxQuat;
                return Second;
            }
            else if (second > first)
            {
                Second = first + maxQuat;
                return Second;
            }
        }
        else if (first < 0 && second < 0)
        {
            if (first > second)
            {
                Second = first - maxQuat;
                return Second;
            }
            else if (second > first)
            {
                Second = first + maxQuat;
                return Second;
            }

        }


        return second;
    }
    float fixTargetVector(float first, float second) {
        float _second = 0.0f;
        if (first > 0) {
            if (second < 0) {
                return second;
            }
        }
        if (first < 0)
        {
            if (second > 0)
            {
                return second;
            }
        }
        if (first > 0 && second > 0)
        {
            if (first > second)
            {
                _second = first - maxVec;
                return _second;
            }
            else if (second > first)
            {
                _second = first + maxVec;
                return _second;
            }
        }
        else if (first < 0 && second < 0) {
            if (first > second)
            {
                _second = first - maxVec;
                return _second;
            }
            else if (second > first)
            {
                _second = first + maxVec;
                return _second;
            }

        }

        
        return second;
    }

    void smoothify() {
        if (smoothHelper(Math.Abs(tPos.x), Math.Abs(gameObject.transform.position.x)) > maxVec) {
            //implement me: call fixTargetVector() to determine how the lerped targeted transform should be altered
            tPos.x = fixTargetVector(tPos.x, gameObject.transform.position.x);
        }
        if (smoothHelper(Math.Abs(tPos.y), Math.Abs(gameObject.transform.position.y)) > maxVec)
        {
            tPos.y = fixTargetVector(tPos.y, gameObject.transform.position.y);
        }
        if (smoothHelper(Math.Abs(tPos.z), Math.Abs(gameObject.transform.position.z)) > maxVec)
        {
            tPos.z = fixTargetVector(tPos.z, gameObject.transform.position.z);
        }

        if (smoothHelper(Math.Abs(tQuat.x), Math.Abs(gameObject.transform.rotation.x)) > maxQuat)
        {
            tQuat.x = fixTargetQuat(tPos.x, gameObject.transform.rotation.x);
        }
        if (smoothHelper(Math.Abs(tQuat.y), Math.Abs(gameObject.transform.rotation.y)) > maxQuat)
        {
            tQuat.x = fixTargetQuat(tPos.y, gameObject.transform.rotation.y);
        }
        if (smoothHelper(Math.Abs(tQuat.z), Math.Abs(gameObject.transform.rotation.z)) > maxQuat)
        {
            tQuat.x = fixTargetQuat(tPos.z, gameObject.transform.rotation.z);
        }


        transform.position = Vector3.Lerp(gameObject.transform.position, target.position, Time.deltaTime);
        transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, target.rotation, Time.time);
    }

    void lerpTransform() {
        //transform.position = Vector3.Lerp(gameObject.transform.position, target.position, Time.deltaTime);
        //transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, target.rotation, Time.time);
        tQuat = Quaternion.Lerp(gameObject.transform.rotation, target.rotation, Time.time*smoothRate);
        tPos = Vector3.Lerp(gameObject.transform.position, target.position, Time.deltaTime * smoothRate);
        smoothify();

    }
	
	// Update is called once per frame
	void Update () {
        lerpTransform();

    }
}
