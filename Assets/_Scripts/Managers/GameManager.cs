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
    private WaveNumberUI waveNumberUI;
    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private DeathScreen deathScreen;
    //
    //Values
    public bool BattleStarted = false;
    public Color PlayerColor;
    public int EnemyCount = 0;

    public delegate void LastKillEvent();
    public event LastKillEvent lastKillEvent;
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
        InitPlayerStats();
    }
    public void InitPlayerStats()
    {
        PlayerCollision.SetPlayerHealth();
        healthBar.SetMax();
        PlayerMover.SetPlayerSpeed();
    }
    public void ChangePlayerStats(float healthIncrease)
    {
        if(healthIncrease >0)
        {
            PlayerCollision.IncreaseHealth(healthIncrease);
            healthBar.SetMax();
        }
        PlayerMover.SetPlayerSpeed();
    }
    public void StartBattle()
    {
        if(BattleStarted==false)
        {
            BattleStarted = true;

            //Set Player Stats
            PlayerColor = PlayerStats.circleSpriteRenderer.color;

            InitPlayerStats();
            StartBattleUI();
        }
    }
    public void StartBattleUI()
    {
        //Update UI
        enemiesLeftCount.ShowCount();
        waveNumberUI.ShowCount();
    }
    public void AddEnemies(int enemies)
    {
        EnemyCount += enemies;
    }
    public void RemoveEnemy()
    {
        EnemyCount --;
        if(EnemyCount==0)lastKillEvent.Invoke();
    }
    public void DisplayDeath()
    {
        deathScreen.ShowDeathScreen();
    }
}
