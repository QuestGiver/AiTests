using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : MonoBehaviour
{

    public float burstSpeed;
    //public float walkRange;
    public Transform enemy;
    public float distThreshold;
    public float wanderRefreshTimer;
    float timer;

    Vector3 desiredVel;
    Vector3 perpVectScaler;

    Rigidbody myRig;




    // Use this for initialization
    void Start()
    {
        timer = 0;
        myRig = GetComponent<Rigidbody>();
        perpVectScaler = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
        timer = wanderRefreshTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;






        if (Vector3.Distance(transform.position, enemy.position) < distThreshold)
        {
            if (timer >= wanderRefreshTimer)
            {
                perpVectScaler = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
                myRig.AddForce(((Vector3.Cross(enemy.position - transform.position, perpVectScaler)).normalized * burstSpeed) * Time.deltaTime, ForceMode.Impulse);
            }

        }
    }

    //Vector3 NewDestination()
    //{
    //    return new Vector3(Random.Range(-walkRange, walkRange), 0, Random.Range(-walkRange, walkRange));
    //}
}
