using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    Transform marker;
    string roomCheck;

    // void Start()
    // {
    //     marker = GameObject.Find(PublicVars.currentRoom).transform.GetChild(0);
    //     roomCheck = PublicVars.currentRoom;
    // }
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
        this.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(.7f);
        this.transform.GetChild(0).gameObject.SetActive(true);
    }
}
