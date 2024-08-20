using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPower : EntityUI
{

    protected override void Start()
    {
        base.Start();

    }

    protected override void Update()
    {
        base.Update();
        ImpoverPower();
    }

    private void ImpoverPower()
    {
        if (ManagerUI.instance.btnPower.checkPower)
        {

            if (Inventory.instance.itemPower.GetStack() > 0 && PlayerManager.instance.player.power < HealthManager.instance.powerBar.maxPower)
            {
                ManageState.instance.PlayOneShortAudio(ManageState.instance.audioSFXHealth, ManageState.instance.healing);
                PlayerManager.instance.player.ImpoveEffect(PlayerManager.instance.player.powerEffect);
                PlayerManager.instance.player.power += Inventory.instance.itemPower.itemObject.value;
                if (PlayerManager.instance.player.power > HealthManager.instance.powerBar.maxPower)
                {
                    PlayerManager.instance.player.power = HealthManager.instance.powerBar.maxPower;
                }
                HealthManager.instance.powerBar.IncreasePower(Inventory.instance.itemPower.itemObject.value);
                Inventory.instance.itemPower.RemoveStack();
                UpdateAmount(Inventory.instance.itemPower.GetStack());
            }
            ManagerUI.instance.btnPower.checkPower = false;

        }
    }

    public override void UpdateAmount(int _amount)
    {
        base.UpdateAmount(_amount);
    }

    public void OnPowerButtonClick()
    {

    }
}
