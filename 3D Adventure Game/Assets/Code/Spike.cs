using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public void Shoot()
    {
        Vector3 cur = this.transform.position;
        transform.position = new Vector3(cur.x, cur.y + 0.7f, cur.z);
        //if (cur.y < 0f)
        // {
        //     StartCoroutine(_Wait());
            
        // }

    }

    IEnumerator _Wait(){
        //Vector3 cur = this.transform.position;
        yield return new WaitForSeconds(1f);
        //this.transform.localPosition += (Vector3.up * 0.7f);
        //this.transform.Position = new Vector3(cur.x,cur.y + 0.7f, cur.z);
    } 

    public void Retract()
    {
        // if (this.transform.localPosition.y > 0f)
        // {
        //     StartCoroutine(_Off());
        // }
        Vector3 cur = this.transform.position;
        transform.position = new Vector3(cur.x, cur.y - 0.7f, cur.z);
        // if (cur.y > 0f)
        // {
        //     StartCoroutine(_Wait());
            
        // }
    }

    IEnumerator _Off(){
        Vector3 cur = this.transform.position;
        yield return new WaitForSeconds(1f);
        //this.transform.localPosition += (Vector3.up * 0.7f);
        //this.transform.Position = new Vector3(cur.x,cur.y -0.7f, cur.z);
    } 

}
