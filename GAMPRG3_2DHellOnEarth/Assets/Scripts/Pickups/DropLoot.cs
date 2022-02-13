using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public DestructibleItems item;
    public int dropChance;
    private int RandomNum;
    public List<GameObject> lootTable;
    private int LootNum;
    private int LootTotal;
    private bool IsDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        item = gameObject.GetComponent<DestructibleItems>();
        LootTotal = lootTable.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if(item.itemHealth <= 0 && !IsDestroyed)
        {
            RandomNum = Random.Range(0, 101);
            LootNum = Random.Range(0, LootTotal);
            if(RandomNum <= dropChance)
            {
                Instantiate(lootTable[LootNum], transform.position, transform.rotation);
            }
            IsDestroyed = true;
        }
    }
}
