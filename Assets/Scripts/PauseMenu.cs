using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseM;
    public GameObject SettingsM;
    public static bool paused = false;
    void Start()
    {
        PauseM.SetActive(false);
        SettingsM.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!paused){
                Pause();
            }
            else
            {
                UnPause();
            }
        }
        
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseM.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void UnPause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseM.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        Time.timeScale = 1f;
        paused = false;
    }

    public void Settings()
    {
        SettingsM.SetActive(true);
        PauseM.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Quit()
    {
        Debug.LogWarning("Quit");
        Application.Quit();
    }
}
