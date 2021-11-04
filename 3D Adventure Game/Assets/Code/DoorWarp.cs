using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorWarp : MonoBehaviour
{
    public GameObject roomGoingTo;
    public bool locked = true;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(!locked){
                collision.transform.LookAt(this.transform.GetChild(0));
                collision.GetComponent<NavMeshAgent>().Warp(this.transform.GetChild(0).transform.position);
                //collision.transform.position = this.transform.GetChild(0).transform.position;
                PublicVars.currentRoom = roomGoingTo.name;
            }
            else if (PublicVars.numKeys > 0){
                PublicVars.numKeys--;
                collision.transform.LookAt(this.transform.GetChild(0));
                collision.GetComponent<NavMeshAgent>().Warp(this.transform.GetChild(0).transform.position);
                //collision.transform.position = this.transform.GetChild(0).transform.position;
                PublicVars.currentRoom = roomGoingTo.name;
            }
        }
    }

}

