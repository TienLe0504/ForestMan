using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealthBar : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    [SerializeField] public Image imageHealth;
    [SerializeField] public float fillSpeed = 0.5f;
    [SerializeField] public Gradient colorGradient;
    public virtual void Start()
    {
        //maxHealth = EnemyManager.instance.dinosaur.health;
        //currentHealth = maxHealth;
        
    }
    public virtual void IncreaseHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();
    }
    public virtual void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();
    }
    protected virtual void UpdateHealthBar()
    {
        float targetFillAmount = currentHealth / maxHealth;
        imageHealth.fillAmount = targetFillAmount;
        imageHealth.DOFillAmount(targetFillAmount, fillSpeed);
        imageHealth.DOColor(colorGradient.Evaluate(targetFillAmount), fillSpeed);
    }
    // Update is called once per frame
    public virtual void Update()
    {
        
    }
}
