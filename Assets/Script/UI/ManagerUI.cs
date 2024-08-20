using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI instance;
    [SerializeField] public UIHealth health;
    [SerializeField] public UIPower power;
    [SerializeField] public BtnHealth btnHealth;
    [SerializeField] public BtnPower btnPower;
    [SerializeField] public AmountEgg amountEgg;
    [SerializeField] public AmountStone amountStone;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
