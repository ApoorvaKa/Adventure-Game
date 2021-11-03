using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTheWay : MonoBehaviour
{
    public GameObject solidBody;
    public GameObject transparentBody;
    // Start is called before the first frame update
    void Awake()
    {
        ShowSolid();
    }

    // Update is called once per frame
    public void ShowTransparent()
    {
        solidBody.SetActive(false);
        transparentBody.SetActive(true);
    }

    public void ShowSolid()
    {
        solidBody.SetActive(true);
        transparentBody.SetActive(false);
    }
}
