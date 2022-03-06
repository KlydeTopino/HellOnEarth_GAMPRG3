using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public DestructibleItems item;
    public List<GameObject> lootTable;
    public int[] dropRatePerLoot; 
    public Transform player;
    public SpriteRenderer spriteRenderer;
    public Sprite openedSprite;
    public int dropChance;
    public bool dropOnDestroy, isDropRateEqual;
    private int RandomNum;
    
    private int LootNum;
    private int LootTotal;
    private bool IsLooted = false;
    // Start is called before the first frame update
    void Start()
    {
        item = gameObject.GetComponent<DestructibleItems>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        LootTotal = lootTable.Count;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 distanceToPlayer = player.position - transform.position;
        if(item.itemHealth <= 0 && !IsLooted && dropOnDestroy)
        {
            Drop();
        }
        else if (distanceToPlayer.magnitude <= 0.2 && !dropOnDestroy && Input.GetKeyDown(KeyCode.E) && !IsLooted)
        {
            Drop();
            spriteRenderer.sprite = openedSprite;
        }
    }

    void Drop()
    {
        RandomNum = Random.Range(0, 101);
        LootNum = Random.Range(0, LootTotal);
        if(RandomNum <= dropChance)
        {
            if(isDropRateEqual)
            Instantiate(lootTable[LootNum], transform.position, transform.rotation);
            else
            {
                Instantiate(lootTable[LootNum], transform.position, transform.rotation);
            }
            
        }
        IsLooted = true;
    }

}
