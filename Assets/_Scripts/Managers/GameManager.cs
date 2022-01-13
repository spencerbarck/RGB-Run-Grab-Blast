using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Color playerColor;
    public PlayerStats PlayerStats;
    public PlayerCollision PlayerCollision;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance=this;
    }
}
