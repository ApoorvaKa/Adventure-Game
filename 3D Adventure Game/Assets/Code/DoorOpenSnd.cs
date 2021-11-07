using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenSnd : MonoBehaviour
{
    
    //audio
    static AudioSource _audioSource;
    static AudioClip OpenSnd;

    // Update is called once per frame
    public static void Sound()
    {
        _audioSource.PlayOneShot(OpenSnd);
    }
}
