using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    [SerializeField]
    //private WaveButton waveButton;
    private PickRGBUI pickRGB;
    public int WaveNumber = 0;
    public int LastWave = 10;
    public int[] EnemiesInWave = {10,10,10,10,12,15,17,20,25,30};
    public int PickupsInWave = 51;
    public float[] EnemyColorInWave = {0f,0.1f,0.2f,0.3f,0.4f,0.5f,0.6f,0.7f,0.8f,0.9f};
    private EnemySpawner[] enemySpawners;
    private PickupSpawner[] pickupSpawners;
    public bool WaveStarted;
    public Color PickupColorChoice = Color.red;
    public int EnemiesLeftInWave = 0;
    public int PickupsLeftInWave = 0;
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
        PickupsLeftInWave = PickupsInWave;
        pickRGB.colorPickEvent += WaveStart;
        //waveButton.pressEvent += WaveStart;
        GameManager.instance.lastKillEvent += WaveEnd;

        enemySpawners = FindObjectsOfType<EnemySpawner>();
        pickupSpawners = FindObjectsOfType<PickupSpawner>();
    }
    private void WaveStart()
    {

        WaveNumber++;
        EnemiesLeftInWave = EnemiesInWave[WaveNumber-1];
        PickupsLeftInWave = PickupsInWave;

        List<PickupSpawner> spawnList = new List<PickupSpawner>();
        foreach(PickupSpawner pS in pickupSpawners)
            spawnList.Add(pS);
        
        PickupSpawner[] spawnArray = spawnList.ToArray();
        for (int i = 0; i < spawnList.Count; i++) 
        {
            int rand = Random.Range (0, spawnList.Count);
            PickupSpawner temp = spawnArray[rand];
            spawnArray[rand] = spawnArray[i];
            spawnArray[i] = temp;
        }

        foreach(PickupSpawner pickupSpawner in spawnArray)
        {
            pickupSpawner.SpawnObject(pickupSpawner.transform.position);
        }

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
