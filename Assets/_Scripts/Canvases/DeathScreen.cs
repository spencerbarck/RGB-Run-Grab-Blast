using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    private Vector3 startingPosition;
    void Start()
    {
        startingPosition = transform.position;
        transform.position = new Vector3(transform.position.x,transform.position.y+900f,transform.position.z);
    }

    public void ShowDeathScreen()
    {
        Vector3 startPosition = FindObjectOfType<CameraManager>().transform.position;
        transform.position = new Vector3(startPosition.x,startPosition.y,1);
    }

    public void PlayAgain()
    {
        SoundManager.instance.StopSound("DeathMusic");
        SoundManager.instance.PlaySound("BetweenWaveMusic");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
