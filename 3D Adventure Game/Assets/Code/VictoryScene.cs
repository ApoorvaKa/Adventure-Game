using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScene : MonoBehaviour
{
    public GameObject quitButton;
    void Start()
    {   
        #if UNITY_WEBGL
            quitButton.SetActive(false);
        #endif
        #if UNITY_EDITOR
            quitButton.SetActive(false);
        #endif
    }

    public void RestartGame(){
        SceneManager.LoadScene("TitleScreen");
        PublicVars.greenKey = false;
        PublicVars.redKey = false;
        PublicVars.blueKey = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
