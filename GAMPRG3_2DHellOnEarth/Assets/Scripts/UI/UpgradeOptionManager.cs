using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeOptionManager : MonoBehaviour
{
    public List<GameObject> upgrades;
    
    void CreateOptions(List<GameObject> upgradeList)
    {
        for (int i = 0; i < upgradeList.Count; i++)
        {
            GameObject temp = upgradeList[i];
            int rand = Random.Range(i, upgradeList.Count);
            upgradeList[i] = upgradeList[rand];
            upgradeList[rand] = temp;
        }

        for (int i = 0; i < 3; i++)
        {
            Instantiate(upgradeList[i], transform);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)) 
        {
            CreateOptions(upgrades);
        }
    }
    public void RemoveUpgradeOptions()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
