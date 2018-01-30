using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour
{
    Vector3 Cforce;
    Vector3 Aforce;
    Vector3 Sforce;
    Rigidbody rb;
    public float speed;
    public float radius;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Random.insideUnitSphere * 5);
    }

    void Update()
    {
        Vector3 Ctarget = Vector3.zero;
        Vector3 aDesire = Vector3.zero;
        Vector3 sSum = Vector3.zero;

        int hoodSize = 0;
        Collider[] hood = Physics.OverlapSphere(transform.position, radius);


        foreach (Collider guyInHood in hood)
        {
            var Flocker = guyInHood.GetComponent<Flocking>();
            if (Flocker != null)
            {
                hoodSize++;
                Rigidbody guyRb = guyInHood.GetComponent<Rigidbody>();




                Ctarget += Flocker.transform.position;
                aDesire += guyRb.velocity;
                sSum += (transform.position - guyInHood.transform.position) / radius;



            }
        }

        Ctarget /= hoodSize;
        aDesire /= hoodSize;
        sSum /= hoodSize;


        Cforce = (Ctarget - transform.position).normalized * speed - rb.velocity;
        Aforce = aDesire.normalized * speed - rb.velocity;
        Sforce = sSum.normalized * speed - rb.velocity;

        rb.AddForce(((Cforce + Aforce + Sforce).normalized * speed) * Time.deltaTime);
    }
































































    ////not done
    //public float speed;
    //public float searchRadius;
    //public float searchDist;
    //public float jitter;
    //public float followDist;
    //public float wanderRefreshTimer;
    //public float detectionRange;


    //float timer;
    //Vector3 target;
    //Rigidbody myRig;
    //Transform host;
    //Vector3 desiredVel;

    //// Use this for initialization
    //void Start()
    //{
    //    host = null;
    //    GetComponent<Transform>().tag = "Parasite";
    //    myRig = GetComponent<Rigidbody>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    timer += Time.deltaTime;
    //    if (host != null)
    //    {
    //        if (Vector3.Distance(transform.position, host.transform.position) <= followDist)
    //        {
    //            desiredVel = speed * (host.transform.position - transform.position).normalized;

    //            myRig.AddForce((desiredVel - myRig.velocity) * Time.deltaTime);
    //        }
    //        else
    //        {

    //        }

    //    }
    //    else
    //    {

    //        target = Vector3.zero;
    //        target = Random.insideUnitCircle.normalized * searchRadius;
    //        target = (Vector2)target + Random.insideUnitCircle * jitter;

    //        target.z = target.y;

    //        target += transform.position;
    //        target += transform.forward * searchDist;


    //        target.y = 0;
    //        Vector3 dir = (target - transform.position).normalized;
    //        Vector3 desiredVelocity = dir * speed;

    //        myRig.AddForce(desiredVelocity - myRig.velocity);
    //        transform.forward = new Vector3(myRig.velocity.x, 0, myRig.velocity.z);
    //        Debug.DrawLine(transform.position, (desiredVelocity - myRig.velocity) * speed);

    //        RaycastHit hit;
    //        bool isHit = Physics.SphereCast(transform.position, detectionRange, transform.forward, out hit);
    //        if (isHit)
    //        {
    //            host = hit.transform;
    //        }

    //    }



    //}

    //private void OnCollisionEnter(Collision collision)
    //{




    //}
}
