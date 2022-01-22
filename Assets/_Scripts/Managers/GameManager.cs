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
    public WaveButton waveButton;
    [SerializeField]
    private EnemiesLeftCount enemiesLeftCount;
    [SerializeField]
    private DeathScreen deathScreen;
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
        //waveButton.pressEvent += StartBattle;
    }

    public void StartBattle()
    {
        //waveButton.pressEvent -= StartBattle;
        
        //Update UI
        enemiesLeftCount.ShowCount();

        //Set Player Stats
        playerColor = PlayerStats.circleSpriteRenderer.color;

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
    public void Death()
    {
        deathScreen.ShowDeathScreen();
    }
}
