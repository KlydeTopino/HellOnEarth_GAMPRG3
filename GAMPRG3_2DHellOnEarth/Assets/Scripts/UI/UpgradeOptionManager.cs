using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeOptionManager : MonoBehaviour
{
    public List<GameObject> upgrades;
    public WaveSpawner spawner;
    
    public void CreateOptions()
    {
        for (int i = 0; i < upgrades.Count; i++)
        {
            GameObject temp = upgrades[i];
            int rand = Random.Range(i, upgrades.Count);
            upgrades[i] = upgrades[rand];
            upgrades[rand] = temp;
        }

        for (int i = 0; i < 3; i++)
        {
            Instantiate(upgrades[i], transform);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)) 
        {
            CreateOptions();
        }
    }
    public void RemoveUpgradeOptions()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
            spawner.ChoosingUpgrades = false;
            spawner.WaveAnimator.SetBool("Choosing Upgrades", false);
        }
    }
}
