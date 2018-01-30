using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAvoid : MonoBehaviour
{
    Rigidbody myRig;

    public float avoidenceStrength;
    public float avoidenceRange;

   
    // Use this for initialization
    void Start()
    {
        myRig.GetComponent<Rigidbody>();
    }
    Vector3 wallDir;
    // Update is called once per frame
    void Update()
    {

        doWallAvoidance();
    }

    public void doWallAvoidance()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, myRig.velocity.magnitude))
        {
            myRig.AddForce(hit.normal * avoidenceStrength);
        }
    }
}
