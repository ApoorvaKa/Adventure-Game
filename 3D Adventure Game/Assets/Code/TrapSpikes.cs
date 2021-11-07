using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpikes : MonoBehaviour
{

    public List<Spike> ListSpikes = new List<Spike>();
    float fixedtime = 2f;
    float _time;
    void Start()
    {
        ListSpikes.Clear();
        Spike[] arr = this.gameObject.GetComponentsInChildren<Spike>();
        foreach (Spike s in arr)
        {
            ListSpikes.Add(s);
        }
        StartCoroutine(SpikeTrigger());
        _time = 0f;
    }

    void Update()
    {
        _time += Time.deltaTime;
        while(_time >= fixedtime) {
            StartCoroutine(SpikeTrigger());
            _time -= fixedtime;
        }
        
    }

    IEnumerator SpikeTrigger(){
        foreach(Spike s in ListSpikes)
        {
            s.Shoot();
        }

        yield return new WaitForSeconds(1f);
        
        foreach (Spike s in ListSpikes)
        {
            s.Retract();
        }

        yield return new WaitForSeconds(1f);
    }
}

