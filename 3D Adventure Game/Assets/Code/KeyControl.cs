using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyControl : MonoBehaviour
{
    
    public Image greenKey;
    public Image greenKeyT;
    public Image redKey;
    public Image redKeyT;
    public Image blueKey;
    public Image blueKeyT;

    public Text keyCount;

    void Start()
    {
        
    }

    void Update()
    {
        if(PublicVars.greenKey)
        {
            greenKeyT.gameObject.SetActive(false);
            greenKey.gameObject.SetActive(true);
        } else{
            greenKeyT.gameObject.SetActive(true);
            greenKey.gameObject.SetActive(false);
        }
        if(PublicVars.redKey)
        {
            redKeyT.gameObject.SetActive(false);
            redKey.gameObject.SetActive(true);
        } else{
            redKeyT.gameObject.SetActive(true);
            redKey.gameObject.SetActive(false);
        }
        if(PublicVars.blueKey)
        {
            blueKeyT.gameObject.SetActive(false);
            blueKey.gameObject.SetActive(true);
        } else{
            blueKeyT.gameObject.SetActive(true);
            blueKey.gameObject.SetActive(false);
        }
        keyCount.text = PublicVars.numKeys.ToString();
        }
}
