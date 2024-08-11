using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAttack : FSMAction
{
    [Header("Config")]
    [SerializeField] private float damage;
    [SerializeField] private float timeBetweenAttacks;

    private EnemyBrain enemy;
    private float timer;

    private void Awake()
    {
        enemy = GetComponent<EnemyBrain>();
    }

    public override void Act()
    {
        AttackPlayer();
    }

    private void AttackPlayer()
    {
        if (enemy.Player == null) return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            IDamageable player = enemy.Player.GetComponent<IDamageable>();
            player.TakeDamage(damage);
            timer = timeBetweenAttacks;
        }
    }
}
