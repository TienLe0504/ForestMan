using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float health;

    public virtual void Awake()
    {

    }
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    public virtual void Dodamage(float _health)
    {
        health-=_health;
    }
    public virtual void IncreaseHealth(float _health)
    {
        health += _health;
    }
}
