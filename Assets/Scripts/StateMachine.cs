using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        idle,
        walking,
        swimming,
        climbing
    }

    public State currentstate = State.idle;
    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentstate)
        {
            case State.idle: Idle(); 
                break;
            case State.walking: Walking();
                break;
            case State.swimming: Swimming();
                break;
            case State.climbing: Climbing();
                break;
            default: break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "WaterTrigger")
        {
            currentstate = State.swimming;
        }
        else if (other.name == "MountainTrigger")
        {
            currentstate = State.climbing;
        }
    }

    void OnTriggerExit(Collider other)
    {
        currentstate = State.walking;
    }

    void Swimming()
    {
        Debug.Log ("I am swimming!");
    }

    void Climbing()
    {
        Debug.Log("I am climbing!");
    }

    void Idle()
    {
        Debug.Log("I am idle!");

        if (lastPosition != transform.position)
        {
            currentstate = State.walking;
        }
        lastPosition = transform.position;
    }

    void Walking()
    {
        Debug.Log("I am walking!");

        if (lastPosition == transform.position)
        {
            currentstate = State.idle;
        }
        lastPosition = transform.position;
    }
}
