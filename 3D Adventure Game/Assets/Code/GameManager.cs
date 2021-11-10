using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject quitButton;


    // Start is called before the first frame update
    void Start()
    {
        Resume();
        
        #if UNITY_WEBGL
        quitButton.SetActive(false);
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (PublicVars.paused){
                Resume();

            }
            else{
                pauseMenu.SetActive(true);
                PublicVars.paused = true;
                Time.timeScale = 0;
            }
        }
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        PublicVars.paused = false;
        Time.timeScale = 1;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit(){
        Application.Quit();
        print("Quit called");
    }

}
