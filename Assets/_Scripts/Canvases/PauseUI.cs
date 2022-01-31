using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    private bool isVisible = false;
    private void Start()
    {
        GetComponent<Canvas>().enabled=false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))ToggleVisible();
    }
    private void ToggleVisible()
    {
        if(isVisible)
        {
            GetComponent<Canvas>().enabled=false;
            isVisible = false;
            Time.timeScale = 1f;
        }
        else 
        {
            GetComponent<Canvas>().enabled=true;
            isVisible = true;
            Time.timeScale = 0f;
        }
    }
    public void NavigateMenu()
    {
        Time.timeScale = 1f;
        SoundManager.instance.StopSound("BetweenWaveMusic");
        SoundManager.instance.StopSound("WaveStartMusic1");
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }
}
