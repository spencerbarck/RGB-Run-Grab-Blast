using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickRGBUI : MonoBehaviour
{
    [SerializeField]
    private Transform transformR;
    [SerializeField]
    private Transform transformG;
    [SerializeField]
    private Transform transformB;
    [SerializeField]
    private WaveButton waveButton;
    private Vector3 startingPositionR;
    private Vector3 startingPositionG;
    private Vector3 startingPositionB;

    public delegate void ColorPickEvent();
    public event ColorPickEvent colorPickEvent;
    void Start()
    {
        startingPositionR = transformR.position;
        startingPositionG = transformG.position;
        startingPositionB = transformB.position;

        waveButton.pressEvent += ShowButtons;
        MoveButtonsAway();
    }
    public void ChosenColor(string rGOrB)
    {
        switch(rGOrB)
        {
        case "r":
            WaveManager.instance.PickupColorChoice = Color.red;
            break;
        case "g":
            WaveManager.instance.PickupColorChoice = Color.green;
            break;
        case "b":
            WaveManager.instance.PickupColorChoice = Color.blue;
            break;
        default:
            break;
        }
        MoveButtonsAway();
        FindObjectOfType<PlayerShooter>().enabled = true;
        colorPickEvent.Invoke();
        if(!GameManager.instance.BattleStarted)GameManager.instance.StartBattle();
        GameManager.instance.StartBattleUI();
    }

    public void MoveButtonsAway()
    {
        FindObjectOfType<PlayerShooter>().enabled = false;
        transformR.position = new Vector3(transformR.position.x+-10000f,transformR.position.y,transformR.position.z);
        transformG.position = new Vector3(transformG.position.x,transformG.position.y+10000f,transformG.position.z);
        transformB.position = new Vector3(transformB.position.x+10000f,transformB.position.y+10000f,transformB.position.z);
    }

    public void ShowButtons()
    {  
        FindObjectOfType<PlayerShooter>().enabled = false;
        transformR.position = startingPositionR;
        transformG.position = startingPositionG;
        transformB.position = startingPositionB;
    }
}
