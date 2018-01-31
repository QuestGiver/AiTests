using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        WANDERSTATE,SEEK,FLEESTATE,STARTOVERSTATE
    }

    NavMeshAgent agent;
    Wander wander;
    SeekBehaviour seek;
    RandFlee flee;

    public States currentState;

    public float transitionTime;
    float timer;

    // Use this for initialization
    void Start()
    {
        timer = transitionTime;
        agent = GetComponent<NavMeshAgent>();
        wander = GetComponent<Wander>();
        seek = GetComponent<SeekBehaviour>();
        flee = GetComponent<RandFlee>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case States.WANDERSTATE:
                agent.destination = wander.returnWanderPoints();
                break;
            case States.SEEK:
                agent.destination = seek.returnFleeVector();
                break;
            case States.STARTOVERSTATE:
                
                break;
            case States.FLEESTATE:
                agent.destination = flee.returnFleeVector();
                break;
            
        }

    }

    void switchStates()
    {

        




        timer -= Time.deltaTime;
        if (timer < 0)
        {
            currentState++;
            if (currentState == States.STARTOVERSTATE)
            {
                currentState = States.WANDERSTATE;
            }
            timer = transitionTime;
        }
    }

}
