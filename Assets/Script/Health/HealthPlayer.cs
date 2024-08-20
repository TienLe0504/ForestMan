using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : Health
{
    Player player;
    public override void Awake()
    {
        base.Awake();
        player = GetComponent<Player>();
    }
    public override void Start()
    {
        base.Start();
        health =PlayerManager.instance.player.health;
    }
    public override void Update()
    {
        base.Update();
        if (health<=0)
        {
            player.checkDide = true;
        }
    }
    public override void Dodamage(float _health)
    {
        base.Dodamage(_health);
        HealthManager.instance.healthBar.DecreaseHealth(_health);
    }
    public override void IncreaseHealth(float _health)
    {
        base.IncreaseHealth(_health);
        HealthManager.instance.healthBar.IncreaseHealth(_health);
    }
}
