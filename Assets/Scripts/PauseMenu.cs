using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseM;
    public GameObject SettingsM;
    public static bool paused = false;
    public TMP_Dropdown resolutiondropdown;
    private Resolution[] resolutions;
    void Start()
    {
        PauseM.SetActive(false);
        SettingsM.SetActive(false);
        
        resolutions = Screen.resolutions;
        resolutiondropdown. ClearOptions();
        List<string> options = new List<string>();
        int resindex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resindex = i;
            }
        }
        resolutiondropdown. AddOptions(options);
        resolutiondropdown.value = resindex;
        resolutiondropdown.RefreshShownValue();
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
        SettingsM.SetActive(false);
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

    public void Back()
    {
        SettingsM.SetActive(false);
        PauseM.SetActive(true);
    }

    public void SetResolution(int resindex)
    {
        Resolution res = resolutions[resindex];
        Screen.SetResolution(res.width, res.height,Screen.fullScreen);
    }
}
