using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursuit : MonoBehaviour
{

    public Transform leader;
    public float speed;

    Rigidbody rb;
    Vector3 leaderOffset;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        leaderOffset = leader.position - transform.position;
    }

    void arrive(Vector3 targetPos)
    {
        Vector3 targetOnY = targetPos;
        targetOnY.y = transform.position.y;
        Vector3 targetOffset = targetPos - transform.position;
        float dist = Vector3.Distance(transform.position, targetPos);
        float rampedSpeed = speed * (targetOffset.magnitude / dist);
        float clippedSpeed = Mathf.Min(rampedSpeed, speed);

        if (targetOffset.magnitude != 0)
        {
            Vector3 desiredVel = ((clippedSpeed / targetOffset.magnitude) * targetOffset);
            rb.AddForce(desiredVel - rb.velocity);
        }

        
    }


    // Update is called once per frame
    void Update()
    {
        //leaderOffset = leader.position - transform.position;
        arrive(transform.position + leaderOffset);

    }
}
