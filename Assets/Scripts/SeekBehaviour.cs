using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehaviour : MonoBehaviour
{
    public float speed;
    public Transform target;



    Vector3 desiredVel;
    Rigidbody myRig;




    // Use this for initialization
    //void Start()
    //{
       //myRig = GetComponent<Rigidbody>();
    //}

    // Update is called once per frame
    //void Update()
    //{
        //desiredVel = speed * (target.position - transform.position).normalized;

        //myRig.AddForce((desiredVel - myRig.velocity) * Time.deltaTime);
    //}

    public Vector3 returnFleeVector()
    {
        return (target.position - transform.position);
    }

}
