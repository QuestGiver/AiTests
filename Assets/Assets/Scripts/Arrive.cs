using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour
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
            //Vector3 targetOffset = target.position - transform.position;
            //float dist = Vector3.Distance(transform.position, target.position);
            //float rampedSpeed = currentSpeed * (targetOffset.mag)


            //currentSpeed = BurstSpeed;
            //desiredVel = (currentSpeed * (dist / currentSpeed) * (target.position - transform.position).normalized;
            //myRig.AddForce((desiredVel - myRig.velocity));


            Vector3 targetOnOurY = target.position;
            targetOnOurY.y = transform.position.y;
            Vector3 targetOffset = target.position - transform.position;

            //dist
            float rampedSpeed = speed * (targetOffset.magnitude / dist);
            float clippedSpeed = Mathf.Min(rampedSpeed, speed);
            desiredVel = (clippedSpeed / targetOffset.magnitude) * targetOffset;
            myRig.velocity = desiredVel;




        }





        //myRig.AddForce((desiredVel - myRig.velocity) * Time.deltaTime);
    }
}
