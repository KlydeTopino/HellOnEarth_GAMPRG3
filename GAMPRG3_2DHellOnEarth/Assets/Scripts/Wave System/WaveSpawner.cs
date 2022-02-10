using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Wave
{
    public string WaveName;
    public int EnemyCounter;
    public GameObject[] EnemyTypes;
    public float SpawnInterval;
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] WavesNumber;
    public Transform[] SpawnPoints;

    private Wave CurrentWave;
    private int CurrentWaveNumber;
    private float SpawnTime;

    private bool WillSpawn = true;
    private bool WillAnimate = false;


    public Animator WaveAnimator;
    public Text WaveName;

    // Update is called once per frame
    private void Update()
    {
        CurrentWave = WavesNumber[CurrentWaveNumber];
        SpawnWave();

        GameObject[] TotalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (TotalEnemies.Length == 0)
        {
            if (CurrentWaveNumber + 1 != WavesNumber.Length)
            {
                if (WillAnimate)
                {
                    WaveName.text = WavesNumber[CurrentWaveNumber + 1].WaveName;
                    WaveAnimator.SetTrigger("Wave Complete");
                    WillAnimate = false;
                }
            }
            else
            {
                Debug.Log("Game Finished");
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
            GameObject RandomEnemy = CurrentWave.EnemyTypes[Random.Range(0, CurrentWave.EnemyTypes.Length)];
            Transform RandomSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];

            Instantiate(RandomEnemy, RandomSpawnPoint.position, Quaternion.identity);
            CurrentWave.EnemyCounter--;
            SpawnTime = Time.time + CurrentWave.SpawnInterval;

            if(CurrentWave.EnemyCounter == 0)
            {
                WillSpawn = false;
            }
        }
        
       
    }
}
