using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    public string WaveName;
    public int EnemyCounter;
    public int ObstacleCounter;
    public GameObject[] EnemyTypes;
    public GameObject[] ObjectTypes;
    public float SpawnInterval;
}

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] public Wave[] WavesNumber;
    public Transform[] SpawnPoints;
    public List<Transform> ObstacleSpawnPoints;
    private List<Transform> TempObstacleSpawnPoints;
    public Animator WaveAnimator;
    public Text WaveName;
    public GameObject UpgradesUI;
    public UpgradeOptionManager UpgradeOptions;
    
    public int[] UpgradeWaves;
    public int[] LightSwtichOff;
    public int[] LightSwtichOn;
    public int[] RandomObstacle;

    private Wave CurrentWave;
    private int CurrentWaveNumber;
    private float SpawnTime;

    private bool WillSpawn = true;
    private bool WillAnimate = false;
    public bool ChoosingUpgrades = false;
    private bool CreatedUpgrades = false;

    public GameObject Light;
    private bool On = false;

    public GameObject TheEnd;
    public GameObject HealthHud;

    private void Update()
    {
        CurrentWave = WavesNumber[CurrentWaveNumber];
        if(!ChoosingUpgrades)
        {
            TempObstacleSpawnPoints = new List<Transform>(ObstacleSpawnPoints);
            SpawnWave();
            GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (totalEnemies.Length == 0)
            {
                if (CurrentWaveNumber + 1 != WavesNumber.Length)
                {
                    if (WillAnimate)
                    {
                        WaveName.text = WavesNumber[CurrentWaveNumber + 1].WaveName;
                        foreach (int waveNum in UpgradeWaves)
                        {
                            if (waveNum == CurrentWaveNumber+1)
                            {
                                WaveAnimator.SetBool("Choosing Upgrades", true);
                                ChoosingUpgrades = true;
                            }
                        }
                        foreach (int WaveNum in LightSwtichOff)
                        {
                            if (WaveNum == CurrentWaveNumber + 1 && !On)
                            {
                                Light.SetActive(false);

                            }
                        }
                        foreach (int WaveNum in LightSwtichOn)
                         {
                            if (WaveNum == CurrentWaveNumber + 1 && !On)
                             {
                               Light.SetActive(true);
                             }
                          
                        }
                        foreach (int WaveNum in RandomObstacle)
                        {
                            if (WaveNum == CurrentWaveNumber + 1)
                            {
                                for (int i = CurrentWave.ObstacleCounter; CurrentWave.ObstacleCounter > 0; CurrentWave.ObstacleCounter--)
                                SpawnObstacle();
                            }

                        }

                        Debug.Log("Current Wave: " + CurrentWaveNumber);
                        WaveAnimator.SetTrigger("WaveComplete");
                        if(ChoosingUpgrades) ShowUpgrades();
                        WillAnimate = false;
                    }

                }
                else
                {
                    Debug.Log("GameFinish");
                    TheEnd.SetActive(true);
                    HealthHud.SetActive(false);
                }
            }
        }   
    }

    void SpawnNextWave()
    {
        CurrentWaveNumber++;
        WillSpawn = true;
    }

    void SpawnWave()
    {
        if (WillSpawn && SpawnTime < Time.time)
        {
            CreatedUpgrades = false;
            Debug.Log("Current Wave: " + CurrentWaveNumber);
            GameObject RandomEnemy = CurrentWave.EnemyTypes[Random.Range(0, CurrentWave.EnemyTypes.Length)];
            Transform RandomSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];

            Instantiate(RandomEnemy, RandomSpawnPoint.position, Quaternion.identity);
            CurrentWave.EnemyCounter--;
            SpawnTime = Time.time + CurrentWave.SpawnInterval;

            if(CurrentWave.EnemyCounter == 0)
            {
                WillSpawn = false;
                WillAnimate = true;
            }
        }
    }

    void SpawnObstacle()
    {
        GameObject RandomObstacle = CurrentWave.ObjectTypes[Random.Range(0, CurrentWave.ObjectTypes.Length)];
        int RandomObstacleSpawnPoint = Random.Range(0, TempObstacleSpawnPoints.Count);

        Instantiate(RandomObstacle, TempObstacleSpawnPoints[RandomObstacleSpawnPoint].position, Quaternion.identity);
        TempObstacleSpawnPoints.RemoveAt(RandomObstacleSpawnPoint);

    }
    
    void ShowUpgrades()
    {
        ChoosingUpgrades = true;

        if(!CreatedUpgrades) 
        {   
            UpgradesUI.SetActive(true);
            UpgradeOptions.CreateOptions();
            CreatedUpgrades = true;
        }
    }
}
