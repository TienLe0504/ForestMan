using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemyBar : EntityHealthBar
{
    private Dinosaur dinosaur;
    public override void Start()
    {
        base.Start();
        dinosaur = GetComponentInParent<Dinosaur>();
        maxHealth =dinosaur.health;
        currentHealth=maxHealth;
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
        if (dinosaur.facingDir == 1)
        {
            imageHealth.fillOrigin = (int)Image.OriginHorizontal.Left;
        }
        else
        {
            imageHealth.fillOrigin = (int)Image.OriginHorizontal.Right;
        }
    }
}
