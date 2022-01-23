using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //References
    //
    //Player Stats
    public PlayerStats PlayerStats;
    public PlayerCollision PlayerCollision;
    public PlayerMover PlayerMover;
    //UI
    [SerializeField]
    public WaveButton waveButton;
    [SerializeField]
    private EnemiesLeftCount enemiesLeftCount;
    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private DeathScreen deathScreen;
    //

    //Values
    public Color PlayerColor;
    public int enemyCount { get; private set; }  = 0;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance=this;
    }

    private void Start()
    {
        SetPlayerStats();
    }
    private void SetPlayerStats()
    {
        PlayerCollision.SetPlayerHealth();
        healthBar.SetMax();
        PlayerMover.SetPlayerSpeed();
    }
    public void StartBattle()
    {
        //Update UI
        enemiesLeftCount.ShowCount();

        //Set Player Stats
        PlayerColor = PlayerStats.circleSpriteRenderer.color;

        SetPlayerStats();
    }
    public void AddEnemies(int enemies)
    {
        enemyCount += enemies;
    }
    public void RemoveEnemy()
    {
        enemyCount --;
    }
    public void DisplayDeath()
    {
        deathScreen.ShowDeathScreen();
    }
}
