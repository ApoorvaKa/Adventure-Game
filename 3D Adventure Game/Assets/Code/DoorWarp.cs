using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorWarp : MonoBehaviour
{
    public GameObject roomGoingTo;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.LookAt(this.transform.GetChild(0));
            collision.GetComponent<NavMeshAgent>().Warp(this.transform.GetChild(0).transform.position);
            //collision.transform.position = this.transform.GetChild(0).transform.position;
            PublicVars.currentRoom = roomGoingTo.name;
        }
    }

}

