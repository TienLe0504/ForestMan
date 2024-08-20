using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : EntityHealthBar
{
    public override void Start()
    {
        base.Start();
        maxHealth = PlayerManager.instance.player.health;
        currentHealth = maxHealth;
    }
    public override void DecreaseHealth(float amount)
    {
        base.DecreaseHealth(amount);

    }
    public override void IncreaseHealth(float amount)
    {
        base.IncreaseHealth(amount);
    }
    protected override void UpdateHealthBar()
    {
        base.UpdateHealthBar();
    }
    public override void Update()
    {
        base.Update();
    }

}
