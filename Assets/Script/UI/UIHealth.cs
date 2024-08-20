using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealth : EntityUI
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        ImproveHealth();
    }

    private void ImproveHealth()
    {
        if (ManagerUI.instance.btnHealth.checkHealth) 
        {
            if (Inventory.instance.itemHealth.GetStack() > 0 && PlayerManager.instance.player.healthPlayer.health<HealthManager.instance.healthBar.maxHealth)
            {
                ManageState.instance.PlayOneShortAudio(ManageState.instance.audioSFXHealth, ManageState.instance.healing);
                PlayerManager.instance.player.ImpoveEffect(PlayerManager.instance.player.healEffect);
                PlayerManager.instance.player.healthPlayer.IncreaseHealth(Inventory.instance.itemHealth.itemObject.value);
                Inventory.instance.itemHealth.RemoveStack();
                UpdateAmount(Inventory.instance.itemHealth.GetStack());
            }
            ManagerUI.instance.btnHealth.checkHealth = false;
        }
    }

    public override void UpdateAmount(int _amount)
    {
        base.UpdateAmount(_amount);
        if (PlayerManager.instance.player.healthPlayer.health > HealthManager.instance.healthBar.maxHealth)
        {
            PlayerManager.instance.player.healthPlayer.health = HealthManager.instance.healthBar.maxHealth;
        }

    }
    public void OnPowerButtonClick()
    {

    }
}
