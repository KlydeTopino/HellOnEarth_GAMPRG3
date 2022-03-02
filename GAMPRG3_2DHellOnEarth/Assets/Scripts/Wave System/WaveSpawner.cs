
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
    [SerializeField] public Wave[] WavesNumber;
    public Transform[] SpawnPoints;
    public Animator WaveAnimator;
    public Text WaveName;

    private Wave CurrentWave;
    private int CurrentWaveNumber;
    private float SpawnTime;

    private bool WillSpawn = true;
    private bool WillAnimate = false;


    private void Update()
    {
        CurrentWave = WavesNumber[CurrentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0)
        {
            if (CurrentWaveNumber + 1 != WavesNumber.Length)
            {
                if (WillAnimate)
                {
                    WaveName.text = WavesNumber[CurrentWaveNumber + 1].WaveName;
                    WaveAnimator.SetTrigger("WaveComplete");
                    WillAnimate = false;
                }

            }
            else
            {
                Debug.Log("GameFinish");
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
                WillAnimate = true;
            }
        }
    }
}
