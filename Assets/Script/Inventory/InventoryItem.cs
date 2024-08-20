using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public int stack =0;
    public ItemObject itemObject;
    public ItemType type;
    public void AddStack()
    {
        stack++;
    }
    public void RemoveStack()
    {
        stack--;
    }
    public int GetStack()
    {
        return stack;
    }
}
