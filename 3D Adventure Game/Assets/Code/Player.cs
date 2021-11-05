using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Camera mainCam;
    
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)){
                _navMeshAgent.destination = hit.point;
            }
        }
    }
    void OnTriggerEnter(Collider other) {
        print("key collected");
        if (other.gameObject.CompareTag("Key")){
            Destroy(other.gameObject);
            PublicVars.numKeys++;
        }
        if(other.gameObject.name =="GreenKey"){
            Destroy(other.gameObject);
            PublicVars.greenKey = true;
        }
        if(other.gameObject.name =="BlueKey"){
            Destroy(other.gameObject);
            PublicVars.blueKey = true;
        }
        if(other.gameObject.name =="RedKey"){
            Destroy(other.gameObject);
            PublicVars.redKey = true;
        }
        wait();
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(.7f);
    }
}
