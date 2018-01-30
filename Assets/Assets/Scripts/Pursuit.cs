using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : MonoBehaviour
{
    public float BurstSpeed;
    public float speed;
    public Transform target;
    Rigidbody targetRB;
    public float projectedDist;
    Vector3 projectedPos;

    float dist;
    Vector3 desiredVel;
    Rigidbody myRig;
    float currentSpeed;
    public float acceptableDist;




    // Use this for initialization
    void Start()
    {
        
        myRig = GetComponent<Rigidbody>();
        targetRB = target.GetComponent<Rigidbody>();
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        dist = Vector3.Distance(transform.position, target.position);
        if (dist > acceptableDist)
        {
            currentSpeed = speed;
            projectedPos = target.position + (targetRB.velocity.normalized * projectedDist);
            desiredVel = currentSpeed * (projectedPos - transform.position).normalized;
            myRig.AddForce((desiredVel - myRig.velocity));
        }
        else
        {
            currentSpeed = BurstSpeed;
            desiredVel = currentSpeed * (target.position - transform.position).normalized;
            myRig.AddForce(desiredVel - myRig.velocity);
        }
        




        //myRig.AddForce((desiredVel - myRig.velocity) * Time.deltaTime);
    }
}
