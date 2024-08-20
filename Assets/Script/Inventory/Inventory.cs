using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public InventoryItem itemHealth;
    public InventoryItem itemPower;
    public InventoryItem itemKey;
    public InventoryItem itemStone;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        InitializeInventoryItems();
    }

    //void Start()
    //{
    //    itemHealth = new InventoryItem();
    //    itemPower = new InventoryItem();
    //    itemKey = new InventoryItem();
    //    itemStone = new InventoryItem();
    //}
    public void InitializeInventoryItems()
    {
        if (itemHealth == null) itemHealth = new InventoryItem();
        if (itemPower == null) itemPower = new InventoryItem();
        if (itemKey == null) itemKey = new InventoryItem();
        if (itemStone == null) itemStone = new InventoryItem();
        itemStone.stack = 10;
    }
    private void Start()
    {
        InitializeInventoryItems();
    }
    void Update()
    {

    }


}
