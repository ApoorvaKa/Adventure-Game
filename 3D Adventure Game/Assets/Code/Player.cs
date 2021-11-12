using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Camera mainCam;


    //health system
    public Text lifet;

    //audio
    AudioSource _audioSource;
    public AudioClip keyPickUpSnd;
    // clown explosion sound
    public AudioClip explodeSnd;

    //health system
    
    public Image[] hearts;
    public Sprite fHeart;
    public Sprite eHeart;
    
    //hurt effect(not finished)
    //public GameObject hurt;
    
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        //music effect
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // player movement wrapped in pause check to make sure 
        // player does not move when resume button is clicked
        if(PublicVars.paused == false){
            if(Input.GetMouseButtonDown(0)){
                RaycastHit hit;
                if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)){
                    _navMeshAgent.destination = hit.point;
                }
            }

            //health system
            if (PublicVars.life > PublicVars.numHearts){
                PublicVars.life = PublicVars.numHearts;
            }
            for (int i = 0; i < hearts.Length; i++){
                if (i < PublicVars.life){
                    hearts[i].sprite = fHeart;
                }
                else{
                    hearts[i].sprite = eHeart;
                }

                if (i >=  PublicVars.numHearts){
                    hearts[i].enabled = false;
                } else {
                    hearts[i].enabled = true;
                }
            }
        }
    }
    void OnTriggerEnter(Collider other) {
        print("key collected");
        if (other.gameObject.CompareTag("Key")){
            _audioSource.PlayOneShot(keyPickUpSnd);
            Destroy(other.gameObject);
            PublicVars.numKeys++;
        }
        if(other.gameObject.name =="GreenKey"){
            _audioSource.PlayOneShot(keyPickUpSnd);
            Destroy(other.gameObject);
            PublicVars.greenKey = true;
        }
        if(other.gameObject.name =="BlueKey"){
            _audioSource.PlayOneShot(keyPickUpSnd);
            Destroy(other.gameObject);
            PublicVars.blueKey = true;
        }
        if(other.gameObject.name =="RedKey"){
            _audioSource.PlayOneShot(keyPickUpSnd);
            Destroy(other.gameObject);
            PublicVars.redKey = true;
        }
        if(other.CompareTag("Trap")){
            PublicVars.life --;
        }
        if (other.CompareTag("Monster")){
            _audioSource.PlayOneShot(explodeSnd);

        }
        StartCoroutine(_wait());
    }

    IEnumerator _wait() {
        yield return new WaitForSeconds(.7f);
    }
}
