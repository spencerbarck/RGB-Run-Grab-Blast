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
        transform.position = startingPosition;
    }

    public void PlayAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
