using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryUI : MonoBehaviour
{
    private bool isContinue = false;
    private bool isShown = false;
    private void Start()
    {
        GetComponent<Canvas>().enabled=false;
    }
    private void Update()
    {
        if((WaveManager.instance.WaveNumber>1)&&(!isContinue)&&(!isShown))
        {
            ToggleVisible();
        }
    }
    private void ToggleVisible()
    {
        isShown=true;
        GetComponent<Canvas>().enabled=true;
        Time.timeScale = 0f;
    }
    public void NavigateMenu()
    {
        Time.timeScale = 1f;
        SoundManager.instance.StopSound("BetweenWaveMusic");
        SoundManager.instance.StopSound("WaveStartMusic1");
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }
    public void Continue()
    {
        GetComponent<Canvas>().enabled=false;
        Time.timeScale = 1f;
    }
}
