using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown : MonoBehaviour
{
    GameObject player;
    public float move = 0.02f;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, move);
        transform.LookAt(player.transform);
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            Destroy(this.gameObject);
            PublicVars.life--;
        }
    }
}
