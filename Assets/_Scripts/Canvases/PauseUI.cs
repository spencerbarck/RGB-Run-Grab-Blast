using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    private bool isVisible = false;
    [SerializeField]
    private Slider volumeSlider;
    private void Awake()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }
    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        GetComponent<Canvas>().enabled=false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))ToggleVisible();
    }
    public void ToggleVisible()
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
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
}
