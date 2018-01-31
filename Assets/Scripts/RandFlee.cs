using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandFlee : MonoBehaviour
{
    public float speed;
    public float walkRange;
    public Transform enemy;

    public float wanderRefreshTimer;
    float timer;

    Vector3 desiredVel;


    Rigidbody myRig;




    // Use this for initialization
    //void Start()
    //{
        //timer = 0;
        //myRig = GetComponent<Rigidbody>();
        //desiredVel = speed * (transform.position - (enemy.transform.position + NewDestination())).normalized;
    //}

    //Vector3 randoDest;
    // Update is called once per frame
    //void Update()
    //{
        //timer += Time.deltaTime;

        //if (timer >= wanderRefreshTimer)
        //{
        //    desiredVel = speed * ((transform.position - (enemy.transform.position + NewDestination()))).normalized;
            
        //    timer = 0;
        //}

        //myRig.AddForce((desiredVel ) * Time.deltaTime);
        ////Debug.Log(desiredVel);
        //Debug.DrawLine(transform.position, transform.position + (desiredVel * 10), Color.red);
        //Debug.DrawLine(enemy.transform.position, enemy.transform.position + randoDest, Color.green);
    //}


    public Vector3 returnFleeVector()
    {
        return (enemy.position - transform.position) * -1 + transform.position;
    }

    //Vector3 NewDestination()
    //{
    //    Vector3 retval = new Vector3(Random.Range(-walkRange, walkRange), 0, Random.Range(-walkRange, walkRange));
    //    randoDest = retval;
    //    return retval;
    //}

}