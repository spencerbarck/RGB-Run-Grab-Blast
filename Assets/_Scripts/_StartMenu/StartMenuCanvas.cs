using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartMenuCanvas : MonoBehaviour
{
    [SerializeField]
    private TMP_Text[] title;
    private float textColorTime = 1f;
    private float textColorTimer = 1f;
    private int redHead = 0;
    private int greenHead = 5;
    private int blueHead = 11;
    private void Update()
    {
        textColorTimer -= Time.deltaTime;
        
        if (textColorTimer <= 0.0f)
        {
            CycleColor(title[redHead]);
            CycleColor(title[greenHead]);
            CycleColor(title[blueHead]);

            textColorTimer = textColorTime;

            if(redHead==title.Length-1)redHead=0;
            else redHead++;
            if(greenHead==title.Length-1)greenHead=0;
            else greenHead++;
            if(blueHead==title.Length-1)blueHead=0;
            else blueHead++;
        }
    }
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
    private void CycleColor(TMP_Text character)
    {
        if(character.color.r>0f) character.color = Color.blue;
        else if(character.color.g>0f) character.color = Color.red;
        else character.color = Color.green;
    }
}
