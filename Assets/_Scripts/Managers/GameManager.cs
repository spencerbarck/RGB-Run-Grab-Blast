using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Color playerColor;
    public PlayerStats PlayerStats;
    public PlayerCollision PlayerCollision;
    public int enemyCount { get; private set; }  = 0;
    private bool battleStart = false;
    [SerializeField]
    private WaveButton waveButton;
    [SerializeField]
    private EnemiesLeftCount enemiesLeftCount;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance=this;
    }

    void Start()
    {
        waveButton.pressEvent += StartBattle;
    }

    private void StartBattle()
    {
        Debug.Log("BATTLE");
        enemiesLeftCount.ShowCount();
        if(!battleStart) battleStart = true;
    }

    public void AddEnemies(int enemies)
    {
        enemyCount += enemies;
        waveButton.pressEvent -= StartBattle;
    }
    public void RemoveEnemy()
    {
        enemyCount --;
    }
}
