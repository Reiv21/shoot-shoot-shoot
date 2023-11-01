using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Idead
{
    [SerializeField] Transform player;
    public Health healthScript;
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float attackSpeed;
    float tempAttackSpeed;
    [SerializeField] float attackRange;
    [SerializeField] Rigidbody rb;
    void Start()
    {
        player = PlayerTransform.playerTransform; 
        healthScript.Dead = this;
    }
    public void Dead()
    {
        Destroy(gameObject);
        ScoreManager.AddScore(1);
        PlayerUpgrades.AddIron(1);
    }

    void Update()
    {
        if(player == null) return;
        tempAttackSpeed -= Time.deltaTime;
        rb.velocity = (player.position - transform.position).normalized * speed;
        if (Vector3.Distance(transform.position, player.position) < attackRange && tempAttackSpeed < 0)
        {
            Attack();
        }
    }
    
    void Attack()
    {
        tempAttackSpeed = attackSpeed;
        player.GetComponent<Health>().ChangeHealth(-damage);
    }

    public void UpgradeEnemy(float amount)
    {
        healthScript.maxHealth += amount;
        healthScript.ChangeHealth(healthScript.maxHealth);
        speed += amount;
        damage += amount;
    }
}
