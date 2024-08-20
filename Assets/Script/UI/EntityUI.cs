using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntityUI : MonoBehaviour
{
    public TextMeshProUGUI amount;
    protected virtual void Start()
    {
        amount = GetComponentInChildren<TextMeshProUGUI>();
        UpdateAmount(0);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
    public virtual void UpdateAmount(int _amount)
    {
        amount.text = _amount.ToString();
    }
}
