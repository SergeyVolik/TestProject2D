using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public class HealthHandler : MonoBehaviour, IDamageable, IHealable
    { 
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public event Action<int, Collision2D, bool> OnDamageTaken;
        public event Action<int> OnHealed;
        public event Action OnUpdated;
        public void TakeDamge(int damage, Collision2D collision, bool FromLeftSide)
        {
            Health -= damage;
            OnDamageTaken?.Invoke(damage, collision, FromLeftSide);
            OnUpdated?.Invoke();
        }

        public void Heal(int value)
        {
            Health += value;
            Health = Mathf.Clamp(Health, 0, MaxHealth);

            OnHealed?.Invoke(value);
            OnUpdated?.Invoke();
        }

        public void UpdateValue()
        {
            OnUpdated?.Invoke();
        }

        void Start()
        {
            UpdateValue();
        }
    }
}
