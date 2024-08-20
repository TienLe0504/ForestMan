using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public float maxPower;
    private float currenPower;
    private float speedPower = 0.5f;
    [SerializeField] private Image imagePower;
    private void Start()
    {
        maxPower = PlayerManager.instance.player.power;
        currenPower = maxPower;
    }
    public void IncreasePower(float _power)
    {
        currenPower += _power;
        currenPower = Mathf.Clamp(currenPower, 0f, maxPower);
        UpdatePower();
    }
    public void DecreasePower(float _power)
    {
        currenPower -= _power;
        currenPower = Mathf.Clamp(currenPower, 0f, maxPower);
        UpdatePower();
    }
    private void UpdatePower()
    {
        float targetFillAmount = currenPower / maxPower;
        imagePower.fillAmount = targetFillAmount;
        imagePower.DOFillAmount(targetFillAmount, speedPower);
    }

}
