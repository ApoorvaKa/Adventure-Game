using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorWarp : MonoBehaviour
{
    public GameObject roomGoingTo;
    public GameObject doorLock;
    public bool locked = false;

    void Update()
    {
        if(locked)
        {
            doorLock.gameObject.SetActive(true);
        } else {
            doorLock.gameObject.SetActive(false);
        }
    }

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
                locked = false;
                collision.transform.LookAt(this.transform.GetChild(0));
                collision.GetComponent<NavMeshAgent>().Warp(this.transform.GetChild(0).transform.position);
                //collision.transform.position = this.transform.GetChild(0).transform.position;
                PublicVars.currentRoom = roomGoingTo.name;
                doorLock.gameObject.SetActive(true);
            }
        }
    }

}

