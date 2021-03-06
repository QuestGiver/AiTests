﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleAI : MonoBehaviour
{
    [Header("Core Variables")]
    public float speed;
    public float homingSensitivity;// 0 means less tracking, 1 is most tracking possible
    public float deathTimer = 30;
    public float speedLimmit = 200;

    [Header("RigidBody Target")]
    public Rigidbody target;

    [Header("Non-editable values")]
    public float metersPerSec;
    public float timer;

    Rigidbody myRig;
    
    Collider myCol;

    // Use this for initialization
    void Start()
    {
        myRig = GetComponent<Rigidbody>();
        myCol = GetComponent<Collider>();
    }



    // Update is called once per frame
    void Update()
    {
        metersPerSec = myRig.velocity.magnitude;

        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, homingSensitivity);//the main bit of tracking.


        if (metersPerSec < speedLimmit)
        {
            myRig.AddRelativeForce(new Vector3(0, 0, speed) * Time.deltaTime);//This uses rigidbody and looks more real. Best setting for drag and mass is 0.5(drag) to 1(mass)
                                                                              //transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);//This option does not use rigidbody but is far more accurate
        }

        if (timer >= deathTimer)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name == "Target")
        {
            Debug.Log("detected Collision");
            Destroy(gameObject);
        }
    }
    
}