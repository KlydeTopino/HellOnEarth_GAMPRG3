using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public List<GameObject> obstacles;
    public float Radius = 1;
    public int MaxSpawnCount = 5;
    private int SpawnCount = 0;

    void Update()
    {
        while (SpawnCount < MaxSpawnCount)
        {
            Vector3 randomPos = Random.insideUnitCircle * Radius;
            Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Count)], randomPos, Quaternion.identity);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }
}
