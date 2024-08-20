using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    public float value;
    public string type;
    public Rigidbody2D rb;
    private Collider2D col;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void OnValidate()
    {
        if (itemData == null)
            return;

        GetComponent<SpriteRenderer>().sprite = itemData.itemIcon;
        gameObject.name = itemData.itemName;
        value = itemData.value;
        type = itemData.itemType.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            TryAddItemToInventory();
        }
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
    //    {
    //        if (gameObject.activeInHierarchy)
    //        {
    //            col.enabled = true;
    //            rb.simulated = true;
    //            Debug.Log("Exited collision with player. Collision enabled again.");
    //        }
    //    }
    //}
    private void Start()
    {
        
    }
    private void TryAddItemToInventory()
    {
        bool itemAdded = false;

        if (type == ItemType.Health.ToString() && Inventory.instance.itemHealth.GetStack() < 3)
        {
            GetEntity();
            Inventory.instance.itemHealth.itemObject =this;
            Inventory.instance.itemHealth.AddStack();
            ManagerUI.instance.health.UpdateAmount(Inventory.instance.itemHealth.GetStack());
            CoverGameObject();
            itemAdded = true;
        }
        else if (type == ItemType.Power.ToString() && Inventory.instance.itemPower.GetStack() < 3)
        {
            GetEntity();
            Inventory.instance.itemPower.itemObject = this;
            Inventory.instance.itemPower.AddStack();
            ManagerUI.instance.power.UpdateAmount(Inventory.instance.itemPower.GetStack());
            CoverGameObject();
            itemAdded = true;
        }
        else if (type == ItemType.Key.ToString() && Inventory.instance.itemKey.GetStack() < 3)
        {
            GetEntity();
            Inventory.instance.itemKey.AddStack();
            ManagerUI.instance.amountEgg.ShowAmount(Inventory.instance.itemKey.GetStack());
            CoverGameObject();
            itemAdded = true;
        }
        else if (type == ItemType.Stone.ToString() && Inventory.instance.itemStone.GetStack() < 15)
        {
            GetEntity();
            Inventory.instance.itemStone.stack += (int)itemData.value;
            if (Inventory.instance.itemStone.stack >= 15)
            {
                Inventory.instance.itemStone.stack = 15;
            }
            ManagerUI.instance.amountStone.ShowAmount(Inventory.instance.itemStone.stack);
            CoverGameObject();
            itemAdded = true;
        }

        if (!itemAdded)
        {
            col.enabled = false;
            rb.simulated = false;
            Debug.Log("Item not added. Collision disabled.");
        }
    }

    private void GetEntity()
    {
        ManageState.instance.PlayOneShortAudio(ManageState.instance.auidoSFXEntity, ManageState.instance.entity);
    }
    private void Update()
    {

        // Check if the item can be picked up again
        if (!col.enabled && CanBePickedUpAgain())
        {
            col.enabled = true;
            rb.simulated = true;
            Debug.Log("Item can be picked up again. Collision enabled.");
        }
        rb.velocity = new Vector2(0, 0);
    }

    private bool CanBePickedUpAgain()
    {
        if (type == ItemType.Health.ToString() && Inventory.instance.itemHealth.GetStack() < 3)
        {
            return true;
        }
        else if (type == ItemType.Power.ToString() && Inventory.instance.itemPower.GetStack() < 3)
        {
            return true;
        }
        else if (type == ItemType.Key.ToString() && Inventory.instance.itemKey.GetStack() < 3)
        {
            return true;
        }
        else if (type == ItemType.Stone.ToString() && Inventory.instance.itemStone.GetStack() < 15)
        {
            return true;
        }
        return false;
    }

    private void CoverGameObject()
    {
        gameObject.SetActive(false);
    }
}
