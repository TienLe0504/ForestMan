using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    [SerializeField] public HealthBar healthBar;
    [SerializeField] public PowerBar powerBar;
    //[SerializeField] public HealthEnemyBar healthEnemy;
    private void Awake()
    {
        if (instance == null)
        {
            instance =this;
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
