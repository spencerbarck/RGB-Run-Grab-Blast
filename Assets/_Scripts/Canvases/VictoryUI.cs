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
        GameManager.instance.lastKillEvent += ToggleVisible;
    }
    private void Update()
    {
        if(isShown)SoundManager.instance.StopSound("BetweenWaveMusic");
    }
    private void ToggleVisible()
    {
        if((WaveManager.instance.WaveNumber==10)&&(!isContinue)&&(!isShown))
        {
            SoundManager.instance.PlaySound("VictoryMusic");
            SoundManager.instance.StopSound("BetweenWaveMusic");
            SoundManager.instance.StopSound("BetweenWaveMusic");
            SoundManager.instance.StopSound("WaveStartMusic1");
            isShown=true;
            GetComponent<Canvas>().enabled=true;
            Time.timeScale = 0f;
        }
    }
    public void NavigateMenu()
    {
        Time.timeScale = 1f;
        SoundManager.instance.StopSound("VictoryMusic");
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
        isShown=false;
    }
    public void Continue()
    {
        SoundManager.instance.PlaySound("BetweenWaveMusic");
        SoundManager.instance.StopSound("VictoryMusic");
        GetComponent<Canvas>().enabled=false;
        isShown=false;
        Time.timeScale = 1f;
    }
    
}
