using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmountStone : MonoBehaviour
{
    public int amount;
    public TextMeshProUGUI amountOfStone;
    // Start is called before the first frame update
    void Start()
    {
        if (Inventory.instance.itemStone == null)
        {
            Inventory.instance.InitializeInventoryItems();
        }
        Inventory.instance.itemStone.stack = 10 ;
        amountOfStone = GetComponentInChildren<TextMeshProUGUI>();
        amount = Inventory.instance.itemStone.GetStack();
        if (amountOfStone == null)
        {
            Debug.LogError("TextMeshProUGUI component is missing in children.");
            return;
        }

        // Kiểm tra nếu `Inventory.instance` không null
        if (Inventory.instance == null)
        {
            Debug.LogError("Inventory.instance is null.");
            return;
        }

        // Kiểm tra nếu `itemStone` không null

        ShowAmount(amount);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowAmount(float _amount)
    {
        amountOfStone.text = _amount.ToString();
    }
}
