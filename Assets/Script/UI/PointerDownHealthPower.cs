using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerDownHealthPower : MonoBehaviour
{
    public bool checkHealth;
    public bool checkPower;
    private void Awake()
    {
        checkHealth = false;
        checkPower = false;
    }



    public void PointerHealth()
    {
        checkHealth = true;
    }
    public void PointerPower()
    {
        checkPower = true;
    }
}
