using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseBtn;
    public GameObject quitButton;

    // Start is called before the first frame update
    void Start()
    {
        Resume();
        
        #if UNITY_WEBGL
            quitButton.SetActive(false);
        #endif

        #if UNITY_EDITOR
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
                Pause();
            }
        }
    }

    public void Pause()
    {
        PublicVars.paused = true;
        Time.timeScale = 0;
        pauseBtn.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        PublicVars.paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseBtn.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
