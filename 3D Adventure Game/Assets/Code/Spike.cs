using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public void Shoot()
    {
        Vector3 cur = this.transform.position;
        transform.position = new Vector3(cur.x, cur.y + 0.7f, cur.z);
    }


    public void Retract()
    {
        Vector3 cur = this.transform.position;
        transform.position = new Vector3(cur.x, cur.y - 0.7f, cur.z);
    }

}
