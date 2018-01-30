using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpolate : MonoBehaviour
{

    public float speed;
    public Rigidbody thing1;
    public Rigidbody thing2;
    Rigidbody myRig;

    void Start()
    {
        myRig = GetComponent<Rigidbody>();
    }


    void ArriveAtPoint( Vector3 target)
    {

        Vector3 targetOnOurY = target;
        targetOnOurY.y = transform.position.y;
        Vector3 targetOffset = target - transform.position;

        //dist
        float dist = Vector3.Distance(transform.position,target);
        float rampedSpeed = speed * (targetOffset.magnitude / dist);
        float clippedSpeed = Mathf.Min(rampedSpeed, speed);
        Vector3 desiredVel = (clippedSpeed / targetOffset.magnitude) * targetOffset;
        myRig.velocity = desiredVel;

    }
    void Update()
    {
        

        ArriveAtPoint((thing1.position + thing2.position)/2);
    }


}
    //public float BurstSpeed;
    //public float speed;
    //public Transform target;
    //public Transform secondTarget;
    //Rigidbody targetRB;
    //Rigidbody secondTargetRB;

    //public float projectedDist;
    //Vector3 projectedPos;

    //float dist;
    //Vector3 desiredVel;
    //Rigidbody myRig;
    //float currentSpeed;
    //public float acceptableDist;




    //// Use this for initialization
    //void Start()
    //{

    //    myRig = GetComponent<Rigidbody>();
    //    targetRB = target.GetComponent<Rigidbody>();
    //    currentSpeed = speed;
    //}

    //// Update is called once per frame
    //void Update()
    //{


    //    dist = Vector3.Distance(transform.position,Vector3.Lerp(target.position, secondTarget.position,0.5f));//Vector3.Distance(transform.position, target.position);
    //    if (dist > acceptableDist)
    //    {
    //        currentSpeed = speed;
    //        projectedPos =  Vector3.Lerp(target.position + (targetRB.velocity.normalized * projectedDist),secondTarget.position +(secondTargetRB.velocity.normalized * projectedDist),0.5f);
    //        desiredVel = currentSpeed * (projectedPos - transform.position).normalized;
    //        myRig.AddForce((desiredVel - myRig.velocity));
    //    }
    //    else
    //    {
    //        //Vector3 targetOffset = target.position - transform.position;
    //        //float dist = Vector3.Distance(transform.position, target.position);
    //        //float rampedSpeed = currentSpeed * (targetOffset.mag)


    //        //currentSpeed = BurstSpeed;
    //        //desiredVel = (currentSpeed * (dist / currentSpeed) * (target.position - transform.position).normalized;
    //        //myRig.AddForce((desiredVel - myRig.velocity));


    //        Vector3 targetOnOurY = Vector3.Lerp(target.position, secondTarget.position, 0.5f);
    //        targetOnOurY.y = transform.position.y;
    //        Vector3 targetOffset = Vector3.Lerp(target.position, secondTarget.position, 0.5f) - transform.position;

    //        //dist
    //        float rampedSpeed = speed * (targetOffset.magnitude / dist);
    //        float clippedSpeed = Mathf.Min(rampedSpeed, speed);
    //        desiredVel = (clippedSpeed / targetOffset.magnitude) * targetOffset;
    //        myRig.velocity = desiredVel;




    //    }





    //    //myRig.AddForce((desiredVel - myRig.velocity) * Time.deltaTime);
    //}