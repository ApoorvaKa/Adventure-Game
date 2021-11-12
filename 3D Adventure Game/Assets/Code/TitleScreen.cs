using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
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
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("Hub");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
