using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    [SerializeField]
    private WaveButton waveButton;
    public int WaveNumber = 0;
    public int[] EnemiesInWave;
    public int[] EnemyColorInWave;
    private EnemySpawner[] enemySpawners;
    private PickupSpawner[] pickupSpawners;
    public bool WaveStarted;
    public Color PickupColorChoice = Color.red;
    private void Awake()
    {
        if(WaveManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance=this;
    }

    private void Start()
    {
        waveButton.pressEvent += WaveStart;
        GameManager.instance.lastKillEvent += WaveEnd;

        enemySpawners = FindObjectsOfType<EnemySpawner>();
        pickupSpawners = FindObjectsOfType<PickupSpawner>();
    }
    private void WaveStart()
    {
        WaveNumber++;
        if(GameManager.instance.BattleStarted)
        {
            foreach(EnemySpawner enemySpawner in enemySpawners)
            {
                enemySpawner.StartSpawning();
            }
        }
    }

    private void WaveEnd()
    {
    }
}
