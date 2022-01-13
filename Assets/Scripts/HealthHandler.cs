using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class HealthHandler : MonoBehaviour, IDamageable
    {
        private int m_Health = 5;
        PlayerSettings m_Settings;

        public int Health => m_Health;
        public event Action<int, Collision2D, bool> OnDamageTaken;

        [Inject]
        void Construct(PlayerSettings settings)
        {
            m_Settings = settings;
            m_Health = m_Settings.MaxHealth;
        }


        public void TakeDamge(int damage, Collision2D collsion, bool FromLeftSide)
        {
            m_Health -= damage;
            OnDamageTaken.Invoke(damage, collsion, FromLeftSide);
        }

    }
}
