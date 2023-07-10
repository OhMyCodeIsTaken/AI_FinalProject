using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] public UnityEvent OnDeath;
    [SerializeField] public Action<int, int> OnTakeDamage;
    [SerializeField] public Action<int, int> OnHeal;

    public int Damage { get => _damage; }
    public int MaxHealth { get => _maxHealth; }
    public int CurrentHealth { get => _currentHealth; }

    void Awake()
    {
        _currentHealth = MaxHealth;
    }

    public void Heal(int healAmount)
    {
        int missingHealth = MaxHealth - CurrentHealth;
        
        if(missingHealth > healAmount)
        {
            _currentHealth += healAmount;
            return;
        }
        else
        {
            _currentHealth = MaxHealth;
        }

        OnHeal?.Invoke(CurrentHealth, MaxHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        OnTakeDamage?.Invoke(CurrentHealth, MaxHealth);
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDeath?.Invoke();
    }
}
