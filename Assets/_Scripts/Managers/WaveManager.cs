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
    [HideInInspector]
    public int[] EnemiesInWave = {15,16,17,20,25,27,30,35,27,40};
    public int PickupsInWave = 17;
    [HideInInspector]
    public float[] EnemyColorInWave = {0f,0.25f,0.5f,.75f,1f,1.25f,1.5f,1.75f,2f,2.5f};
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
        if(GameManager.instance.PlayerStats.Health+
            GameManager.instance.PlayerStats.Damage+
            GameManager.instance.PlayerStats.Speed>640)
        {
            PickupsInWave=0;
        }

        SoundManager.instance.PlaySound("WaveStart");
        SoundManager.instance.StopSound("StartMenuMusic");
        SoundManager.instance.StopSound("BetweenWaveMusic");
        SoundManager.instance.PlaySound("WaveStartMusic1");

        FindObjectOfType<PlayerCollision>().MaxOutHealth();

        WaveNumber++;

        if(WaveNumber<=EnemiesInWave.Length)
            EnemiesLeftInWave = EnemiesInWave[WaveNumber-1];
        else
            EnemiesLeftInWave = (WaveNumber-1)*4+5;

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
        SoundManager.instance.PlaySound("WaveEnd");
        SoundManager.instance.StopSound("WaveStartMusic1");
        SoundManager.instance.PlaySound("BetweenWaveMusic");
    }
}
