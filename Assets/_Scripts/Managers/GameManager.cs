using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Color playerColor;
    public PlayerStats PlayerStats;
    public PlayerCollision PlayerCollision;
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

    public void AddEnemies(int enemies)
    {
        enemyCount += enemies;
    }
    public void RemoveEnemy()
    {
        enemyCount --;
    }
}
