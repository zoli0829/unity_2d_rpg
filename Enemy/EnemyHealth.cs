using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [Header("Config")]
    [SerializeField] private float health;

    private readonly int dead = Animator.StringToHash("Dead");

    public float CurrentHealth { get; private set; }

    private Animator animator;
    private EnemyBrain enemyBrain;
    private EnemySelector enemySelector;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyBrain = GetComponent<EnemyBrain>();
        enemySelector = GetComponent<EnemySelector>();
    }

    private void Start()
    {
        CurrentHealth = health;
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            animator.SetTrigger(dead);
            enemyBrain.enabled = false;
            enemySelector.NoSelectionCallback();
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
        else
        {
            DamageManager.Instance.ShowDamageText(amount, transform);
        }
    }
}
