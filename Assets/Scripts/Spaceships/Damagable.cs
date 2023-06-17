using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private UnityEvent _onDeath;

    public int Damage { get => _damage; }

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(int healAmount)
    {
        int missingHealth = _maxHealth - _currentHealth;
        
        if(missingHealth > healAmount)
        {
            _currentHealth += healAmount;
            return;
        }
        else
        {
            _currentHealth = _maxHealth;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        if(_currentHealth <= 0)
        {
           
        }
    }

    private void Die()
    {
        _onDeath.Invoke();
    }
}
