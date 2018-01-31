using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{

    public float speed;
    public float radius;
    public float dist;
    public float jitter;
    //public Transform enemy;

    public float wanderRefreshTimer;
    float timer;

    Vector3 target;


    Rigidbody myRig;




    // Use this for initialization
    //void Start()
    //{

    //    myRig = GetComponent<Rigidbody>();

    //}

    //Vector3 randoDest;
    // Update is called once per frame
    //void Update()
    //{
    //    timer += Time.deltaTime;
    //    target = Vector3.zero;
    //    target = Random.insideUnitCircle.normalized * radius;
    //    target = (Vector2)target + Random.insideUnitCircle * jitter;

    //    target.z = target.y;

    //    target += transform.position;
    //    target += transform.forward * dist;


    //    target.y = 0;
    //    Vector3 dir = (target - transform.position).normalized;
    //    Vector3 desiredVelocity = dir * speed;

    //    myRig.AddForce(desiredVelocity - myRig.velocity);
    //    transform.forward = new Vector3(myRig.velocity.x, 0, myRig.velocity.z);
    //    Debug.DrawLine(transform.position, (desiredVelocity - myRig.velocity) * speed);



    //}

    public Vector3 returnWanderPoints()
    {
        timer += Time.deltaTime;
        target = Vector3.zero;
        target = Random.insideUnitCircle.normalized * radius;
        target = (Vector2)target + Random.insideUnitCircle * jitter;

        target.z = target.y;

        target += transform.position;
        target += transform.forward * dist;


        target.y = 0;
        Vector3 dir = (target - transform.position).normalized;
        Vector3 desiredVelocity = dir * speed;

        myRig.AddForce(desiredVelocity - myRig.velocity);
        transform.forward = new Vector3(myRig.velocity.x, 0, myRig.velocity.z);
        Debug.DrawLine(transform.position, (desiredVelocity - myRig.velocity) * speed);
        return target;

    }
}
