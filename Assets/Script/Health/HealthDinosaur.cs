using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDinosaur : Health
{
    Dinosaur dinosaur;
    public override void Start()
    {
        base.Start();
        dinosaur = GetComponentInParent<Dinosaur>();
        //health = EnemyManager.instance.dinosaur.health ;
        health = dinosaur.health;

    }
    public override void Update()
    {
        base.Update();
        if (health <= 0)
        {
            dinosaur.checkDie = true;

            return;
        }
    }
    public override void Awake()
    {
        base.Awake();
        dinosaur = GetComponent<Dinosaur>();

    }
    public override void Dodamage(float _health)
    {
        base.Dodamage(_health);
        //HealthManager.instance.healthEnemy.DecreaseHealth(_health);
        GetComponentInChildren<HealthEnemyBar>().DecreaseHealth(_health);
    }

}
