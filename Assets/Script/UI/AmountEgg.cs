using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmountEgg : MonoBehaviour
{
    public TextMeshProUGUI amountOfEgg;
    // Start is called before the first frame update
    void Start()
    {
        amountOfEgg = GetComponentInChildren<TextMeshProUGUI>();
        ShowAmount(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowAmount(float _amount)
    {
        amountOfEgg.text = _amount.ToString();
    }
}
