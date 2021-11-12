using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    Transform marker;
    string roomCheck;
    public UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {

        PublicVars.currentRoom = "Room1";
    }
    void Update()
    {
        marker = GameObject.Find(PublicVars.currentRoom).transform.GetChild(0);
        transform.position = Vector3.Lerp(transform.position, marker.position, Time.deltaTime * 3);
        if(roomCheck != PublicVars.currentRoom)
        {
            StartCoroutine(WaitMove());
        }
        roomCheck = PublicVars.currentRoom;
    }

    IEnumerator WaitMove()
    {
        agent.speed = 0;
        this.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(.9f);
        this.transform.GetChild(0).gameObject.SetActive(true);
        agent.speed = 6;
    }
}
