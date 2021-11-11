using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWarpPlate : MonoBehaviour
{
    public string key;
    public GameObject warpPlate;
    void Start()
    {
        warpPlate.SetActive(false);
    }
    void FixedUpdate()
    {
        if(GameObject.Find(key) == null)
        {
            warpPlate.SetActive(true);
        }   
    }
}
