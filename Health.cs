using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    [SerializeField] Slider healthBar;
    [SerializeField] TMP_Text healthText;
    public Idead Dead;

    public float regenOfHealthPerSecound;
    float health;
    
    void Awake()
    {
        health = maxHealth;
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = health;
        }

        if (healthText != null)
        {
            healthText.text = (int)health + "/" + maxHealth;
        }
    }

    void Update()
    {
        if (health < maxHealth)
        {
            health += regenOfHealthPerSecound * Time.deltaTime;
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void ChangeHealth(float amount)
    {
        health += amount;
        OnHealthChange();
        if(health < 0) Dead.Dead();
    }

    public void OnHealthChange()
    {
        if (healthBar != null)
        {
            healthBar.value = health;
        }
        if (healthText != null)
        {
            healthText.text = (int)health + "/" + maxHealth;
        }
    }
}
