using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField]
    private int m_Health = 5;

    public int Health => m_Health;
    public event Action OnDamageTaken;
    public void TakeDamage(int damage)
    {
        m_Health -= damage;
        OnDamageTaken.Invoke();
    }
}
