using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryDoor : MonoBehaviour
{
    public string scene;
    public GameObject redLock;
    public GameObject blueLock;
    public GameObject greenLock;
    bool doorOpen;

    void Start()
    {
        doorOpen = false;
    }

    void FixedUpdate()
    {
        if(PublicVars.redKey)
        {
            redLock.SetActive(false);
        }
        if(PublicVars.blueKey)
        {
            blueLock.SetActive(false);
        }
        if(PublicVars.greenKey)
        {
            greenLock.SetActive(false);
        }
        if(!redLock.activeSelf && !blueLock.activeSelf && !greenLock.activeSelf)
        {
            doorOpen = true;
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player" && doorOpen)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
